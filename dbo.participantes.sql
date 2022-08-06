CREATE TABLE [dbo].[participantes] (
    [id]        INT           IDENTITY (1, 1) NULL,
    [nombre]    VARCHAR (50)  NULL,
    [apellidos] VARCHAR (100) NULL,
    [email]     VARCHAR (50)  NULL,
    [telefono]  INT           NULL,
    [fecha]     INT           NULL,
    [altura]    INT           NULL,
    [peso]      INT           NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    UNIQUE NONCLUSTERED ([email] ASC)
);

