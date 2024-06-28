using project.Data;
using project.Models;
using project.Services.Interfaces;

namespace project.Services;

public class ClientsService: IClientsService
{
    private readonly ApplicationContext _context;

    public ClientsService(ApplicationContext context)
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
}