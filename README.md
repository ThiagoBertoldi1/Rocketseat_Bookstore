## How can you run this project?

### #1 You'll need a database (SQL Server)

You can use Docker for this

```bash
docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=YourStrong@Passw0rd' -p 1433:1433 --name Bookstore_DB -d mcr.microsoft.com/mssql/server:2022-latest
```

### #2 Do you have SSMS? You'll need it too...

When Docker is running, you can log in to SSMS

```
Server name: localhost,1433
Authentication: SQL Server Authentication
Login: sa
Password: YourStrong@Passw0rd

Check "Trust server certificate"
```

Never leave sensitive variables like passwords in public repositories, this is just an example

### #3 Create a new database (Name: Bookstore)

Create a "book" table:

```SQL
USE [Bookstore]
GO

CREATE TABLE [dbo].[Book](
	[Id] [uniqueidentifier] NOT NULL,
	[Title] [varchar](100) NOT NULL,
	[Author] [varchar](255) NOT NULL,
	[Gender] [int] NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[Amount] [int] NOT NULL,
UNIQUE NONCLUSTERED
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
```

### #4 Check your connection string in appSettings.Development.json

The connection string can be changed depending on how you started the Docker container. If you created the container as shown in the example, this is your connection string:

```
Server=localhost,1433;Database=Bookstore;User Id=sa;Password=YourStrong@Passw0rd;TrustServerCertificate=True;
```

### #5 Run the code

You can run it from the command line in the project directory.

```bash
dotnet restore
dotnet run
```

Or you can run it with Visual Studio — just open the `.sln` file.

### #6 Done :D

You are ready to use this API
