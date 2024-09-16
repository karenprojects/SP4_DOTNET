# EASY TECH

Este repositório contém uma API desenvolvida em ASP.NET Core como parte de um projeto para gerenciamento de **HEALTH TECH** do grupo **EASY TECH**.

## Integrantes

- MATHEUS MATOS - RM:99792
- KAREN VITORIA JESUS DA SILVA - RM:99468
- JULIANNY ARAUJO PEREIRA - RM:99554
- DIEGO HENRIQUE SANTOS DE OLIVEIRA - RM:550269
- JULIA DE FATIMA QUEIROZ - RM:551130

## Arquitetura

A API foi desenvolvida utilizando uma arquitetura **monolítica**, centralizando toda a lógica de negócios e comunicação com o banco de dados Oracle em um único projeto. Essa escolha simplifica a gestão e a implantação, considerando o porte médio do projeto. No entanto, já está planejada a futura migração para uma arquitetura de **microsserviços**.


## Tecnologias Utilizadas

- **.NET 8.0**
- **Entity Framework Core com Oracle**
- **Swagger** para documentação da API

## Endpoints

### Pacientes
- `GET /pacientes`: Retorna todos os pacientes cadastrados
- `GET /pacientes/{cpf}`: Retorna um paciente específico
- `POST /pacientes`: Adiciona um novo paciente
- `PUT /pacientes/{cpf}/atualizarSenha`: Atualiza a senha de um paciente
- `DELETE /pacientes/{cpf}`: Deleta um paciente

### Unidades
- `GET /unidades`: Retorna todas as unidades
- `GET /unidades/{id_unidade}`: Retorna uma unidade específica
- `POST /unidades`: Adiciona uma nova unidade
- `PUT /unidades/{id_unidade}`: Atualiza o tipo de exame de uma unidade
- `DELETE /unidades/{id_unidade}`: Deleta uma unidade

### Agendamentos
- `GET /agendamentos`: Retorna todos os agendamentos
- `GET /agendamentos/{n_protocolo}`: Retorna um agendamento específico
- `POST /agendamentos`: Adiciona um novo agendamento
- `PUT /agendamentos/{n_protocolo}`: Atualiza a data e hora de um agendamento
- `DELETE /agendamentos/{n_protocolo}`: Deleta um agendamento

## Como Rodar o Projeto

1. Clone o repositório
2. Abra o projeto no Visual Studio/Rider
3. Configure a string de conexão com o banco de dados Oracle no arquivo `appsettings.json`
4. Execute o projeto em modo http ou https
5. Acesse a documentação da API em `http://localhost:5004/swagger/index.html`
