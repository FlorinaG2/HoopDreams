FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["HoopDreams/HoopDreams.csproj", "HoopDreams/"]
RUN dotnet restore "HoopDreams/HoopDreams.csproj"
COPY . .
WORKDIR "/src/HoopDreams"
RUN dotnet build "HoopDreams.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HoopDreams.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HoopDreams.dll"]