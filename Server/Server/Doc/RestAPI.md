# Endpoints
## Users
Default json representation
``` json
{
  "userID": int,
  "username": string,
  "password": string,
  "email": string
}
```
## Create
Request
``` json
POST: ElectronDepot/Users/Create
Body:
{
  "default": User.Class
}
```
Response - success
``` json
Code: 201
Body:
{
  "default": User.Class
}
```
Response - failed (invalid input)
```json
Code: 400
Body: {}
```
Response - failed (conflict)
``` json
Code: 409
Body:
{
  "title": "Conflict",
  "status": 409,
  "message": "A user with this username|email already exists"
}
```
---
## Read
### Get all users
Request
```
GET: ElectronDepot/Users
Body: {}
```
Response
``` json
[
  {
    "default": User.Class
  },
  ...
]
```
### Get user by ID
Request
``` json
GET: ElectronDepot/Users/{id}
Body: {}
```
Response - success
``` json
Code: 200
Body: 
{
  "default": User.Class
}
```
Response - failed
``` json
Code: 404
Body:
{
  "title": "not found",
  "status": 404
}
```
---
### Update
---
### Delete
Request
``` json
DELETE: ElectronDepot/Users/Delete/{id}
Body: {}
```
Response - success
``` json
Code: 204
Body: {}
```
Response - failed
``` json
Code: 400|404
Body: {...}
```