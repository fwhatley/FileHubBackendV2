# multi stage - https://app.pluralsight.com/player?course=docker-images-containers-aspdotnet-core&author=wes-mcclure&name=docker-images-containers-aspdotnet-core-m6&clip=4&mode=live
# INSTRUCTIONS TO BUILD
# build with: docker build -t fredywhatley/filehubbackendv2:1.0.1 .
# run with: 


# 1. BUILD IMAGE STAGE
FROM microsoft/dotnet:latest as build-image-stage
WORKDIR /FileHubBackendV2

# separate  dotnet restore to cache and improve build speed
COPY FileHubBackendV2.csproj .
RUN dotnet restore

COPY . .
RUN dotnet publish -o /publish


# 2. RUNTIME IMAGE STATE
FROM mcr.microsoft.com/dotnet/core/aspnet:2.1
WORKDIR /publish

# take image from stage 1
COPY --from=build-image-stage /publish .
ENTRYPOINT ["dotnet", "FileHubBackendV2.dll"]
