using project.Models;

namespace project.Services;

public interface IApplicationService
{
    Task AddIndividual(Individual individual);
    Task<Individual> GetIndividualById(int id);
    Task UpdateIndividual(Individual individual);
    
    Task AddCompany(Company company);
    Task<Company> GetCompanyById(int id);
    Task UpdateCompany(Company company);

    Task<bool> DoesSoftwareExist(int id);
    
    Task AddContract(Contract contract);
    Task<bool> DoesContractExist(int id);

    Task AddPayment(Payment payment);
}