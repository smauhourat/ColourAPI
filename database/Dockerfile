# Base image
FROM mcr.microsoft.com/mssql/server:2017-latest-ubuntu

# Create app directory
RUN mkdir -p /usr/src/app
WORKDIR /usr/src/app

# Copy initializacion scripts
COPY . /usr/src/app

# Grant permissions for the run-initialization script to be executable
RUN chmod +x /usr/src/app/run-initialization.sh

EXPOSE 1433

CMD /bin/bash ./entrypoint.sh
