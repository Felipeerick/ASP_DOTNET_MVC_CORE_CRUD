# Instalando o projeto

```
dotnet new mvc

dotnet add package Microsoft.EntityFrameworkCore

dotnet add package Microsoft.EntityFrameworkCore.tools

Obs: caso, você queira usar o razorPages instale esses pacotes
abaixo:

dotnet add package Microsoft.EntityFrameworkCore.Design

dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design

dotnet tool install --global dotnet-aspnet-codegenerator

dotnet aspnet-codegenerator razorpage -m NomeDaModel -dc ContosoUniversity.Data.SchoolContext -udl -outDir Pages\Students --referenceScriptLibraries -sqlite 
``` 


## Para instalar o banco de dados postgresql

```
dotnet add package Npgsql.EntityFrameworkCore.Postgresql
```


## Para instalar o banco de dados mysql

```
dotnet add package Pomelo.EntityFrameworkCore.MySql
```

## Para instalar o banco de dados SQLite

```
dotnet add package Pomelo.EntityFrameworkCore.SQLite
```

## Como rodar o projeto

```
dotnet run
```

## adicionando migrações

```
Obs: caso ocorra erro dizendo que não possui a ferramenta global use:
dotnet tool install --global dotnet-ef

dotnet ef migrations add initial_migrate

dotnet ef database update 

------------------------------------------------------------------------------------------------------------------------------------------------

Obs: caso esteja trabalhando em um projeto com design pattern e a pasta de entidades fique em uma pasta diferente, use:

dotnet ef migrations add "models do crud" -s ..\NomeDaPasta\ArquivoConfigurado.csproj 

dotnet ef database update -s ..\Matching.WebAPI\Matching.WebAPI.csproj 

```

## Apagando o bd

```
dotnet ef database drop --force
```
