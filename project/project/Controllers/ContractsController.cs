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
        Company company = await clientsService.GetCompanyById(dto.ClientId);
        Individual individual = await clientsService.GetIndividualById(dto.ClientId);
        if ((company is null && individual is null) || individual.IsDeleted) 
            return NotFound("Client with this id does not exist");

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
            EndDate = dto.EndDate
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

        Payment payment = new Payment()
        {
            ContractId = dto.ContractId,
            Amount = dto.Amount,
            Date = dto.Date
        };

        await contractsService.AddPayment(payment);
        
        return Created("/api/payments/"+payment.Id, payment);
    }
}