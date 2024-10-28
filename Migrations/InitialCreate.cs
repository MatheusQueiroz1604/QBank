using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QBank.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    accountId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    balance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    accountNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    accountType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    openingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    clientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.accountId);
                });

            migrationBuilder.CreateTable(
                name: "Authentication",
                columns: table => new
                {
                    authenticationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    clientId = table.Column<int>(type: "int", nullable: false),
                    token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    expirationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authentication", x => x.authenticationId);
                });

            migrationBuilder.CreateTable(
                name: "BankSlip",
                columns: table => new
                {
                    bankSlipId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    barcode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dueDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankSlip", x => x.bankSlipId);
                });

            migrationBuilder.CreateTable(
                name: "CreditCard",
                columns: table => new
                {
                    creditCardId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    clientId = table.Column<int>(type: "int", nullable: false),
                    currentBill = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    approvalDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    limit = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditCard", x => x.creditCardId);
                });

            migrationBuilder.CreateTable(
                name: "DebitCard",
                columns: table => new
                {
                    debitCardId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    clientId = table.Column<int>(type: "int", nullable: false),
                    availableBalance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    approvalDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DebitCard", x => x.debitCardId);
                });

            migrationBuilder.CreateTable(
                name: "Loan",
                columns: table => new
                {
                    loanId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    clientId = table.Column<int>(type: "int", nullable: false),
                    amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    requestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    deadline = table.Column<DateTime>(type: "datetime2", nullable: false),
                    interestRate = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    numberParcels = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loan", x => x.loanId);
                });

            migrationBuilder.CreateTable(
                name: "PIX",
                columns: table => new
                {
                    pixId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    pixKey = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    pixKeyType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PIX", x => x.pixId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    userId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CPF = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    birthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    phone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.userId);
                });

            migrationBuilder.CreateTable(
                name: "Transaction",
                columns: table => new
                {
                    transactionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    transactionType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    originAccountId = table.Column<int>(type: "int", nullable: false),
                    destinationAccountId = table.Column<int>(type: "int", nullable: true),
                    debitCardDetailsdebitCardId = table.Column<int>(type: "int", nullable: true),
                    creditCardDetailscreditCardId = table.Column<int>(type: "int", nullable: true),
                    pixDetailspixId = table.Column<int>(type: "int", nullable: true),
                    bankSlipDetailsbankSlipId = table.Column<int>(type: "int", nullable: true),
                    loanDetailsloanId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transaction", x => x.transactionId);
                    table.ForeignKey(
                        name: "FK_Transaction_BankSlip_bankSlipDetailsbankSlipId",
                        column: x => x.bankSlipDetailsbankSlipId,
                        principalTable: "BankSlip",
                        principalColumn: "bankSlipId");
                    table.ForeignKey(
                        name: "FK_Transaction_CreditCard_creditCardDetailscreditCardId",
                        column: x => x.creditCardDetailscreditCardId,
                        principalTable: "CreditCard",
                        principalColumn: "creditCardId");
                    table.ForeignKey(
                        name: "FK_Transaction_DebitCard_debitCardDetailsdebitCardId",
                        column: x => x.debitCardDetailsdebitCardId,
                        principalTable: "DebitCard",
                        principalColumn: "debitCardId");
                    table.ForeignKey(
                        name: "FK_Transaction_Loan_loanDetailsloanId",
                        column: x => x.loanDetailsloanId,
                        principalTable: "Loan",
                        principalColumn: "loanId");
                    table.ForeignKey(
                        name: "FK_Transaction_PIX_pixDetailspixId",
                        column: x => x.pixDetailspixId,
                        principalTable: "PIX",
                        principalColumn: "pixId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_bankSlipDetailsbankSlipId",
                table: "Transaction",
                column: "bankSlipDetailsbankSlipId");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_creditCardDetailscreditCardId",
                table: "Transaction",
                column: "creditCardDetailscreditCardId");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_debitCardDetailsdebitCardId",
                table: "Transaction",
                column: "debitCardDetailsdebitCardId");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_loanDetailsloanId",
                table: "Transaction",
                column: "loanDetailsloanId");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_pixDetailspixId",
                table: "Transaction",
                column: "pixDetailspixId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropTable(
                name: "Authentication");

            migrationBuilder.DropTable(
                name: "Transaction");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "BankSlip");

            migrationBuilder.DropTable(
                name: "CreditCard");

            migrationBuilder.DropTable(
                name: "DebitCard");

            migrationBuilder.DropTable(
                name: "Loan");

            migrationBuilder.DropTable(
                name: "PIX");
        }
    }
}
