FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY apiRest/apiRest.csproj apiRest/
COPY Entities/Entities.csproj Entities/
COPY Repository/Repository.csproj Repository/
COPY Contracts/Contracts.csproj Contracts/
RUN dotnet restore apiRest/apiRest.csproj
COPY . .
WORKDIR /src/apiRest
RUN dotnet build apiRest.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish apiRest.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "apiRest.dll"]
