$network = "networkanalysis_default"
$insert_script = "/data/insert.sh"

docker run --rm -it --network $network -v ${PWD}:/data confluentinc/cp-kafka:7.3.2 /bin/bash $insert_script
