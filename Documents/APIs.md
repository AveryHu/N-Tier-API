# API List

- [x] [Get] http://{url}:{port}/account  
- [x] [Get] http://{url}:{port}/account/{id}  
- [x] [Post] http://{url}:{port}/account  
- [x] [Put] http://{url}:{port}/account/{id}  
- [x] [Delete] http://{url}:{port}/account/{id}

## API usage guide

* Get
  * Body  
``` ``` 
* Get (id)
  * Body  
``` ``` 
* Post
  * Body  
``` {Name:string, Password_hash:string, Gender:Gender enum} ``` 
* Put
  * Body  
``` {Name:string, Gender:Gender enum} ``` 
* Delete
  * Body  
``` {Id:int, Password_hash:string} ``` 