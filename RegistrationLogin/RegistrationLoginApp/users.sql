/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [UserID]
      ,[Username]
      ,[Password]
  FROM [UserRegistration].[dbo].[users]