FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["lab4/lab4.csproj", "lab4/"]
RUN dotnet restore "lab4/lab4.csproj"
COPY . .
WORKDIR "/src/lab4"
RUN dotnet build "lab4.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "lab4.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "lab4.dll"]
