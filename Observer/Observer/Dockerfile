FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Observer/Observer.csproj", "Observer/"]
RUN dotnet restore "Observer/Observer.csproj"
COPY . .
WORKDIR "/src/Observer"
RUN dotnet build "Observer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Observer.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Observer.dll"]
