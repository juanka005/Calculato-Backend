# Etapa de compilación
FROM mcr.microsoft.com/dotnet/sdk:10.0-preview AS build-env
WORKDIR /app

# Copiar archivos y restaurar
COPY . ./
RUN dotnet restore

# Publicar la aplicación
RUN dotnet publish -c Release -o out

# Etapa de ejecución
FROM mcr.microsoft.com/dotnet/aspnet:10.0-preview
WORKDIR /app
COPY --from=build-env /app/out .

# Exponer el puerto que usa Render
ENV ASPNETCORE_URLS=http://+:10000
EXPOSE 10000

ENTRYPOINT ["dotnet", "Calculato.Api.dll"]