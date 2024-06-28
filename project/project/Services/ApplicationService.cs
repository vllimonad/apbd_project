using Microsoft.EntityFrameworkCore;
using project.Data;
using project.Models;

namespace project.Services;

public class ApplicationService: IApplicationService
{
    private readonly ApplicationContext _context;

    public ApplicationService(ApplicationContext context)
    {
        _context = context;
    }

    public async Task AddIndividual(Individual individual)
    {
        await _context.AddAsync(individual);
        await _context.SaveChangesAsync();
    }

    public async Task<Individual> GetIndividualById(int id)
    {
        return await _context.Individuals.FindAsync(id);
    }
    
    public async Task UpdateIndividual(Individual individual)
    {
        _context.Individuals.Update(individual);
        await _context.SaveChangesAsync();
    }
    
    public async Task AddCompany(Company company)
    {
        await _context.AddAsync(company);
        await _context.SaveChangesAsync();
    }

    public async Task<Company> GetCompanyById(int id)
    {
        return await _context.Companies.FindAsync(id);
    }
    
    public async Task UpdateCompany(Company company)
    {
        _context.Companies.Update(company);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> DoesSoftwareExist(int id)
    {
        return await _context.Softwares.AnyAsync(s => s.Id == id);
    }
    
    public async Task AddContract(Contract contract)
    {
        await _context.AddAsync(contract);
        await _context.SaveChangesAsync();
    }
    
    public async Task<bool> DoesContractExist(int id)
    {
        return await _context.Contracts.AnyAsync(s => s.Id == id);
    }
    
    public async Task AddPayment(Payment payment)
    {
        await _context.AddAsync(payment);
        await _context.SaveChangesAsync();
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