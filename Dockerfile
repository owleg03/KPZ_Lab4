FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["WepAPI/WepAPI.csproj", "WepAPI/"]
RUN dotnet restore "WepAPI/WepAPI.csproj"
COPY . .
WORKDIR "/src/WepAPI"
RUN dotnet build "WepAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WepAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WepAPI.dll"]
