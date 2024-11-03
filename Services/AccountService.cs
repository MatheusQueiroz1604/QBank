using QBank.Data;
using QBank.Models;
using Microsoft.EntityFrameworkCore;

public class AccountService
{
    private readonly AppDbContext dbContext;

    public AccountService(AppDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<IEnumerable<Account>> GetAllAccountsAsync()
    {
        return await dbContext.Accounts.ToListAsync();
    }

    public async Task<Account?> GetAccountByIdAsync(int id)
    {
        return await dbContext.Accounts.FindAsync(id);
    }

    public async Task<Account> CreateAccountAsync(Account account)
    {
        dbContext.Accounts.Add(account);
        await dbContext.SaveChangesAsync();
        return account;
    }

    public async Task<bool> UpdateAccountAsync(int id, Account updatedAccount)
    {
        var account = await dbContext.Accounts.FindAsync(id);
        if (account == null)
            return false;

        // Atualiza os campos da conta
        account.Balance = updatedAccount.Balance;
        account.accountNumber = updatedAccount.accountNumber;
        account.accountType = updatedAccount.accountType;
        account.openingDate = updatedAccount.openingDate;
        account.clientId = updatedAccount.clientId;

        await dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAccountAsync(int id)
    {
        var account = await dbContext.Accounts.FindAsync(id);
        if (account == null)
            return false;

        dbContext.Accounts.Remove(account);
        await dbContext.SaveChangesAsync();
        return true;
    }
}