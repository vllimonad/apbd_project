using Microsoft.EntityFrameworkCore;
using project.Data;
using project.Models;
using project.Services.Interfaces;

namespace project.Services;

public class ContractsService: IContractsService
{
    private readonly ApplicationContext _context;

    public ContractsService(ApplicationContext context)
    {
        _context = context;
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
    
    public async Task<List<Payment>> GetPaymentsOfContract(int id)
    {
        return await _context.Payments.Where(p => p.ContractId == id).ToListAsync();
    }
    
    public async Task<Contract> GetContractById(int id)
    {
        return await _context.Contracts.FindAsync(id);
    }
    
    public async Task UpdateContract(Contract contract)
    {
        _context.Contracts.Update(contract);
        await _context.SaveChangesAsync();
    }
    
    public async Task<List<Contract>> GetContractsOfCompany(int id)
    {
        return await _context.Contracts
            .Where(c => c.ClientType == ClientType.Company && c.ClientId == id)
            .ToListAsync();
    }
    
    public async Task<List<Contract>> GetContractsOfIndividual(int id)
    {
        return await _context.Contracts
            .Where(c => c.ClientType == ClientType.Individual && c.ClientId == id)
            .ToListAsync();
    }
}