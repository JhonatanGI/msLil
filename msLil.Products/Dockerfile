FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["msLil.Products/msLil.Products.csproj", "msLil.Products/"]
RUN dotnet restore "msLil.Products/msLil.Products.csproj"
COPY . .
WORKDIR "/src/msLil.Products"
RUN dotnet build "msLil.Products.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "msLil.Products.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "msLil.Products.dll"]
