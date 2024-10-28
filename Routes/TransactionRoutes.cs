using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using QBank.Data;
using QBank.Models;

public static class TransactionRoutes
{
    public static void MapTransactionRoutes(this IEndpointRouteBuilder app)
    {
        //Find all
        app.MapGet("/transactions", async (AppDbContext dbContext) =>
        {
            var transactions = await dbContext.Transactions.ToListAsync();
            return Results.Ok(transactions);
        });

        //Find
        app.MapGet("/transactions/{id}", async (int id, AppDbContext dbContext) =>
        {
            var transaction = await dbContext.Transactions.FindAsync(id);
            return transaction is not null ? Results.Ok(transaction) : Results.NotFound();
        });

        //Create
        app.MapPost("/transactions", async (Transaction transaction, AppDbContext dbContext) =>
        {
            dbContext.Transactions.Add(transaction);
            await dbContext.SaveChangesAsync();
            return Results.Created($"/transactions/{transaction.transactionId}", transaction);
        });

        //Update
        app.MapPut("/transactions/{id}", async (int id, Transaction updatedTransaction, AppDbContext dbContext) =>
        {
            var transaction = await dbContext.Transactions.FindAsync(id);
            if (transaction is null) return Results.NotFound();

            // Atualiza os campos da transação
            transaction.transactionType = updatedTransaction.transactionType;
            transaction.amount = updatedTransaction.amount;
            transaction.date = updatedTransaction.date;
            transaction.originAccountId = updatedTransaction.originAccountId;
            transaction.destinationAccountId = updatedTransaction.destinationAccountId;

            await dbContext.SaveChangesAsync();
            return Results.NoContent(); // 204 No Content
        });

        //Delete
        app.MapDelete("/transactions/{id}", async (int id, AppDbContext dbContext) =>
        {
            var transaction = await dbContext.Transactions.FindAsync(id);
            if (transaction is null) return Results.NotFound();

            dbContext.Transactions.Remove(transaction);
            await dbContext.SaveChangesAsync();
            return Results.NoContent(); // 204 No Content
        });
    }
}
