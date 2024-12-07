# Command Query Responsibility Segregation (CQRS)

## **Descrição**
O projeto adota o padrão **CQRS**, que separa as operações de **escrita (Commands)** e **leitura (Queries)**, permitindo otimizações específicas para cada uma.

---

## **Motivos para usar CQRS**
1. **Escalabilidade**:
   - Operações de leitura e escrita podem ser escaladas separadamente.
2. **Simplicidade**:
   - As responsabilidades são claras e independentes.
3. **Performance**:
   - Permite otimizar as consultas de leitura sem impactar as operações de escrita.
4. **Flexibilidade**:
   - Fácil de adaptar a diferentes tecnologias para leitura e escrita.

---

## **Comando Docker para Banco de Dados**
Utilizamos o SQL Server como banco de dados. Execute o seguinte comando para configurá-lo:

```bash
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=Educa123!Senha" \
-p 1433:1433 --name sqlserver \
-d mcr.microsoft.com/mssql/server:2019-latest
```

Script para criar a tabela

Após configurar o banco de dados, execute o script SQL abaixo para criar a tabela Livros:

````
CREATE TABLE Livros (
    Id UNIQUEIDENTIFIER PRIMARY KEY,
    Titulo NVARCHAR(255) NOT NULL,
    Autor NVARCHAR(255) NOT NULL,
    Categoria NVARCHAR(100) NOT NULL,
    Disponivel BIT NOT NULL
);
````

Camadas do Projeto

1. Commands

	•	Gerencia operações de escrita.
	•	Exemplo: CadastrarLivroCommandHandler.cs.

2. Queries

	•	Gerencia operações de leitura.
	•	Exemplo: ConsultarLivroQueryHandler.cs.

3. Domain

	•	Contém as entidades e interfaces de repositórios.
	•	Exemplo: Livro.cs e ILivroRepository.cs.

4. Infrastructure

	•	Implementa os repositórios e gerencia o banco de dados.
	•	Exemplo: LivroRepository.cs.

Como rodar

	1.	Configure o banco de dados usando o comando Docker acima.
	2.	Execute o projeto no terminal:

dotnet run


	3.	Use os endpoints de comandos e consultas:
	•	Comandos: /api/livros/commands.
	•	Consultas: /api/livros/queries.

---
