#!/bin/sh

set -e

data_dir=/data
archive=test_data_dist.tar.gz

findings_file=findings.txt
modelobjects_file=modelobjects.txt

findings_topic=findings
modelobjects_topic=model_objects

kafka_server=kafka:19092

cd $data_dir

tar -xvf $archive

kafka-console-producer --bootstrap-server $kafka_server --topic $modelobjects_topic < $modelobjects_file
kafka-console-producer --bootstrap-server $kafka_server --topic $findings_topic < $findings_file
