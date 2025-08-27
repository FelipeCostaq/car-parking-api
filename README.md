# Car Parking API
API para gerenciamento de vagas e carros em um estacionamento condominial. Desenvolvida em C# com ASP.NET Core e Entity Framework.

## Tecnologias Utilizadas
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- Swagger (OpenAPI)

### Pré-requisitos
- [.NET SDK 8.0+](https://dotnet.microsoft.com/download)
- [SQL Server](https://www.microsoft.com/pt-br/sql-server/)
- [Git](https://git-scm.com/)

### Passos para rodar localmente
1. Clone o repositório:
   ```bash
   git clone https://github.com/usuario/car-parking-api.git
   cd car-parking-api

2. Restaure as depêndencias.
   ```bash
   dotnet restore

3. Crie o banco de dados e rode as migrations.
   ```bash
   dotnet ef database update

4. Execute a aplicação
   ```bash
   dotnet run

# Endpoints

## Car

<ul>
   <li>GET /api/Car/all – Lista todos os carros.</li>
   <li>GET /api/Car/{id} – Retorna um carro pelo ID.</li>
   <li>GET /api/Car/plate – Retorna um carro pela placa.</li>
   <li>GET /api/Car/model – Retorna um carro pelo modelo.</li>
   <li>GET /api/Car/owner – Retorna um carro pelo proprietário.</li>
   <li>GET /api/Car/apartment – Retorna um carro pelo apartamento.</li>
   <li>POST /api/Car – Adiciona um carro.</li>
   <li>PUT /api/Car/{id} – Atualiza um carro.</li>
   <li>DELETE /api/Car/{id} – Remove um carro.</li>
</ul>

## ParkingSpot

<ul>
   <li>GET /api/ParkingSpot/all – Lista todos as vagas.</li>
   <li>GET /api/ParkingSpot/number – Retorna uma vaga pelo número.</li>
   <li>GET /api/ParkingSpot/type – Retorna uma vaga pelo tipo.</li>
   <li>GET /api/ParkingSpot/status – Retorna uma vaga pelo status.</li>
   <li>GET /api/ParkingSpot/{id} – Retorna uma vaga pelo id.</li>
   <li>POST /api/ParkingSpot – Adiciona uma vaga.</li>
   <li>PUT /api/ParkingSpot/{id} – Atualiza uma vaga.</li>
   <li>DELETE /api/ParkingSpot/{id} – Remove uma vaga.</li>
</ul>

## ParkingAssignment

<ul>
   <li>GET /api/ParkingAssignment/all – Lista todos as atribuições.</li>
   <li>GET /api/ParkingAssignment/spotId – Retorna uma atribuição pelo id da vaga.</li>
   <li>GET /api/ParkingAssignment/carId – Retorna uma atribuição pelo id do carro.</li>
   <li>GET /api/ParkingAssignment/{id} – Retorna uma vaga pelo id.</li>
   <li>POST /api/ParkingAssignment – Adiciona uma atribuição.</li>
   <li>PUT /api/ParkingAssignment/{id} – Atualiza uma atribuição.</li>
   <li>DELETE /api/ParkingAssignment/{id} – Remove uma atribuição.</li>
</ul>
