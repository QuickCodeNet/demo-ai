FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG PIPELINE_ID=1 

WORKDIR /src
COPY . .

WORKDIR "/src/src/Modules/ShippingModule/Presentation/QuickCode.DemoAi.ShippingModule.Api"

RUN dotnet restore "QuickCode.DemoAi.ShippingModule.Api.csproj"

FROM build AS publish
RUN dotnet publish "QuickCode.DemoAi.ShippingModule.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false /p:AssemblyVersion=1.0.0.${PIPELINE_ID} /p:GenerateCode=NO 

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "QuickCode.DemoAi.ShippingModule.Api.dll"]

