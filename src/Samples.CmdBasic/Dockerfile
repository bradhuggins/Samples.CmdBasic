#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/runtime:3.1-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/Samples.CmdBasic/Samples.CmdBasic.csproj", "src/Samples.CmdBasic/"]
RUN dotnet restore "src/Samples.CmdBasic/Samples.CmdBasic.csproj"
COPY . .
WORKDIR "/src/src/Samples.CmdBasic"
RUN dotnet build "Samples.CmdBasic.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Samples.CmdBasic.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Samples.CmdBasic.dll"]