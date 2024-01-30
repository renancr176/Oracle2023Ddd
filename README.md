# Oracle2023Ddd

Instalações necessárias:

 - Base de dados Oracle 11g R2 XE 
	 - [Download](https://www.oracle.com/database/technologies/xe-prior-release-downloads.html)
 - Visual Studio 
	 - [Download](https://visualstudio.microsoft.com/pt-br/downloads/)
 - DotNet SDK 7
	 - [Download](https://dotnet.microsoft.com/en-us/download/dotnet/7.0)

## Configurações
	
 1. Criar base de dados / schema TMS.

	 - Instalar o Oracle com a senha "admin"
	 - Conectar na base de dados
		 - [Download do DBeaver](https://dbeaver.io/download/)
		 - Connection Type: Basic
		 - Host : 127.0.0.1
		 - Port: 1521
		 - Service Name: XE
		 - SID
		 - User Name: SYSTEM
		 - Password: admin
	 - Executar os comando SQL a baixo para criar o schema TMS
		 - `CREATE USER TMS IDENTIFIED BY admin;`
		 - `GRANT ALL PRIVILEGES TO TMS;`

2. Criar base de dados / schema TMS de TESTE.

	 - Instalar o Oracle com a senha "admin"
	 - Conectar na base de dados
		 - [Download do DBeaver](https://dbeaver.io/download/)
		 - Connection Type: Basic
		 - Host : 127.0.0.1
		 - Port: 1521
		 - Service Name: XE
		 - SID
		 - User Name: SYSTEM
		 - Password: admin
	 - Executar os comando SQL a baixo para criar o schema TMS
		 - `CREATE USER TMSTEST IDENTIFIED BY admin;`
		 - `GRANT ALL PRIVILEGES TO TMSTEST;`

3. Configurar a conexão do projeto com o banco de dados local para desenvolvimento e tete automatizado.

	- No projeto Oracle2023Ddd.Services.Api
		- Alterar o arquivo appsettings.Development.json
			- Alterar a connection string TMS para:
				- "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=127.0.0.1)(PORT=1521))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=EX)));User Id=TMS;Password=admin;Validate Connection=true;Max Pool Size=200"
		- Alterar o arquivo appsettings.Testing.json
			- Alterar a connection string TMS para:
				- "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=127.0.0.1)(PORT=1521))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=EX)));User Id=TMSTEST;Password=admin;Validate Connection=true;Max Pool Size=200"