FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["ObserverPractice/ObserverPractice.csproj", "ObserverPractice/"]
RUN dotnet restore "ObserverPractice/ObserverPractice.csproj"
COPY . .
WORKDIR "/src/ObserverPractice"
RUN dotnet build "ObserverPractice.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ObserverPractice.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ObserverPractice.dll"]
