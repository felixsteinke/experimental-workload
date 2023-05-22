# Tools for Experimental Workloads

## K6 Load Testing

> [Postman Collection to K6 Script](https://k6.io/blog/load-testing-with-postman-collections/)

__Install libraries:__

```shell
npm install -g @apideck/postman-to-k6
cd k6-loadtests
```

__Convert collection to script:__

```shell
postman-to-k6 ../experimental-workload.postman_collection.json -o ./k6-loadtests/collection-script.js
```

__Run scripts:__

```shell
k6 run ./k6-loadtests/sorting-api-spring.js
```

## Docker Stats Tool

```shell
sh docker-stats.sh
```
