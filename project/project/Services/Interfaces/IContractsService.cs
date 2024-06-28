using project.Models;

namespace project.Services.Interfaces;
public interface IContractsService
{
    Task<bool> DoesSoftwareExist(int id);
    
    Task AddContract(Contract contract);
    Task<bool> DoesContractExist(int id);
    Task<Contract> GetContractById(int id);
    Task UpdateContract(Contract contract);

    Task AddPayment(Payment payment);
    Task<List<Payment>> GetPaymentsOfContract(int id);
}