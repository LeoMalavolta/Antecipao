Migrations:

Add-Migration InitialCreate -Project Antecipacao.Infrastructure -StartupProject Antecipacao.Api -OutputDir Data/Migrations

Update-Database -Project Antecipacao.Infrastructure -StartupProject Antecipacao.Api

Remove-Migration -Project Antecipacao.Infrastructure -StartupProject Antecipacao.Api

---------------------------------------------------------------------------------------------------------------------------------

SQL Server:

docker pull mcr.microsoft.com/mssql/server:2022-latest

docker image ls

docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=!Admin123" -p 1433:1433 --name antecipacao-sqlserver --hostname antecipacao-sqlserver -v sql_data:/var/opt/mssql -d mcr.microsoft.com/mssql/server:2022-latest 

docker container ls