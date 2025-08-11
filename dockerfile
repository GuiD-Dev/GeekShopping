FROM mysql:8.4

ENV MYSQL_ROOT_PASSWORD=root

COPY init-db.sql /docker-entrypoint-initdb.d/