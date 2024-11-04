using Microsoft.AspNetCore.Mvc;
using QBank.Models;
using QBank.Filters;

namespace QBank.Controllers
{
    [Route("/transactions")]
    [ApiController]
    [ServiceFilter(typeof(TokenAuthorizeFilter))]
    public class TransactionController : ControllerBase
    {
        private readonly TransactionService transactionService;

        private TransactionController (TransactionService transactionService)
        {
            this.transactionService = transactionService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Transaction>>> GetTransactions()
        {
            var transactions = await transactionService.GetAllTransactionsAsync();
            return Ok(transactions);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Transaction>> GetTransaction(int id)
        {
            var transaction = await transactionService.GetTransactionByIdAsync(id);
            if (transaction==null)
                return NotFound();

            return Ok(transaction);
        }

        [HttpPost]
        public async Task<ActionResult<Transaction>> PostTransaction(Transaction transaction)
        {
            var createdTransaction = await transactionService.CreateTransactionAsync(transaction);
            return CreatedAtAction(nameof(GetTransaction), new { id = createdTransaction.transactionId }, createdTransaction);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTransaction(int id, Transaction transaction)
        {
            var result = await transactionService.UpdateTransactionAsync(id, transaction);
            if (!result)
                return NotFound();

            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTransaction(int id)
        {
            var result = await transactionService.DeleteTransactionAsync(id);
            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}