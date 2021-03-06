#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["BookAPI/BookAPI.csproj", "BookAPI/"]
COPY ["BookAPI.BLL/BookAPI.BLL.csproj", "BookAPI.BLL/"]
COPY ["BookAPI.DAL/BookAPI.DAL.csproj", "BookAPI.DAL/"]
COPY ["BookAPI.Infrastructure/BookAPI.Infrastructure.csproj", "BookAPI.Infrastructure/"]
RUN dotnet restore "BookAPI/BookAPI.csproj"
COPY . .
WORKDIR "/src/BookAPI"
RUN dotnet build "BookAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BookAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BookAPI.dll"]