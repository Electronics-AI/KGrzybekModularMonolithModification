FROM mcr.microsoft.com/mssql/server:2017-latest

EXPOSE 1433

COPY ./Scripts/ /scripts/

ADD entrypoint.sh /

ENTRYPOINT ["/bin/bash", "/entrypoint.sh"]