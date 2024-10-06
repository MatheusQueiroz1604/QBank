CREATE TABLE UserTable
( 
    ID INT PRIMARY KEY, 
    NAME VARCHAR(300) NOT NULL, 
    CPF VARCHAR(14) NOT NULL,
    EMAIL VARCHAR(250) NOT NULL,
    SENHA VARCHAR(250) NOT NULL,
    DATA_NASCIMENTO DATE NOT NULL,
    TELEFONE VARCHAR(20)
);

CREATE TABLE AccountTable
(
    id INT PRIMARY KEY,
    Saldo DECIMAL(10, 2) NULL,
    NumeroConta VARCHAR(50) NOT NULL,
    TipoConta VARCHAR(50) NOT NULL,
    DataAbertura DATETIME NOT NULL,
    ClienteId INT NOT NULL,
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
    FOREIGN KEY (ContaOrigemId) REFERENCES AccountTable(id),
    FOREIGN KEY (ContaDestinoId) REFERENCES AccountTable(id)
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

CREATE TABLE BorrowingTable
(
    EmprestimoId INT PRIMARY KEY,
    ClienteId INT NOT NULL,
    Valor DECIMAL(10, 2) NOT NULL,
    DataSolicitacao DATETIME NOT NULL,
    Prazo DATETIME NOT NULL,
    Juros INT NULL,
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