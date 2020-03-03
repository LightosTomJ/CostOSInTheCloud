CREATE TABLE [dbo].[ExchangeRate] (
    [ExchangeRateId]    UNIQUEIDENTIFIER    NOT NULL,
    [CurrencyId]        SMALLINT            NOT NULL,
    [Date]              DATE                NOT NULL,
    [Rate]              DECIMAL(18,6)       NOT NULL,
    CONSTRAINT [PK_Placeholder] PRIMARY KEY CLUSTERED ([ExchangeRateId] ASC),
    CONSTRAINT [FK_ExchangeRate_Currency] FOREIGN KEY ([CurrencyId]) REFERENCES [Currency]([CurrencyId])
);


