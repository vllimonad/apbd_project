using Microsoft.EntityFrameworkCore;
using project.Data;
using project.Models;
using project.Services.Interfaces;

namespace project.Services;

public class RevenuesService: IRevenuesService
{
    private readonly ApplicationContext _context;

    public RevenuesService(ApplicationContext context)
    {
        _context = context;
    }

    public async Task<Contract> GetContractById(int id)
    {
        return await _context.Contracts.FindAsync(id);
    }
    
    public async Task<ICollection<Payment>> GetAllPayments()
    {
        return await _context.Payments.ToListAsync();
    }
    
    public async Task<ICollection<Contract>> GetAllContracts()
    {
        return await _context.Contracts.ToListAsync();
    }

    public async Task<double> Convert(double amount, string currency)
    {
        if (currency == "PLN") return amount;
        HttpClient client = new HttpClient();
        var response = await client.GetAsync("http://api.nbp.pl/api/exchangerates/rates/A/" + currency);
        Currency c = await response.Content.ReadAsAsync<Currency>();
        return amount / c.rates[0].mid;
    }
}


public class Currency
{
    public List<Rate> rates;
}

public class Rate
{
    public double mid;
}