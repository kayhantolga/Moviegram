# Moviegram

## This is the sample project for .Net Core API

Clients can call all apis without any authorization.  
Every api has own help description at Swagger Documentation.
You will be able to achive Swagger page after to run project.

## Installation

1. Clone
2. Project will create a new database named as Moviegram. If you have already a database with same name simply change the name of Database from [Connectionstring](https://github.com/kayhantolga/Moviegram/blob/develop/Moviegram/appsettings.json) .
3. Run

## Note
**Cursor Usage**  
Every api with listed response object has cursor implementation.  
You can send your cursor information data at Querystring.
CursorPageSize for size of items (default 20)  
CursorIndex for index of page(default 0)  
Sample Usage:  
/api/movie/movies?CursorPageSize=5&CursorIndex=0  
/api/movie/movies?CursorPageSize=5&CursorIndex=1
.
.


## Feel free to ask questions, Enjoy

