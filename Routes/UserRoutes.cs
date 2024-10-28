using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using QBank.Data;
using QBank.Models;

public static class UserRoutes
{
    public static void MapUserRoutes(this IEndpointRouteBuilder app)
    {
        //Find all
        app.MapGet("/users", async (AppDbContext dbContext) =>
        {
            var users = await dbContext.Users.ToListAsync();
            return Results.Ok(users);
        });

        //Find
        app.MapGet("/users/{id}", async (int id, AppDbContext dbContext) =>
        {
            var user = await dbContext.Users.FindAsync(id);
            return user is not null ? Results.Ok(user) : Results.NotFound();
        });

        //Create
        app.MapPost("/users", async (User user, AppDbContext dbContext) =>
        {
            dbContext.Users.Add(user);
            await dbContext.SaveChangesAsync();
            return Results.Created($"/users/{user.userId}", user);
        });

        //Update
        app.MapPut("/users/{id}", async (int id, User updatedUser, AppDbContext dbContext) =>
        {
            var user = await dbContext.Users.FindAsync(id);
            if (user is null) return Results.NotFound();

            // Atualiza os campos do usuário
            user.name = updatedUser.name;
            user.CPF = updatedUser.CPF;
            user.email = updatedUser.email;
            user.password = updatedUser.password;
            user.birthDate = updatedUser.birthDate;
            user.phone = updatedUser.phone;

            await dbContext.SaveChangesAsync();
            return Results.NoContent(); // 204 No Content
        });

        //Delete
        app.MapDelete("/users/{id}", async (int id, AppDbContext dbContext) =>
        {
            var user = await dbContext.Users.FindAsync(id);
            if (user is null) return Results.NotFound();

            dbContext.Users.Remove(user);
            await dbContext.SaveChangesAsync();
            return Results.NoContent(); // 204 No Content
        });
    }
}