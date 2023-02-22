/****** 1. Read all the customers in the database, this should display their: Id, first name, last name, country, postal code,
phone number and email.
******/
SELECT TOP (1000) [CustomerId]
      ,[FirstName]
      ,[LastName]
      ,[Country]
      ,[PostalCode]
      ,[Phone]
      ,[Email]
  FROM [Chinook].[dbo].[Customer]

  /****** 
  2. Read a specific customer from the database (by Id), should display everything listed in the above point.

  ******/

  SELECT [CustomerId]
      ,[FirstName]
      ,[LastName]
      ,[Country]
      ,[PostalCode]
      ,[Phone]
      ,[Email]
  FROM [Chinook].[dbo].[Customer]
  where [CustomerId] = 5

   /****** 
3. Read a specific customer by name. HINT: LIKE keyword can help for partial matches.

  ******/

  SELECT [CustomerId]
      ,[FirstName]
      ,[LastName]
      ,[Country]
      ,[PostalCode]
      ,[Phone]
      ,[Email]
  FROM [Chinook].[dbo].[Customer]
  where [FirstName] LIKE 'j%' 

  SELECT [CustomerId]
      ,[FirstName]
      ,[LastName]
      ,[Country]
      ,[PostalCode]
      ,[Phone]
      ,[Email]
  FROM [Chinook].[dbo].[Customer]
  where [LastName] LIKE 'Bree%'

    /****** 
4. Return a page of customers from the database. This should take in limit and offset as parameters and make use
of the SQL limit and offset keywords to get a subset of the customer data. The customer model from above
should be reused.

  ******/

  SELECT [CustomerId]
      ,[FirstName]
      ,[LastName]
      ,[Country]
      ,[PostalCode]
      ,[Phone]
      ,[Email]
  FROM [Chinook].[dbo].[Customer]
  Order by [CustomerId]
  OFFSET 2 ROWS FETCH FIRST 3 ROWS ONLY
  /****** 
  5. Add a new customer to the database. You also need to add only the fields listed above (our customer object) 
  ******/
  USE [Chinook]
  INSERT INTO [Customer] 
  (    [FirstName]
      ,[LastName]
      ,[Country]
      ,[PostalCode]
      ,[Phone]
      ,[Email]) 
  VALUES('Shoo', 'Bree', 'Germany', '14700','+49 2 4172 5555','Shoo@bre.com')
    /******
  6. Update an existing customer.
  ******/
   USE [Chinook]
	UPDATE [Customer] 
  SET [FirstName] = 'jo'
      ,[LastName] = 'man'
      ,[Country] = 'Sweden'
      ,[PostalCode] = '163 74'
      ,[Phone] = '+46 76 598 32 68'
      ,[Email] = 'jo@man.com'
	WHERE [CustomerId] = 61
      /******
  7. Return the number of customers in each country, ordered descending (high to low). i.e. USA: 13, … 
  ******/
  USE [Chinook]
  SELECT [Country],COUNT([CustomerId]) AS [NumberOfCustomers]
  FROM [Customer] 
  GROUP BY [Country]
  Order by [NumberOfCustomers] DESC

      /******
8. Customers who are the highest spenders (total in invoice table is the largest), ordered descending.
  ******/
  USE [Chinook]
  SELECT [Customer].[CustomerId],[FirstName],[LastName], SUM([Total]) AS [TotelSpending]
  FROM [Customer]
  INNER JOIN [Invoice]
  ON [Customer].[CustomerId] = [Invoice].[CustomerId]
  GROUP BY [Customer].[CustomerId],[FirstName],[LastName]
  Order by [TotelSpending] DESC

      /******
  9. For a given customer, their most popular genre (in the case of a tie, display both). Most popular in this context 
means the genre that corresponds to the most tracks from invoices associated to that customer.
  ******/

  USE [Chinook]
  SELECT [Customer].[CustomerId],[FirstName],[LastName],[Genre].[NAME], COUNT([Genre].[NAME]) AS [GenreNumber]
  FROM [Customer]
  INNER JOIN [Invoice]
  ON [Customer].[CustomerId] = [Invoice].[CustomerId]
  INNER JOIN [InvoiceLine]
  ON [Invoice].[InvoiceId] = [InvoiceLine].[InvoiceId]
   INNER JOIN [Track]
  ON [InvoiceLine].[TrackId] = [Track].[TrackId]

  INNER JOIN [Genre]
  ON [Track].[GenreId] = [Genre].[GenreId]

  GROUP BY [Customer].[CustomerId],[FirstName],[LastName],[Genre].[NAME]
  Order by [Customer].[CustomerId],[GenreNumber] DESC


  /******   ******/

  USE [Chinook]
  SELECT [Genre].[NAME], COUNT([Genre].[NAME]) AS [GenreNumber]
  FROM [Customer]
  INNER JOIN [Invoice]
  ON [Customer].[CustomerId] = [Invoice].[CustomerId]
  INNER JOIN [InvoiceLine]
  ON [Invoice].[InvoiceId] = [InvoiceLine].[InvoiceId]
   INNER JOIN [Track]
  ON [InvoiceLine].[TrackId] = [Track].[TrackId]

  INNER JOIN [Genre]
  ON [Track].[GenreId] = [Genre].[GenreId]
  WHERE [Customer].[CustomerId] = 10
  GROUP BY [Genre].[NAME]
  Order by [GenreNumber] DESC


  SELECT TOP (1) [CustomerId]
      ,[FirstName]
      ,[LastName]
  FROM [Chinook].[dbo].[Customer]

    SELECT TOP (1) [InvoiceId]
      ,[CustomerId]
  FROM [Chinook].[dbo].[Invoice]

  SELECT TOP (1) [InvoiceLineId]
      ,[InvoiceId]
      ,[TrackId]
  FROM [Chinook].[dbo].[InvoiceLine]

  SELECT TOP (1) [TrackId]
      ,[GenreId]
  FROM [Chinook].[dbo].[Track]

  SELECT TOP (1) [GenreId]
      ,[Name]
  FROM [Chinook].[dbo].[Genre]