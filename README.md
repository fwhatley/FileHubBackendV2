# FileHubBackendV2

[![Build Status](https://travis-ci.org/joemccann/dillinger.svg?branch=master)](https://travis-ci.org/joemccann/dillinger)

This is the API for the FileHub app: [https://github.com/fwhatley/FileHubFrontend](https://github.com/fwhatley/FileHubFrontend)

## Set up your dev env
  - open `FileHubBackendV2.sln` with Visual Studio for Mac or Windows
  - run the app
    - app will run at [http://localhost/index.html](http://localhost/index.html)
## Build a new image
```sh
# build image fredywhatley/filehubbackendv2:tagname 
docker build -f Dockerfile -t fredywhatley/filehubbackendv2:2.0.0 . # make sure to update the tag

# push to docker central with push fredywhatley/filehubbackendv2:tagname 
docker login
docker push fredywhatley/filehubbackendv2:2.0.0 # tag must match what you used above
```

## Serve production build locally
Run
```sh
docker-compose up # app will be served at http://localhost:5000
```

Other helpful commands
```sh
# run detached and rebuild, -d and --build are optional, --build is required when app needs to be rebuilt
docker-compose up -d --build 

# stop and remove containers
docker-compose down 
```

## Notes
- for more details see the `Dockerfile.yml` and `docker-compose.yml`



