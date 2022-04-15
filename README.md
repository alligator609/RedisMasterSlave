# to create a master redis in docker 
 docker run -p 6379:6379 --name redis-master -e REDIS_REPLICATION_MODE=master -e ALLOW_EMPTY_PASSWORD=yes bitnami/redis:latest
 
# to create a slave which replicate master

 docker run -p 6380:6379 --name redis-replica --link redis-master:master -e REDIS_REPLICATION_MODE=slave -e REDIS_MASTER_HOST=master -e REDIS_MASTER_PORT_NUMBER=6379 -e REDIS_MASTER_PASSWORD= -e ALLOW_EMPTY_PASSWORD=yes bitnami/redis:latest 

If any any messge given in a messeger channel all the subscribe user will gate the message. In this project redis subscriber is a user. 

Slave automatically copy from master 

If master fails or crash the Redis Sentinel will trigger an automatic failover and the replica will take over. Also trigger that process manually.

 inspired by 
 https://www.youtube.com/watch?v=jwek4w6als4&t=222s