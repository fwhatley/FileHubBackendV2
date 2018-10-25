#!/bin/bash
#set -x #echo on

echo "INFO - stop supervisor to avoid port used errors"
sudo service supervisor stop

echo "INFO - deleting old app: FileHubBackendV2"
rm -rf /var/FileHubBackendV2

echo "INFO - publishing app: FileHubBackendV2"
dotnet publish

echo "INFO - copying new app to be served: FileHubBackendV2"
sudo cp -a ~/FileHubBackendV2/FileHubBackendV2/bin/Debug/netcoreapp2.1/publish/ /var/FileHubBackendV2

echo "INFO - serving app: FileHubBackendV2"
sudo /usr/bin/dotnet /var/FileHubBackendV2/FileHubBackendV2.dll --server.urls:https://*:5000

echo "INFO - start supervisor so FileHubApi never goes down"
sudo service supervisor start

