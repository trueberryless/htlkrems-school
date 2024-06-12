FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Azure Storage Account Access/Azure Storage Account Access.csproj", "Azure Storage Account Access/"]
RUN dotnet restore "Azure Storage Account Access/Azure Storage Account Access.csproj"
COPY . .
WORKDIR "/src/Azure Storage Account Access"
RUN dotnet build "Azure Storage Account Access.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Azure Storage Account Access.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Azure Storage Account Access.dll"]
