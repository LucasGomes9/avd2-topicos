#!/bin/bash
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=M1yPa4ss!123" -p 1433:1433 --name sqlserver -d mcr.microsoft.com/mssql/server:2019-CU14-ubuntu-20.04