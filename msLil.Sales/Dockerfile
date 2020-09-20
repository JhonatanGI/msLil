FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["msLil.Sales/msLil.Sales.csproj", "msLil.Sales/"]
RUN dotnet restore "msLil.Sales/msLil.Sales.csproj"
COPY . .
WORKDIR "/src/msLil.Sales"
RUN dotnet build "msLil.Sales.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "msLil.Sales.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "msLil.Sales.dll"]
