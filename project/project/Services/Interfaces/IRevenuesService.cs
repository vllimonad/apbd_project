using project.Models;

namespace project.Services.Interfaces;
public interface IRevenuesService
{
    Task<ICollection<Payment>> GetAllPayments();
    Task<Contract> GetContractById(int id);
    Task<ICollection<Contract>> GetAllContracts();
    Task<double> Convert(double amount, string currency);
}