CREATE TABLE Users
(
    userId INT PRIMARY KEY,
    name VARCHAR(300) NOT NULL,
    cpf VARCHAR(14) NOT NULL,
    email VARCHAR(250) NOT NULL,
    password VARCHAR(250) NOT NULL,
    birthDate DATETIME NOT NULL,
    phone VARCHAR(20) NOT NULL
);

CREATE TABLE Accounts
(
    accountId INT PRIMARY KEY,
    balance DECIMAL(18, 2) NOT NULL,
    accountNumber VARCHAR(50) NOT NULL,
    accountType VARCHAR(50) NOT NULL,
    openingDate DATETIME NOT NULL,
    clientId INT NOT NULL,
    creditLimit DECIMAL(18, 2) DEFAULT 0.0,
    currentBill DECIMAL(18, 2) DEFAULT 0.0,
    availableBalance DECIMAL(18, 2) DEFAULT 0.0,
    
    FOREIGN KEY (clientId) REFERENCES User_Table(userId)
);

CREATE TABLE Transactions
(
    transactionId INT PRIMARY KEY,
    transactionType VARCHAR(50) NOT NULL,
    amount DECIMAL(18, 2) NOT NULL,
    date DATETIME NOT NULL,
    originAccountId INT NOT NULL,
    destinationAccountId INT NULL,
    barcode VARCHAR(255) DEFAULT NULL,
    pixKey VARCHAR(255) DEFAULT NULL,
    pixKeyType VARCHAR(50) DEFAULT NULL,
    interestRate DECIMAL(5, 2) DEFAULT NULL,
    numberParcels INT DEFAULT NULL,
    dueDate DATETIME DEFAULT NULL,
    approvalDate DATETIME DEFAULT NULL,

    FOREIGN KEY (originAccountId) REFERENCES Account_Table(accountId),
    FOREIGN KEY (destinationAccountId) REFERENCES Account_Table(accountId)
);