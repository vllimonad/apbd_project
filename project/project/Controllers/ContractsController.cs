using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using project.Models;
using project.Models.DTOs;
using project.Services.Interfaces;
namespace project.Controllers;

[ApiController]
[Route("/api/contract")]
public class ContractsController: ControllerBase
{
    private readonly IContractsService contractsService;
    private readonly IClientsService clientsService;
    
    public ContractsController(IContractsService contractsService, IClientsService clientsService)
    {
        this.contractsService = contractsService;
        this.clientsService = clientsService;
    }
    
    [HttpPost("/create")]
    [Authorize]
    public async Task<IActionResult> CreateContract(NewContractDTO dto)
    {
        if (dto.ClientType == ClientType.Company)
        {
            Company company = await clientsService.GetCompanyById(dto.ClientId);
            if (company is null) return NotFound("Company with this id does not exist");
            
            List<Contract> companyContracts = await contractsService.GetContractsOfCompany(company.Id);
            for (int i = 0; i < companyContracts.Count; i++)
            {
                if (companyContracts[i].SoftwareId == dto.SoftwareId)
                    return BadRequest("This company already has contract for this software");
            }
        }
        else
        {
            Individual individual = await clientsService.GetIndividualById(dto.ClientId);
            if (individual is null || individual.IsDeleted) return NotFound("Individual client with this id does not exist");
            
            List<Contract> individualContracts = await contractsService.GetContractsOfIndividual(individual.Id);
            for (int i = 0; i < individualContracts.Count; i++)
            {
                if (individualContracts[i].SoftwareId == dto.SoftwareId)
                    return BadRequest("This individual client already has contract for this software");
            }
        }

        if (!await contractsService.DoesSoftwareExist(dto.SoftwareId)) 
            return NotFound("Software with this id does not exist");
        
        int NumberOfDays = (dto.EndDate - dto.StartDate).Days;
        if (NumberOfDays < 3 || NumberOfDays > 30)
            return BadRequest("The time range should be at least 3 days and at most 30 days");

        Contract contract = new Contract()
        {
            ClientId = dto.ClientId,
            SoftwareId = dto.SoftwareId,
            Price = dto.Price,
            Version = dto.Version,
            StartDate = dto.StartDate,
            EndDate = dto.EndDate,
            ClientType = dto.ClientType
        };

        await contractsService.AddContract(contract);
        
        return Created("/api/contracts/"+contract.Id, contract);
    }

    [HttpPost("/addPayment")]
    [Authorize]
    public async Task<IActionResult> IssuePayment(NewPaymentDTO dto)
    {
        if (!await contractsService.DoesContractExist(dto.ContractId))
            return NotFound("Contract with this id does not exist");
        
        var contract = await contractsService.GetContractById(dto.ContractId);
        if (dto.Date > contract.EndDate) 
            return BadRequest("We cannot accept the payment for a contract after the date specified within the contract");
        

        Payment payment = new Payment()
        {
            ContractId = dto.ContractId,
            Amount = dto.Amount,
            Date = dto.Date
        };

        await contractsService.AddPayment(payment);
        List<Payment> payments = await contractsService.GetPaymentsOfContract(dto.ContractId);
        var sum = 0.0;
        for (int i = 0; i < payments.Count; i++)
        {
            sum += payments[i].Amount;
        }

        if (sum == contract.Price)
        {
            contract.IsSigned = true;
            await contractsService.UpdateContract(contract);
        }

        return Created("/api/payments/"+payment.Id, payment);
    }
}