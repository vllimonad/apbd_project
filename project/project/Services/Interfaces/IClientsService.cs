using project.Models;

namespace project.Services.Interfaces;

public interface IClientsService
{
    Task AddIndividual(Individual individual);
    Task<Individual> GetIndividualById(int id);
    Task UpdateIndividual(Individual individual);
    
    Task AddCompany(Company company);
    Task<Company> GetCompanyById(int id);
    Task UpdateCompany(Company company);
}