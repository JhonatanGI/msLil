FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["msLil.Search/msLil.Search.csproj", "msLil.Search/"]
RUN dotnet restore "msLil.Search/msLil.Search.csproj"
COPY . .
WORKDIR "/src/msLil.Search"
RUN dotnet build "msLil.Search.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "msLil.Search.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "msLil.Search.dll"]
