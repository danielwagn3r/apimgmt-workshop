# Kong DB-less

## Initial startup

Start Kong, Konga and the CalcApi with Docker Compose

``` bash
docker-compose up
```

See [https://github.com/Kong/docker-kong/tree/master/compose](https://github.com/Kong/docker-kong/tree/master/compose) for reference.

Load deklarative configuration

``` bash
http :8001/config config=@kong.yml
```

## Perform Requests

Continue in [Demo.http](Demo.http)