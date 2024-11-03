using QBank.Data;
using QBank.Models;
using Microsoft.EntityFrameworkCore;

public class TransactionService 
{
    private readonly AppDbContext dbContext;

    public TransactionService(AppDbContext dbContext) 
    {
        this.dbContext = dbContext;
    }
    public async Task<IEnumerable<Transaction>> GetAllTransactionsAsync()
    {
        return await dbContext.Transactions.ToListAsync();
    }

    public async Task<Transaction?> GetTransactionByIdAsync(int id)
    {
        return await dbContext.Transactions.FindAsync(id);
    }

    public async Task<Transaction> CreateTransactionAsync (Transaction transaction)
    {
        dbContext.Transactions.Add(transaction);
        await dbContext.SaveChangesAsync();
        return transaction;
    }

    public async Task<bool> UpdateTransactionAsync(int id, Transaction updatedTransaction)
    {
        var transaction = await dbContext.Transactions.FindAsync(id);
        if (transaction == null)
            return false;

        // Atualiza os campos da transação
        transaction.amount = updatedTransaction.amount;
        transaction.barcode = updatedTransaction.barcode;
        transaction.pixKey = updatedTransaction.pixKey;
        transaction.pixKeyType = updatedTransaction.pixKeyType;
        transaction.interestRate = updatedTransaction.interestRate;
        transaction.numberParcels = updatedTransaction.numberParcels;
        transaction.dueDate = updatedTransaction.dueDate;
        transaction.approvalDate = updatedTransaction.approvalDate;
        transaction.destinationAccountId = updatedTransaction.destinationAccountId;

        await dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteTransactionAsync (int id)
    {
        var transaction = await dbContext.Transactions.FindAsync(id);
        if (transaction==null)
            return false;
        
        dbContext.Transactions.Remove(transaction);
        await dbContext.SaveChangesAsync();
        return true;
    }
}