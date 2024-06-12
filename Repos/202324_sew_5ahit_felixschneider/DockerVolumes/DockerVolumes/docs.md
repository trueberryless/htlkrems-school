# Docs

## Build Docker Image

![img.png](./img/build.png)

## Start Container

![img.png](./img/run.png)

## Add file

![img.png](./img/add_file.png)

## Get file

![img.png](./img/get_file.png)

## Find file

We can find our file under /app/persistant.  
Also we can find other files under /app, like dlls, json, config and some others...

![img.png](./img/file_location.png)

As u can c, there is no files in /app/temp.

## Restart

As u can c, the files are still here (at least the ones that existed before as well).

![img.png](./img/stop_start.png)

## Remove

![img.png](./img/remove.png)

## Start again

![img.png](./img/start_rm.png)

As u can c, the files are not there any more:

![img.png](./img/dead.png)

## Do everything again

![img.png](./img/new_build.png)
![img.png](./img/run.png)
![img.png](./img/add_file.png)
![img.png](./img/get_file.png)

## Inspect

As u can c, there is a volume now, suiii:

![img.png](./img/volume.png)

## Docker Desktop Volume

![img.png](./img/volume_dd.png)

## Stopped

As u can c, there is no volume when container stopped.

![img.png](./img/volume_dead.png)

## New container

As u can c, after running again, there is no file.

## Now with -v

If u start with -v, like `docker run -d -p 8081:8080 -v myvolume:/app/persistent --rm --name volumescontainer volumes-exercise`, and create a file, stop, remove and run again, the files will still be there, juhu!

![img.png](./img/file_here_again.png)
