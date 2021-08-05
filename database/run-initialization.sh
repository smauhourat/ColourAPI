# Wait to be sure that SQL Server came up
##sleep 90s

# Run the setup script to create the DB and the schema in the DB
# Note: make sure that your password matches what is in the Dockerfile
##/opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P Aa30597131972_ -d master -i create-database.sql
######################################################################################################
  sleep 90s
  #echo 'entro al script'
  if [ ! -f /tmp/db-initialized ]; then
    #echo 'entro al if'
    function initialize_database() {
      #sleep 90s

      #run setup script to create the DB and the schema in the DB
      /opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P Aa30597131972_ -d master -i create-database.sql

      # Note that the container has been initialized so future starts won't wipe changes to the data
      touch /tmp/db-initialized
    }
    initialize_database &
  fi

