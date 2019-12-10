# Experimenting with Kong

## Initial startup

Start Kong, Konga and the Calc.Api with the following command

``` bash
docker-compose up
```

See [https://github.com/Kong/docker-kong/tree/master/compose](https://github.com/Kong/docker-kong/tree/master/compose) for reference.

``` bash
http :8001/config config=@kong.yml
```

## Demo


Continue in [Demo.http](Demo.http)