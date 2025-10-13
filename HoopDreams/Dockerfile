FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
# Render terminates TLS and forwards HTTP to your container, so 443 isn't required.
EXPOSE 80

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
COPY --from=publish /app/publish ./
ENV ASPNETCORE_URLS=http://0.0.0.0:${PORT}
ENTRYPOINT ["dotnet", "HoopDreams.dll"]
