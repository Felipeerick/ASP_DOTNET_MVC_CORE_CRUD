# Instalando o projeto

```
dotnet new mvc

dotnet add package Microsoft.EntityFrameworkCore

dotnet add package Microsoft.EntityFrameworkCore.tools

Obs: caso, voc� queira usar o razorPages instale esses pacotes
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

## adicionando migra��es

```
Obs: caso ocorra erro dizendo que n�o possui a ferramenta global use:
dotnet tool install --global dotnet-e

dotnet ef migrations add initial_migrate

dotnet ef database update 

```

## Apagando o bd

```
dotnet ef database drop --force
```