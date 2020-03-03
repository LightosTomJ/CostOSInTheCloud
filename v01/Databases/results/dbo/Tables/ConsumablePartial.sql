CREATE TABLE [dbo].[ConsumablePartial] (
    [Id]           INT            NOT NULL,
    [resultSize]   INT            NULL,
    [partialSize]  INT            NULL,
    [partialStart] INT            NULL,
    [pageSize]     INT            NULL,
    [sortByField]  NVARCHAR (255) NOT NULL,
    [ascending]    BIT            NOT NULL,
    [query]        NVARCHAR (255) NOT NULL,
    [queryType]    NVARCHAR (255) NOT NULL,
    [seconds]      DECIMAL (8, 4) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

