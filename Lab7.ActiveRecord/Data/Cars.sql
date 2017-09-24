CREATE TABLE [dbo].[Cars] (
    [Id]       INT          NOT NULL IDENTITY,
    [Firm]     VARCHAR (50) NULL,
    [Make]     VARCHAR (50) NULL,
    [Year]     INT          NULL,
    [Price]    INT          NULL,
    [MaxSpeed] INT          NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


SET IDENTITY_INSERT [dbo].[Cars] ON
INSERT INTO [dbo].[Cars] ([Id], [Firm], [Make], [Year], [Price], [MaxSpeed]) VALUES (1, N'BMW', N'X5', 2014, 70000, 180)
INSERT INTO [dbo].[Cars] ([Id], [Firm], [Make], [Year], [Price], [MaxSpeed]) VALUES (2, N'Audi', N'TT', 2012, 90000, 190)
INSERT INTO [dbo].[Cars] ([Id], [Firm], [Make], [Year], [Price], [MaxSpeed]) VALUES (3, N'Volkswagen', N'Tiguan', 2013, 80000, 170)
INSERT INTO [dbo].[Cars] ([Id], [Firm], [Make], [Year], [Price], [MaxSpeed]) VALUES (4, N'Renault', N'Logan', 2015, 10000, 160)
INSERT INTO [dbo].[Cars] ([Id], [Firm], [Make], [Year], [Price], [MaxSpeed]) VALUES (5, N'Lada', N'Vesta', 2017, 11000, 150)
SET IDENTITY_INSERT [dbo].[Cars] OFF
