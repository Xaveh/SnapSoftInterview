# SnapSoftInterview

A sample .NET 6 API which contains some array calculations and log query operations. 

## Table of contents
* [Usage](#Usage)
* [Dependencies](#Dependencies)
* [Todos](#Todos)
* [Contributors](#Contributors)

## Usage
1. Clone the repository.
2. Change the connection string in the context class (potentially the password). Current connection string is:  
"host=localhost;username=postgres;password=1234;database=SnapsoftInterview"  
(I know it could have been located in a better place, but I left here to keep it simple)
3. Host the web service locally by starting it e.g. from VS (by default https://localhost:3000).
4. A demo database should be set up automatically. Use the swagger UI (https://localhost:3000/swagger/index.html) for testing. 

## Dependencies
* AutoMapper 11.0.1
* AutoMapper.Extensions.Microsoft.DependencyInjection 11.0.0
* Microsoft.EntityFrameworkCore 6.0.6
* Npgsql.EntityFrameworkCore.PostgreSQL 6.0.4
* Swashbuckle.AspNetCore 6.2.3

## Todos
* Add middlewares for input validation, authorization etc.
* Make calculations more overflow-proof (see red tests). 
 
## Contributors
* me
