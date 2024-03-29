#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Services/ShoppingCart/ShoppingCart.API/ShoppingCart.API.csproj", "Services/ShoppingCart/ShoppingCart.API/"]
COPY ["Services/ShoppingCart/ShoppingCart.Infrastructure/ShoppingCart.Infrastructure.csproj", "Services/ShoppingCart/ShoppingCart.Infrastructure/"]
COPY ["Services/ShoppingCart/ShoppingCart.Application/ShoppingCart.Application.csproj", "Services/ShoppingCart/ShoppingCart.Application/"]
COPY ["CommonBlocks/ServiceBus/ServiceBus.csproj", "CommonBlocks/ServiceBus/"]
COPY ["Services/ShoppingCart/ShoppingCart.Domain/ShoppingCart.Domain.csproj", "Services/ShoppingCart/ShoppingCart.Domain/"]
RUN dotnet restore "Services/ShoppingCart/ShoppingCart.API/ShoppingCart.API.csproj"
COPY . .
WORKDIR "/src/Services/ShoppingCart/ShoppingCart.API"
RUN dotnet build "ShoppingCart.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ShoppingCart.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ShoppingCart.API.dll"]