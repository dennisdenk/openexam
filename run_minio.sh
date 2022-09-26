#! /bin/bash

sudo docker run -it -d -p 9000:9000 -p 9001:9001 --restart always -v ${PWD}/data/:/data \
  -e "MINIO_ROOT_USER=ROOT" --name minio \
  -e "MINIO_ROOT_PASSWORD=Aasdf123!" minio/minio server /data --console-address ":9001"
