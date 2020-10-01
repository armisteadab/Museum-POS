CREATE TABLE [dbo].[CASH] (
    [Id]       INT        NOT NULL,
    [CashDate] NCHAR (10) NULL,
    [CashIn]   MONEY      NULL,
    [CashOut]  MONEY      NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);