# PracticalExerciseBNR

1. Pentru a adauga toate using-urile intr-un fisier global, nu uita sa prefixezi fiecare using din globals.cs cu cuvantul cheie "global"; Se pot scoate celelalte using-uri din fisierele folosite in proiect.

Procesul de scaffolding 
1. se instaleaza EF: dotnet tool install --global dotnet-ef
2. se adauga package-urile: 
 - dotnet add package Microsoft.EntityFrameworkCore.Design
 - dotnet add package Microsoft.EntityFrameworkCore.SqlServer
 - dotnet add package Microsoft.EntityFrameworkCore.Tools
 Comanda pentru crearea modelelor:
 - dotnet ef dbcontext scaffold "Data Source=localhost;Initial Catalog=testscursnetcore;Trusted_Connection=True;TrustServerCertificate=true;MultipleActiveResultSets=true;" Microsoft.EntityFrameworkCore.SqlServer (--force)
 - dotnet new install Microsoft.EntityFrameworkCore.Templates
 - dotnet new ef-templates
 
 
 3. db script: schema and data -> DB_script.sql.bak
 