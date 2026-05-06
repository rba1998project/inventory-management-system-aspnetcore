# IMS.ThreeTier

🗄️ Database Setup

This project uses Entity Framework Core (Code-First approach).
The database is not included and will be created locally using migrations.

🔌 Connection String

Configure the connection string using either:

appsettings.json

"ConnectionStrings": {
  "DefaultConnection": "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=IMS_DB;Integrated Security=True;"
}

OR Environment Variable

ConnectionStrings__DefaultConnection
🏗️ Database Initialization

This repository already includes EF Core migration files, so you do NOT need to create new migrations.

Run only:

dotnet ef database update