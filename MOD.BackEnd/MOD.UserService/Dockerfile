#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM microsoft/dotnet:2.1-aspnetcore-runtime-nanoserver-sac2016 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk-nanoserver-sac2016 AS build
WORKDIR /src
COPY ["MOD.UserService/MOD.UserService.csproj", "MOD.UserService/"]
COPY ["MOD.Logging/MOD.Logging.csproj", "MOD.Logging/"]
COPY ["MOD.Entities/MOD.Entities.csproj", "MOD.Entities/"]
RUN dotnet restore "MOD.UserService/MOD.UserService.csproj"
COPY . .
WORKDIR "/src/MOD.UserService"
RUN dotnet build "MOD.UserService.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "MOD.UserService.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "MOD.UserService.dll"]