# Etapa 1: build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copia e restaura o projeto correto
COPY . ./
RUN dotnet restore "SonoffControllerProject.csproj"

# Publica o projeto
RUN dotnet publish "SonoffControllerProject.csproj" -c Release -o /app/out

# Etapa 2: runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/out .

# Expõe a porta 80
EXPOSE 80

ENTRYPOINT ["dotnet", "SonoffControllerProject.dll"]
