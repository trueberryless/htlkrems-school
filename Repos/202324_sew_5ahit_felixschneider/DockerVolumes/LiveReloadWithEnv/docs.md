# How is the container port on which the application listens defined and managed?

Through the `.env` file and the config in the `server.mjs`: 

```.env
PORT=8000
```

```mjs
app.listen(process.env.PORT);
```

# What does the ARG command do in your Dockerfile and how can you use that when building an image?

Defining and argument (which can be set when starting container to override default value). I didn't see it during build.

# Why does the application listen on the port defined in the environment variable?

```mjs
app.listen(process.env.PORT);
```

# How can you set environment variables when running a container? (There are 2 ways. One might be connected to the .env file. But you should try it out to make sure.)

1. With the `-e`-option when running container:

```powershell
docker run -it -p 8082:80 -v C:\Users\trueb\repos\school\202324_sew_5ahit_felixschneider\DockerVolumes\LiveReloadWithEnv:/app -v /app/node_modules --rm --name bindmountcontainer -e PORT=80 bindmountimg
```

2. With the `--env-file`-option when running container:

```powershell
docker run -it -p 8082:80 -v C:\Users\trueb\repos\school\202324_sew_5ahit_felixschneider\DockerVolumes\LiveReloadWithEnv:/app -v /app/node_modules --rm --name bindmountcontainer --env-file .env bindmountimg
```

# What is a .dockerignore file?

File for setting what files to ignore when building Docker Image.

# What is nodemon and how did we use it in that example?

nodemon is a tool that helps develop Node.js based applications by automatically restarting the node application when file changes in the directory are detected.

When calling npm start, this script runs with nodemon:

```json
"scripts": {
    "start": "nodemon server.mjs"
},
```

# Which part of the docker run command defines a bind mount?

```powershell
-v C:\Users\trueb\repos\school\202324_sew_5ahit_felixschneider\DockerVolumes\LiveReloadWithEnv:/app
```

# Why did we have to specify an anonymous volume using -v /app/node_modules? What would happen if we left that out? (This last question is probably the most important question for you to understand how volumes and bind mounts interact with each other.)

The anonymous volume overrides our local node_modules folder, so it can find nodemon which is only installed in the containers node_module folder.