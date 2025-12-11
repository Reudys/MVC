# ---- Build ----
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia solo los archivos necesarios para restore (mejora caché)
COPY ["TuProyecto.csproj", "./"]
RUN dotnet restore "TuProyecto.csproj"

# Copia todo y compila
COPY . .
RUN dotnet publish "TuProyecto.csproj" -c Release -o /app/publish --no-restore

# ---- Runtime ----
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

# Puerto que Render espera
ENV ASPNETCORE_URLS=http://0.0.0.0:8080
EXPOSE 8080

ENTRYPOINT ["dotnet", "TuProyecto.dll"]