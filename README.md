# MotoVision - ASP.NET Core com Oracle e EF Core

Este projeto é uma API RESTful desenvolvida com ASP.NET Core 8.0, Entity Framework Core e banco de dados Oracle, que gerencia o cadastro de Motos, Pátios e relacionamentos entre elas com base em status, cores e setores.

## 🛠 Tecnologias Utilizadas

- ASP.NET Core 8.0
- EF Core com Oracle
- Swagger para documentação
- AutoMapper

## 📦 Entidades

### Moto

| Campo       | Tipo    | Descrição                                       |
|-------------|---------|--------------------------------------------------|
| Id          | int     | Identificador da moto                           |
| Modelo      | string  | Modelo da moto                                  |
| Placa       | string  | Placa da moto                                   |
| Status      | enum    | DISPONIVEL, RESERVADA, INDISPONIVEL, etc.       |
| NomePatio   | string  | Nome do pátio onde está localizada              |
| Setor       | string  | Derivado do status (ex: Setor A para DISPONIVEL)|
| Cor         | string  | Cor derivada do status (ex: Verde para DISPONIVEL)|

### Patio

| Campo | Tipo   | Descrição              |
|-------|--------|-------------------------|
| Id    | int    | Identificador do pátio |
| Nome  | string | Nome do pátio          |

## 🚀 Endpoints

### MotoController

- `GET /api/moto` → Lista todas as motos
- `GET /api/moto/{id}` → Detalhes de uma moto
- `POST /api/moto` → Criação de moto
```json
{
  "modelo": "Honda Biz",
  "placa": "ABC1234",
  "status": "DISPONIVEL",
  "nomePatio": "Pátio Butantã"
}
```
- `PUT /api/moto/{id}` → Atualização
- `DELETE /api/moto/{id}` → Exclusão

### PatioController

- `GET /api/patio`
- `GET /api/patio/{id}`
- `POST /api/patio`
```json
{
  "nome": "Pátio Butantã"
}
```
- `PUT /api/patio/{id}`
- `DELETE /api/patio/{id}`

## 🧠 Lógica do Setor e Cor por Status

| Status             | Setor     | Cor        |
|--------------------|-----------|------------|
| DISPONIVEL         | Setor A   | Verde      |
| RESERVADA          | Setor B   | Azul       |
| MANUTENCAO         | Setor C   | Amarelo    |
| FALTA_PECA         | Setor D   | Laranja    |
| INDISPONIVEL       | Setor E   | Cinza      |
| DANOS_ESTRUTURAIS  | Setor F   | Vermelho   |
| SINISTRO           | Setor G   | Preto      |

## 📂 Como Executar

1. Clonar o repositório
2. Configurar a string de conexão do Oracle no `appsettings.json`
3. Executar as migrations:
```bash
dotnet ef database update
```
4. Iniciar a aplicação no Visual Studio com depuração
5. Acessar o Swagger: `https://localhost:xxxx/swagger`

(Atualmente está configurado com o meu banco de dados e o localhost com a porta 8080)

---


## 👥 INTEGRANTES DO GRUPO
- RM555871 – Eduardo Miguel Forato Monteiro  
- RM556996 – Cícero Gabriel Oliveira Serafim

---

## 📌 OBSERVAÇÕES FINAIS

Este é o projeto para 1 e 2 Sprint do Challenge para a Mottu

---
