#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ProductWeb/ProductWeb.csproj", "ProductWeb/"]
RUN dotnet restore "ProductWeb/ProductWeb.csproj"
COPY . .
WORKDIR "/src/ProductWeb"
RUN dotnet build "ProductWeb.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ProductWeb.csproj" -c Release -o /app/publish

FROM base AS final
ENV ASPNETCORE_ENVIRONMENT=Development
ENV ASPNETCORE_URLS=http://*:8000
EXPOSE 8000
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ProductWeb.dll"]