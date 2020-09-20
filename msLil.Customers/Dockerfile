FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["msLil.Customers/msLil.Customers.csproj", "msLil.Customers/"]
RUN dotnet restore "msLil.Customers/msLil.Customers.csproj"
COPY . .
WORKDIR "/src/msLil.Customers"
RUN dotnet build "msLil.Customers.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "msLil.Customers.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "msLil.Customers.dll"]
