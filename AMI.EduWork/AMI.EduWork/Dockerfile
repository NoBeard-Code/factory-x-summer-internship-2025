# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["AMI.EduWork/AMI.EduWork/AMI.EduWork.csproj", "AMI.EduWork/"]
COPY ["AMI.EduWork/AMI.EduWork.Client/AMI.EduWork.Client.csproj", "AMI.EduWork.Client/"]
COPY ["AMI.EduWork/AMI.EduWork.Data/AMI.EduWork.Data.csproj", "AMI.EduWork.Data/"]
COPY ["AMI.EduWork/AMI.EduWork.Domain/AMI.EduWork.Domain.csproj", "AMI.EduWork.Domain/"]
RUN dotnet restore "./AMI.EduWork/AMI.EduWork.csproj"
COPY . .
WORKDIR "/src/AMI.EduWork"
RUN dotnet build "AMI.EduWork/AMI.EduWork.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "AMI.EduWork/AMI.EduWork.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AMI.EduWork.dll"]