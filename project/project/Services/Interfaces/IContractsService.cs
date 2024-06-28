using project.Models;

namespace project.Services.Interfaces;
public interface IContractsService
{
    Task<bool> DoesSoftwareExist(int id);
    
    Task AddContract(Contract contract);
    Task<bool> DoesContractExist(int id);

    Task AddPayment(Payment payment);
}