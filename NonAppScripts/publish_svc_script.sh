#!/bin/bash
#set -x #echo on

# INSTRUCTIONS how to auto deploy SVC
# 1. clone SVC into home directory ~/
# 2. place this script in ~/
# 3. run chmod 777 publish_svc_script.sh
# 4. run ./publish_svc_script.sh


echo "INFO - deleting old app: FileHubBackendV2"
rm -rf /var/FileHubBackendV2

echo "INFO - moving into directory: /FileHubBackendV2"
cd ~/FileHubBackendV2

echo "INFO - pulling latest changes"
git pull

echo "INFO - publishing app: FileHubBackendV2"
dotnet publish

echo "INFO - copying new app to be served: FileHubBackendV2"
sudo cp -a ~/FileHubBackendV2/FileHubBackendV2/bin/Debug/netcoreapp2.1/publish/ /var/FileHubBackendV2

# no need to start bc supervisor automatically serves it
#echo "INFO - serving app: FileHubBackendV2"
#sudo /usr/bin/dotnet /var/FileHubBackendV2/FileHubBackendV2.dll --server.urls:https://*:5000

