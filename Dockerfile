# Etapa 1: build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copia o arquivo .csproj e restaura dependências
COPY SonoffControllerProject.csproj ./
RUN dotnet restore

# Copia todos os arquivos do projeto
COPY . ./

# Publica a aplicação
RUN dotnet publish -c Release -o /app/out

# Etapa 2: runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/out .

# Expõe a porta 80
EXPOSE 80

# Comando de entrada
ENTRYPOINT ["dotnet", "SonoffControllerProject.dll"]