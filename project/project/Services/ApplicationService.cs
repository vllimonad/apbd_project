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
}