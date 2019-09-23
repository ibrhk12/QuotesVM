FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["QuotesVM/QuotesVM.csproj", "QuotesVM/"]
COPY ["BusinessLayer/BusinessLayer.csproj", "BusinessLayer/"]
COPY ["DataAccessLayer/DataAccessLayer.csproj", "DataAccessLayer/"]
RUN dotnet restore "QuotesVM/QuotesVM.csproj"
COPY . .
WORKDIR "/src/QuotesVM"
RUN dotnet build "QuotesVM.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "QuotesVM.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "QuotesVM.dll"]