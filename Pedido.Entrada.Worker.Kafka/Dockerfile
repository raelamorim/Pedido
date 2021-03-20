#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/runtime:3.1-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Pedido.Entrada.Worker.Kafka/Pedido.Entrada.Worker.Kafka.csproj", "Pedido.Entrada.Worker.Kafka/"]
RUN dotnet restore "Pedido.Entrada.Worker.Kafka/Pedido.Entrada.Worker.Kafka.csproj"
COPY . .
WORKDIR "/src/Pedido.Entrada.Worker.Kafka"
RUN dotnet build "Pedido.Entrada.Worker.Kafka.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Pedido.Entrada.Worker.Kafka.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Pedido.Entrada.Worker.Kafka.dll"]