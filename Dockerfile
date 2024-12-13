FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["AspNet2HW/AspNet2HW.csproj", "AspNet2HW/"]
RUN dotnet restore "AspNet2HW/AspNet2HW.csproj"
COPY . .
WORKDIR "/src/AspNet2HW"
RUN dotnet build "AspNet2HW.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AspNet2HW.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AspNet2HW.dll"]
