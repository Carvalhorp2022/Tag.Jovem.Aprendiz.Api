FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Tag.Jovem.Aprendiz.Api.csproj", "./"]
RUN dotnet restore "Tag.Jovem.Aprendiz.Api.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "Tag.Jovem.Aprendiz.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Tag.Jovem.Aprendiz.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Tag.Jovem.Aprendiz.Api.dll"]
