#!/bin/bash
#set -x #echo on

# INSTRUCTIONS how to auto deploy SVC
# 1. clone SVC into home directory ~/
# 2. place this script in ~/
# 3. run chmod 777 publish_svc_script.sh
# 4. run ./publish_svc_script.sh


echo "INFO - =========== DEPLOYING SVC APPLICATION ================"
echo "INFO - stopping supervisor service"
sudo service supervisor stop

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

echo "INFO - change wwwroot/uploads folder permissions so all users have read+write+exec access" # without exec, app cannot read files
chmod -R 777 /var/FileHubBackendV2/wwwroot/

echo "INFO - starting supervisor service"
sudo service supervisor start

echo "INFO - Helpful commands to see supervisor and app logs"
echo "INFO - Supervisor: sudo tail -f /var/log/supervisor/supervisord.log"
echo "INFO - App logs: sudo tail -f /var/log/FileHubBackendV2.out.log"
echo "INFO - =========== DONE DEPLOYING SVC APPLICATION ================"

# no need to start bc supervisor automatically serves it
#echo "INFO - serving app without supervisor: FileHubBackendV2"
#sudo /usr/bin/dotnet /var/FileHubBackendV2/FileHubBackendV2.dll --server.urls:https://*:5000

