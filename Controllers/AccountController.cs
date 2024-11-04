// Controllers/AccountController.cs
using Microsoft.AspNetCore.Mvc;
using QBank.Models;
using QBank.Filters;

namespace QBank.Controllers
{
    [Route("/accounts")]
    [ApiController]
    [ServiceFilter(typeof(TokenAuthorizeFilter))]
    public class AccountController : ControllerBase
    {
        private readonly AccountService accountService;

        public AccountController(AccountService accountService)
        {
            this.accountService = accountService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Account>>> GetAccounts()
        {
            var accounts = await accountService.GetAllAccountsAsync();
            return Ok(accounts);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Account>> GetAccount(int id)
        {
            var account = await accountService.GetAccountByIdAsync(id);
            if (account == null)
                return NotFound();

            return Ok(account);
        }

        [HttpPost]
        public async Task<ActionResult<Account>> PostAccount(Account account)
        {
            var createdAccount = await accountService.CreateAccountAsync(account);
            return CreatedAtAction(nameof(GetAccount), new { id = createdAccount.accountId }, createdAccount);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAccount(int id, Account account)
        {
            var result = await accountService.UpdateAccountAsync(id, account);
            if (!result)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccount(int id)
        {
            var result = await accountService.DeleteAccountAsync(id);
            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}
