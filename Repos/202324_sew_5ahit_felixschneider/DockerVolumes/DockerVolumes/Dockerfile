FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["DockerVolumes/DockerVolumes.csproj", "DockerVolumes/"]
RUN dotnet restore "DockerVolumes/DockerVolumes.csproj"
COPY . .
WORKDIR "/src/DockerVolumes"
RUN dotnet build "DockerVolumes.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DockerVolumes.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
VOLUME ["/app/persistent"]
ENTRYPOINT ["dotnet", "DockerVolumes.dll"]
