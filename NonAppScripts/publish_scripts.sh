#!/bin/bash

dotnet publish
rm -rf /var/FileHubBackendV2
sudo cp -a ~/FileHubBackendV2/FileHubBackendV2/bin/Debug/netcoreapp2.1/publish/ /var/FileHubBackendV2
sudo /usr/bin/dotnet /var/FileHubBackendV2/FileHubBackendV2.dll --server.urls:https://*:5000

