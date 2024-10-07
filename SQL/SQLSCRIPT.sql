CREATE TABLE UserTable
( 
    Id INT PRIMARY KEY,
    Nome VARCHAR(300) NOT NULL,
    CPF VARCHAR(14) NOT NULL,
    Email VARCHAR(250) NOT NULL,
    Senha VARCHAR(250) NOT NULL,
    DataNascimento DATETIME NOT NULL,
    Telefone VARCHAR(20) NOT NULL
);

CREATE TABLE AccountTable
(
    id INT PRIMARY KEY,
    Saldo DECIMAL(18, 2) NULL,
    NumeroConta VARCHAR(50) NOT NULL,
    TipoConta VARCHAR(50) NOT NULL,
    DataAbertura DATETIME NOT NULL,
    ClienteId INT NOT NULL,
    FOREIGN KEY (ClienteId) REFERENCES UserTable(Id)
);

CREATE TABLE AuthenticationTable
(
    Id INT PRIMARY KEY,
    ClienteId INT NOT NULL,
    Token VARCHAR(255) NOT NULL,
    DataExpiracao DATETIME NOT NULL,
    FOREIGN KEY (ClienteId) REFERENCES UserTable(Id)
);

CREATE TABLE CreditCardTable
(
    CartaoId INT PRIMARY KEY,
    ClienteId INT NOT NULL,
    FaturaAtual DECIMAL(10, 2) NOT NULL,
    DataAprovacao DATETIME NOT NULL,
    Limite DECIMAL(10, 2) NOT NULL,
    FOREIGN KEY (ClienteId) REFERENCES UserTable(Id)
);

CREATE TABLE DebitCardTable
(
    CartaoId INT PRIMARY KEY,
    ClienteId INT NOT NULL,
    SaldoDisponivel DECIMAL(10, 2) NOT NULL,
    DataAprovacao DATETIME NOT NULL,
    FOREIGN KEY (ClienteId) REFERENCES UserTable(Id)
);

CREATE TABLE PIXTable
(
    PIXId INT PRIMARY KEY,
    ChavePix VARCHAR(255) NOT NULL,
    TipoChavePix VARCHAR(50) NOT NULL
);

CREATE TABLE BoletoTable
(
    BoletoId INT PRIMARY KEY,
    CodigoBarras VARCHAR(255) NOT NULL,
    DataVencimento DATETIME NOT NULL
);

CREATE TABLE LoanTable
(
    EmprestimoId INT PRIMARY KEY,
    ClienteId INT NOT NULL,
    Valor DECIMAL(10, 2) NOT NULL,
    DataSolicitacao DATETIME NOT NULL,
    Prazo DATETIME NOT NULL,
    Juros DECIMAL(10, 2) NULL,
    FOREIGN KEY (ClienteId) REFERENCES UserTable(Id)
);

CREATE TABLE TransactionTable
(
    TransacaoId INT PRIMARY KEY,
    TipoTransacao VARCHAR(50) NOT NULL,
    Valor DECIMAL(10, 2) NOT NULL,
    Data DATETIME NOT NULL,
    ContaOrigemId INT NOT NULL,
    ContaDestinoId INT NULL,
    DebitCardDetailsId INT NULL,
    CreditCardDetailsId INT NULL,
    PixDetailsId INT NULL,
    BoletoDetailsId INT NULL,
    LoanDetailsId INT NULL,
    FOREIGN KEY (ContaOrigemId) REFERENCES AccountTable(id),
    FOREIGN KEY (ContaDestinoId) REFERENCES AccountTable(id),
    FOREIGN KEY (DebitCardDetailsId) REFERENCES DebitCardTable(CartaoId),
    FOREIGN KEY (CreditCardDetailsId) REFERENCES CreditCardTable(CartaoId),
    FOREIGN KEY (PixDetailsId) REFERENCES PIXTable(PIXId),
    FOREIGN KEY (BoletoDetailsId) REFERENCES BoletoTable(BoletoId),
    FOREIGN KEY (LoanDetailsId) REFERENCES LoanTable(EmprestimoId)
);