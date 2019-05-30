FROM microsoft/dotnet:latest
COPY . /app
WORKDIR /app
RUN ["dotnet", "restore"]
RUN ["dotnet", "build"]
EXPOSE 5001
ENTRYPOINT ["dotnet", "run", " — server.urls", "http://0.0.0.0:80"]
