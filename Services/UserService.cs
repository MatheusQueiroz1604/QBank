using QBank.Data;
using QBank.Models;
using Microsoft.EntityFrameworkCore;

public class UserService
{
    private readonly AppDbContext dbContext;

    public UserService(AppDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<IEnumerable<User>> GetAllUsersAsync()
    {
        return await dbContext.Users.ToListAsync();
    }

    public async Task<User?> GetUserByIdAsync(int id)
    {
        return await dbContext.Users.FindAsync(id);
    }

    public async Task<User> CreateUserAsync(User user)
    {
        dbContext.Users.Add(user);
        await dbContext.SaveChangesAsync();
        return user;
    }

    public async Task<bool> UpdateUserAsync(int id, User updatedUser)
    {
        var user = await dbContext.Users.FindAsync(id);
        if (user == null)
            return false;

        // Atualiza os campos do usuário
        user.name = updatedUser.name;
        user.CPF = updatedUser.CPF;
        user.email = updatedUser.email;
        user.password = updatedUser.password;
        user.birthDate = updatedUser.birthDate;
        user.phone = updatedUser.phone;

        await dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteUserAsync(int id)
    {
        var user = await dbContext.Users.FindAsync(id);
        if (user == null)
            return false;

        dbContext.Users.Remove(user);
        await dbContext.SaveChangesAsync();
        return true;
    }
}