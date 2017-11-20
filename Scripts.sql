
/*
				Creación de tabla User
*/


CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[Password] [varchar](20) NOT NULL,
	[Roles] [varchar](50) NOT NULL
) ON [PRIMARY]
GO



/*
				Creación de SPs
*/



CREATE PROCEDURE [dbo].[ValidateUser] 
	@email varchar(100),
	@password varchar(20)
AS
BEGIN
	SELECT [Email]
      ,[FirstName]
      ,[LastName]
      ,[Password]
      ,[Roles]
  FROM [dbo].[User]
  WHERE Email=@email AND [Password] = @password
END

GO




CREATE PROCEDURE [dbo].[CustomerPagedList]
@startRow int,
@endRow int
AS
BEGIN
SELECT 
CustomerId
,FirstName
,LastName
,Company
,Address
,City
,State
,Country
,PostalCode
,Phone
,Fax
,Email
,SupportRepId
FROM    ( SELECT    ROW_NUMBER() OVER ( ORDER BY CustomerId ) AS RowNum,
CustomerId
,FirstName
,LastName
,Company
,Address
,City
,State
,Country
,PostalCode
,Phone
,Fax
,Email
,SupportRepId
  FROM     [dbo].[Customer]          
) AS RowConstrainedResult
WHERE   RowNum >= @startRow
AND RowNum <= @endRow
ORDER BY RowNum
END

GO




CREATE PROCEDURE [dbo].[ArtistPagedList]
@startRow int,
@endRow int
AS
BEGIN
SELECT 
ArtistId
,Name
FROM    ( SELECT    ROW_NUMBER() OVER ( ORDER BY ArtistId ) AS RowNum,
ArtistId
,Name
  FROM     [dbo].[Artist]          
) AS RowConstrainedResult
WHERE   RowNum >= @startRow
AND RowNum <= @endRow
ORDER BY RowNum
END

GO



CREATE PROCEDURE [dbo].[EmployeePagedList]
@startRow int,
@endRow int
AS
BEGIN
SELECT 
EmployeeId
,LastName
,FirstName
,Title
,ReportsTo
,BirthDate
,HireDate
,Address
,City
,State
,Country
,PostalCode
,Phone
,Fax
,Email
FROM    ( SELECT    ROW_NUMBER() OVER ( ORDER BY EmployeeId ) AS RowNum,
EmployeeId
,LastName
,FirstName
,Title
,ReportsTo
,BirthDate
,HireDate
,Address
,City
,State
,Country
,PostalCode
,Phone
,Fax
,Email
  FROM     [dbo].[Employee]          
) AS RowConstrainedResult
WHERE   RowNum >= @startRow
AND RowNum <= @endRow
ORDER BY RowNum
END

GO




CREATE PROCEDURE [dbo].[InvoicePagedList]
@startRow int,
@endRow int
AS
BEGIN
SELECT 
InvoiceId
,CustomerId
,InvoiceDate
,BillingAddress
,BillingCity
,BillingState
,BillingCountry
,BillingPostalCode
,Total
FROM    ( SELECT    ROW_NUMBER() OVER ( ORDER BY InvoiceId ) AS RowNum,
InvoiceId
,CustomerId
,InvoiceDate
,BillingAddress
,BillingCity
,BillingState
,BillingCountry
,BillingPostalCode
,Total
  FROM     [dbo].[Invoice]          
) AS RowConstrainedResult
WHERE   RowNum >= @startRow
AND RowNum <= @endRow
ORDER BY RowNum
END

GO





CREATE PROCEDURE [dbo].[InvoiceLinePagedList]
@startRow int,
@endRow int
AS
BEGIN
SELECT 
InvoiceLineId
,InvoiceId
,TrackId
,UnitPrice
,Quantity
FROM    ( SELECT    ROW_NUMBER() OVER ( ORDER BY InvoiceLineId ) AS RowNum,
InvoiceLineId
,InvoiceId
,TrackId
,UnitPrice
,Quantity
  FROM     [dbo].[InvoiceLine]          
) AS RowConstrainedResult
WHERE   RowNum >= @startRow
AND RowNum <= @endRow
ORDER BY RowNum
END

GO


CREATE PROCEDURE [dbo].[MediaTypePagedList]
@startRow int,
@endRow int
AS
BEGIN
SELECT 
MediaTypeId
,Name
FROM    ( SELECT    ROW_NUMBER() OVER ( ORDER BY MediaTypeId ) AS RowNum,
MediaTypeId
,Name
  FROM     [dbo].[MediaType]          
) AS RowConstrainedResult
WHERE   RowNum >= @startRow
AND RowNum <= @endRow
ORDER BY RowNum
END

GO


CREATE PROCEDURE [dbo].[PlaylistPagedList]
@startRow int,
@endRow int
AS
BEGIN
SELECT 
PlaylistId
,Name
FROM    ( SELECT    ROW_NUMBER() OVER ( ORDER BY PlaylistId ) AS RowNum,
PlaylistId
,Name
  FROM     [dbo].[Playlist]          
) AS RowConstrainedResult
WHERE   RowNum >= @startRow
AND RowNum <= @endRow
ORDER BY RowNum
END

GO



CREATE PROCEDURE [dbo].[PlaylistTrackPagedList]
@startRow int,
@endRow int
AS
BEGIN
SELECT 
PlaylistId
,TrackId
FROM    ( SELECT    ROW_NUMBER() OVER ( ORDER BY PlaylistId ) AS RowNum,
PlaylistId
,TrackId
  FROM     [dbo].[PlaylistTrack]          
) AS RowConstrainedResult
WHERE   RowNum >= @startRow
AND RowNum <= @endRow
ORDER BY RowNum
END

GO




CREATE PROCEDURE [dbo].[TrackPagedList]
@startRow int,
@endRow int
AS
BEGIN
SELECT 
TrackId
,Name
,AlbumId
,MediaTypeId
,GenreId
,Composer
,Milliseconds
,Bytes
,UnitPrice
FROM    ( SELECT    ROW_NUMBER() OVER ( ORDER BY TrackId ) AS RowNum,
TrackId
,Name
,AlbumId
,MediaTypeId
,GenreId
,Composer
,Milliseconds
,Bytes
,UnitPrice
  FROM     [dbo].[Track]          
) AS RowConstrainedResult
WHERE   RowNum >= @startRow
AND RowNum <= @endRow
ORDER BY RowNum
END

GO




CREATE PROCEDURE [dbo].[GenrePagedList]
@startRow int,
@endRow int
AS
BEGIN
SELECT 
GenreId
,Name
FROM    ( SELECT    ROW_NUMBER() OVER ( ORDER BY GenreId ) AS RowNum,
GenreId
,Name
  FROM     [dbo].[Genre]          
) AS RowConstrainedResult
WHERE   RowNum >= @startRow
AND RowNum <= @endRow
ORDER BY RowNum
END

GO


CREATE PROCEDURE [dbo].[AlbumPagedList]
@startRow int,
@endRow int
AS
BEGIN
SELECT 
AlbumId
,Title
,ArtistId
FROM    ( SELECT    ROW_NUMBER() OVER ( ORDER BY AlbumId ) AS RowNum,
AlbumId
,Title
,ArtistId
  FROM     [dbo].[Album]          
) AS RowConstrainedResult
WHERE   RowNum >= @startRow
AND RowNum <= @endRow
ORDER BY RowNum
END

GO




/*
				Carga inicial
*/

Insert Into [dbo].[User] Values ('mad@gmail.com','Manuel','Angeles','12345678','1')
Go


