# Catálogo Cultural API

Esta é uma API em .NET para o gerenciamento de eventos culturais.

## Estrutura do Projeto

O projeto é estruturado em pastas como `Controllers`, `Data`, `Models` e `ViewModels` dentro do diretório `src/code`.

## Tecnologias
- .NET 8.0
- Entity Framework Core (provavelmente, dado o `AppDbContext.cs`)

## Como Executar

Para rodar a API localmente:

1. Certifique-se de ter o SDK do .NET 8 instalado.
2. Execute o comando de restauração dos pacotes (opcional, pois o `run` faz isso):
   ```bash
   dotnet restore
   ```
3. Execute a aplicação:
   ```bash
   dotnet run
   ```

A API deve iniciar e escutar na porta configurada (verifique `Properties/launchSettings.json`).
