#! /bin/bash

# This script generates a typescript client for the API using the swag-ts
# Unfortunately swagger-typescript only runs with node 16 while this project is on version 18
# Not used anymore.. Changed to node version 16

nvm exec 16 swag-ts

