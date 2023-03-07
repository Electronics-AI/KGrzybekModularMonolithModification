#!/bin/bash

# Should be obtained from the environment variables
User=SA
Password=1paSS-word2

echo 'Starting sql server..' ;

# Start SQL Server
/opt/mssql/bin/sqlservr

echo 'SQL server started.';

echo 'Create database..' ;

# Create database
/opt/mssql-tools/bin/sqlcmd -d master -i /scripts/CreateDatabase_Linux.sql -U $User -P $Password;
/opt/mssql-tools/bin/sqlcmd -d MyMeetings -i  /scripts/InitializeDatabase.sql -U $User -P $Password;
/opt/mssql-tools/bin/sqlcmd -d MyMeetings -i  /scripts/SeedDatabase.sql -U $User -P $Password;
/opt/mssql-tools/bin/sqlcmd -d MyMeetings -i  /scripts/Seeds/0001_SeedCountries.sql -U $User -P $Password;

echo 'Database created' ;
