using Microsoft.AspNetCore.Mvc;
using project.Models;
using project.Models.DTOs;
using project.Services;

namespace project.Controllers;

[ApiController]
[Route("/api/clients")]
public class ClientsController: ControllerBase
{
    private readonly IApplicationService _service;

    public ClientsController(IApplicationService service)
    {
        _service = service;
    }

    [HttpPost("/addIndividual")]
    public IActionResult AddIndividual(NewIndividualDTO dto)
    {
        Individual individual = new Individual()
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            PESEL = dto.PESEL,
            Address = dto.Address,
            Email = dto.Email,
            PhoneNumber = dto.PhoneNumber
        };
        _service.AddIndividual(individual);
        
        return Created("api/clients/"+individual.Id, individual);
    }
    
    [HttpPost("/addCompany")]
    public async Task<IActionResult> AddCompany(NewCompanyDTO dto)
    {
        Company company = new Company()
        {
            Name = dto.Name,
            KRS = dto.KRS,
            Address = dto.Address,
            Email = dto.Email,
            PhoneNumber = dto.PhoneNumber
        };
        await _service.AddCompany(company);
        
        return Created("api/clients/"+company.Id, company);
    }
    
    [HttpDelete("/removeClient")]
    public async Task<IActionResult> RemoveClient(int id)
    {
        Company company = await _service.GetCompanyById(id);
        if (company is not null) return BadRequest("Companies can not be removed");
        
        Individual individual = await _service.GetIndividualById(id);
        if (individual is not null)
        {
            individual.IsDeleted = true;
            await _service.UpdateIndividual(individual);
            return Ok();
        }
        
        return NotFound("Client with this id does not exist");
    }
    
    [HttpPost("/updateIndividual/{id}")]
    public async Task<IActionResult> UpdateIndividual(int id, UpdateIndividualDTO dto)
    {
        Individual individual = await _service.GetIndividualById(id);
        if (individual is null) return NotFound("Individual with this id does not exist");
        
        individual.FirstName = dto.FirstName;
        individual.LastName = dto.LastName;
        individual.Email = dto.Email;
        individual.PhoneNumber = dto.PhoneNumber;
        individual.Address = dto.Address;
        await _service.UpdateIndividual(individual);
        
        return Ok();
    }
    
    [HttpPost("/updateCompany/{id}")]
    public async Task<IActionResult> UpdateCompany(int id, UpdateCompanyDTO dto)
    {
        Company company = await _service.GetCompanyById(id);
        if (company is null) return NotFound("Company with this id does not exist");

        company.Name = dto.Name;
        company.Email = dto.Email;
        company.PhoneNumber = dto.PhoneNumber;
        company.Address = dto.Address;
        await _service.UpdateCompany(company);
        
        return Ok();
    }
}