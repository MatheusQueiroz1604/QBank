using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using QBank.Data;
using QBank.Models;

public static class AccountRoutes
{
    public static void MapAccountRoutes(this IEndpointRouteBuilder app)
    {
        //Find all
        app.MapGet("/accounts", async (AppDbContext dbContext) =>
        {
            var accounts = await dbContext.Accounts.ToListAsync();
            return Results.Ok(accounts);
        });

        //Find
        app.MapGet("/accounts/{id}", async (int id, AppDbContext dbContext) =>
        {
            var account = await dbContext.Accounts.FindAsync(id);
            return account is not null ? Results.Ok(account) : Results.NotFound();
        });

        //Create
        app.MapPost("/accounts", async (Account account, AppDbContext dbContext) =>
        {
            dbContext.Accounts.Add(account);
            await dbContext.SaveChangesAsync();
            return Results.Created($"/accounts/{account.accountId}", account);
        });

        //Update
        app.MapPut("/accounts/{id}", async (int id, Account updatedAccount, AppDbContext dbContext) =>
        {
            var account = await dbContext.Accounts.FindAsync(id);
            if (account is null) return Results.NotFound();

            // Atualiza os campos da conta
            account.Balance = updatedAccount.Balance;
            account.accountNumber = updatedAccount.accountNumber;
            account.accountType = updatedAccount.accountType;
            account.openingDate = updatedAccount.openingDate;
            account.clientId = updatedAccount.clientId;

            await dbContext.SaveChangesAsync();
            return Results.NoContent(); // 204 No Content
        });

        //Delete
        app.MapDelete("/accounts/{id}", async (int id, AppDbContext dbContext) =>
        {
            var account = await dbContext.Accounts.FindAsync(id);
            if (account is null) return Results.NotFound();

            dbContext.Accounts.Remove(account);
            await dbContext.SaveChangesAsync();
            return Results.NoContent(); // 204 No Content
        });
    }
}
