using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using project.Models;
using project.Services.Interfaces;

namespace project.Controllers;

[ApiController]
[Route("/api/revenue")]
public class RevenuesController: ControllerBase
{
    private readonly IRevenuesService _service;

    public RevenuesController(IRevenuesService service)
    {
        _service = service;
    }

    [HttpGet("/current")]
    [Authorize]
    public async Task<IActionResult> CalculateRevenue(int? SoftwareId, string Currency = "PLN")
    {
        ICollection<Payment> payments = await _service.GetAllPayments();
        List<double> amounts = new List<double>();
        double sum = 0;
        
        if (SoftwareId is null) 
        {
            amounts = payments.Select(p => p.Amount).ToList();
        } 
        else 
        {
            for (int i = 0; i < payments.Count; i++)
            {
                Contract contract = await _service.GetContractById(payments.ElementAt(i).ContractId);
                if (contract.SoftwareId == SoftwareId) 
                    amounts.Add(payments.ElementAt(i).Amount);
            }
        }
        
        for (int i = 0; i < amounts.Count; i++)
        {
            sum += amounts[i];
        }

        sum = await _service.Convert(sum, Currency);
        return Ok("Current revenue: " + sum + " " + Currency);
    }

    [HttpGet("/predicted")]
    [Authorize]
    public async Task<IActionResult> CalculatePredictedRevenue(int? SoftwareId, string Currency = "PLN")
    {
        ICollection<Contract> contracts = await _service.GetAllContracts();
        List<double> prices = new List<double>();
        double sum = 0;
        
        if (SoftwareId is null) 
        {
            prices = contracts.Select(c => c.Price).ToList();
        } 
        else 
        {
            prices = contracts.Where(c => c.SoftwareId == SoftwareId)
                .Select(c => c.Price).ToList();
        }
        
        for (int i = 0; i < prices.Count; i++)
        {
            sum += prices[i];
        }

        sum = await _service.Convert(sum, Currency);
        return Ok("Predicted revenue: " + sum + " " + Currency);
    }
}