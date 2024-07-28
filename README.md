# Using Entity Framework Core Database First

1. Install Visual Studio Code
   https://code.visualstudio.com/Download

   - C# Dev kit (extensions)
     https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csdevkit

2. Install .NET
   https://dotnet.microsoft.com/en-us/download

3. Create a First Project to Visual Studio Code
   CTRL + SHIFT + P --> .NET: New Project... --> MVC --> เลือก Folder ที่เก็บ Project --> ตั้งชื่อ ProjectName

# Nuget

https://www.nuget.org/
https://marketplace.visualstudio.com/items?itemName=patcx.vscode-nuget-gallery

- Microsoft.EntityFrameworkCore.SqlServer
- Microsoft.EntityFrameworkCore.Tools
- Microsoft.VisualStudio.Web.CodeGeneration.Design

Or install with Command Prompt

```bash
cd UsingEFCoreDatabaseFirst
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Tools
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
```

Updated to `UsingEFCoreDatabaseFirst.csproj`

# แปลงฐานข้อมูล SQL Server เป็น class

```bash
dotnet ef dbcontext scaffold "Server=.\SQLExpress;Database=Northwind;Trusted_Connection=True;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer --context-dir Data --output-dir Models/db
```

Server=.\SQLExpress หมายถึง ต้องการติดต่อกับฐานข้อมูลที่ชื่อว่า SQLExpress (ค่าเริ่มต้นที่มากับตัวติดตั้งฐานข้อมูล SQL Server)
Database=Northwind หมายถึง ต้องการใช้งานกับฐานข้อมูลที่ชื่อว่า Northwind
--context-dir Data หมายถึง พาธที่เก็บไฟล์ DBContext ของฐานข้อมูล
--output-dir Models/db หมายถึง พาธที่ใช้จัดเก็บคลาสที่ได้มาจากฐานข้อมูล

# Set up

JSON file to `appsettings.json`

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=./SQLExpress;Database=Northwind;Trusted_Connection=True;TrustServerCertificate=True;ConnectRetryCount=0"
  }
}
```

Add DB Context to`Program.cs`

```cs
using Microsoft.EntityFrameworkCore;
using UsingEFCoreDatabaseFirst.Data;

// Connect Database
builder.Services.AddDbContext<NorthwindContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
```
