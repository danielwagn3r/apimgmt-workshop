ARG KONG_TAG
FROM kong:${KONG_TAG:-latest}


COPY kong-plugin-upstream-auth-basic /plugins/kong-plugin-upstream-auth-basic

RUN cd /plugins/kong-plugin-upstream-auth-basic && \
    ./devBuild.sh

RUN luarocks install kong-oidc && \
    luarocks install kong-response-size-limiting && \
    luarocks install kong-spec-expose && \
    luarocks install kong-service-virtualization && \
    luarocks install kong-plugin-url-rewrite
