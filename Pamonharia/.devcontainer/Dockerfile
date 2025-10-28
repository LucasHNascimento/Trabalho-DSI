# .devcontainer/Dockerfile
FROM mcr.microsoft.com/devcontainers/dotnet:8.0

# Instala as ferramentas de linha de comando do EF Core
RUN dotnet tool install --global dotnet-ef
ENV PATH="$PATH:/root/.dotnet/tools"