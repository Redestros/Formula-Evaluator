FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Formula Evaluator/Formula Evaluator.csproj", "Formula Evaluator/"]
RUN dotnet restore "Formula Evaluator/Formula Evaluator.csproj"
COPY . .
WORKDIR "/src/Formula Evaluator"
RUN dotnet build "Formula Evaluator.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Formula Evaluator.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Formula Evaluator.dll"]
