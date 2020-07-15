# DropDownWithSearch
Step by step process for implement this project. 

Step-1 Create the database.

Step-2 Install packages :
        Microsoft.EntityFrameworkCore
        Microsoft.EntityFrameworkCore.sqlserver
        Microsoft.EntityFrameworkCore.tools
        
Step-3 Add connection string in appsetting.json file :  

      "ConnectionStrings": {
               "TestDb": "connection string for your database"
       }, 
        
Step-4 For Create DbContext class used below command : 
       Scaffold-DbContext -Connection Name=Test Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models

Step-5 In Startup.cs file add service for AddDbContext used in our project :

       services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("TestDb")));

Step- 6 Used object of DbContext as per our requirement.
