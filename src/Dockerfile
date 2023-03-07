FROM mcr.microsoft.com/dotnet/sdk:6.0 AS base
ENV ASPNETCORE_ENVIRONMENT=Development
ENV ASPNETCORE_URLS=http://+:80;
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Web/src/Web.API/Web.API.csproj", "Web/src/Web.API/"]
COPY ["BuildingBlocks/src/BuildingBlocks.Domain/BuildingBlocks.Domain.csproj", \
      "BuildingBlocks/src/BuildingBlocks.Domain/"]
COPY ["BuildingBlocks/src/BuildingBlocks.Application/BuildingBlocks.Application.csproj",\
      "BuildingBlocks/src/BuildingBlocks.Application/"]
COPY ["BuildingBlocks/src/BuildingBlocks.Infrastructure/BuildingBlocks.Infrastructure.csproj", \
      "BuildingBlocks/src/BuildingBlocks.Infrastructure/"]
COPY ["BuildingBlocks/src/BuildingBlocks.EventBus/BuildingBlocks.EventBus.csproj", \
      "BuildingBlocks/src/BuildingBlocks.EventBus/"] 
COPY ["Modules/UserAccess/src/UserAccess.Domain/UserAccess.Domain.csproj", \
      "Modules/UserAccess/src/UserAccess.Domain/"]
COPY ["Modules/UserAccess/src/UserAccess.Application/UserAccess.Application.csproj", \
      "Modules/UserAccess/src/UserAccess.Application/"]
COPY ["Modules/UserAccess/src/UserAccess.Infrastructure/UserAccess.Infrastructure.csproj", \
      "Modules/UserAccess/src/UserAccess.Infrastructure/"]
COPY ["Modules/UserAccess/src/UserAccess.IntegrationEvents/UserAccess.IntegrationEvents.csproj", \
      "Modules/UserAccess/src/UserAccess.IntegrationEvents/"]
COPY ["Modules/Meetings/src/Meetings.Domain/Meetings.Domain.csproj", \
      "Modules/Meetings/src/Meetings.Domain/"]
COPY ["Modules/Meetings/src/Meetings.Application/Meetings.Application.csproj", \
      "Modules/Meetings/src/Meetings.Application/"]
COPY ["Modules/Meetings/src/Meetings.Infrastructure/Meetings.Infrastructure.csproj", \
      "Modules/Meetings/src/Meetings.Infrastructure/"]
COPY ["Modules/Meetings/src/Meetings.IntegrationEvents/Meetings.IntegrationEvents.csproj", \
      "Modules/Meetings/src/Meetings.IntegrationEvents/"]
COPY ["Modules/Payments/src/Payments.Domain/Payments.Domain.csproj", \
      "Modules/Payments/src/Payments.Domain/"]
COPY ["Modules/Payments/src/Payments.Application/Payments.Application.csproj", \
      "Modules/Payments/src/Payments.Application/"]
COPY ["Modules/Payments/src/Payments.Infrastructure/Payments.Infrastructure.csproj", \
      "Modules/Payments/src/Payments.Infrastructure/"]
COPY ["Modules/Payments/src/Payments.IntegrationEvents/Payments.IntegrationEvents.csproj", \
      "Modules/Payments/src/Payments.IntegrationEvents/"]
COPY ["Modules/Administration/src/Administration.Domain/Administration.Domain.csproj", \
      "Modules/Administration/src/Administration.Domain/"]
COPY ["Modules/Administration/src/Administration.Application/Administration.Application.csproj", \
      "Modules/Administration/src/Administration.Application/"]
COPY ["Modules/Administration/src/Administration.Infrastructure/Administration.Infrastructure.csproj", \ 
      "Modules/Administration/src/Administration.Infrastructure/"]
COPY ["Modules/Administration/src/Administration.IntegrationEvents/Administration.IntegrationEvents.csproj", \
      "Modules/Administration/src/Administration.IntegrationEvents/"]

RUN dotnet restore "Web/src/Web.API/Web.API.csproj"
COPY . .
WORKDIR "/src/Web/src/Web.API/"
RUN dotnet build "Web.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Web.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ADD entrypoint.sh /

ENTRYPOINT ["/bin/bash", "/entrypoint.sh"]