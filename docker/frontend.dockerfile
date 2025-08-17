FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
COPY ./Frontend /home/app
WORKDIR /home/app
RUN dotnet restore Frontend.csproj && dotnet publish -c release -o /build --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
ENV ASPNETCORE_URLS=http://+:5000
WORKDIR /home/app
COPY --from=build /build .
EXPOSE 5000
ENTRYPOINT ["dotnet", "Frontend.dll"]