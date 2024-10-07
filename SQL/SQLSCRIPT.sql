CREATE TABLE User_Table
(
    userId INT PRIMARY KEY,
    name VARCHAR(300) NOT NULL,
    CPF VARCHAR(14) NOT NULL,
    email VARCHAR(250) NOT NULL,
    password VARCHAR(250) NOT NULL,
    birthDate DATETIME NOT NULL,
    phone VARCHAR(20) NOT NULL
);

CREATE TABLE Account_Table
(
    accountId INT PRIMARY KEY,
    balance DECIMAL(18, 2) NOT NULL,
    accountNumber VARCHAR(50) NOT NULL,
    accountType VARCHAR(50) NOT NULL,
    openingDate DATETIME NOT NULL,
    clientId INT NOT NULL,
    FOREIGN KEY (clientId) REFERENCES User_Table(userId)
);

CREATE TABLE Authentication_Table
(
    authenticationId INT PRIMARY KEY,
    clientId INT NOT NULL,
    token VARCHAR(255) NOT NULL,
    expirationDate DATETIME NOT NULL,
    FOREIGN KEY (clientId) REFERENCES User_Table(userId)
);

CREATE TABLE Credit_Card_Table
(
    creditCardId INT PRIMARY KEY,
    clientId INT NOT NULL,
    currentBill DECIMAL(10, 2) NOT NULL,
    approvalDate DATETIME NOT NULL,
    limit DECIMAL(10, 2) NOT NULL,
    FOREIGN KEY (clientId) REFERENCES Account_Table(accountId)
);

CREATE TABLE Debit_Card_Table
(
    debitCardId INT PRIMARY KEY,
    clientId INT NOT NULL,
    availableBalance DECIMAL(10, 2) NOT NULL,
    approvalDate DATETIME NOT NULL,
    FOREIGN KEY (clientId) REFERENCES Account_Table(accountId)
);

CREATE TABLE Pix_Table
(
    pixId INT PRIMARY KEY,
    pixKey VARCHAR(255) NOT NULL,
    pixKeyType VARCHAR(50) NOT NULL
);

CREATE TABLE Bank_Slip_Table
(
    bankSlipId INT PRIMARY KEY,
    barcode VARCHAR(255) NOT NULL,
    status VARCHAR(100) NOT NULL,
    dueDate DATETIME NOT NULL
);

CREATE TABLE Loan_Table
(
    loanId INT PRIMARY KEY,
    clientId INT NOT NULL,
    amount DECIMAL(10, 2) NOT NULL,
    requestDate DATETIME NOT NULL,
    deadline DATETIME NOT NULL,
    interestRate DECIMAL(10, 2) NULL,
    numberParcels INT NULL,
    FOREIGN KEY (clientId) REFERENCES User_Table(userId)
);

CREATE TABLE Transaction_Table
(
    transactionId INT PRIMARY KEY,
    transactionType VARCHAR(50) NOT NULL,
    amount DECIMAL(10, 2) NOT NULL,
    date DATETIME NOT NULL,
    originAccountId INT NOT NULL,
    destinationAccountId INT NULL,
    debitCardDetailsId INT NULL,
    creditCardDetailsId INT NULL,
    pixDetailsId INT NULL,
    bankSlipDetailsId INT NULL,
    loanDetailsId INT NULL,
    FOREIGN KEY (originAccountId) REFERENCES Account_Table(accountId),
    FOREIGN KEY (destinationAccountId) REFERENCES Account_Table(accountId),
    FOREIGN KEY (debitCardDetailsId) REFERENCES Debit_Card_Table(debitCardId),
    FOREIGN KEY (creditCardDetailsId) REFERENCES Credit_Card_Table(creditCardId),
    FOREIGN KEY (pixDetailsId) REFERENCES Pix_Table(pixId),
    FOREIGN KEY (bankSlipDetailsId) REFERENCES Bank_Slip_Table(bankSlipId),
    FOREIGN KEY (loanDetailsId) REFERENCES Loan_Table(loanId)
);