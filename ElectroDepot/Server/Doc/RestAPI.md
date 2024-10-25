# Endpoints
## Users endpoints
Podstawowe operacje na użytkownikach.
- [x] Create - tworzenie użytkownika
- [x] Get all - zwrócenie wszystkich użytkowników w bazie.
- [x] Get by ID - użytkownik po ID.
- [x] Update - zmiana danych użytkownika hasło/email.
- [x] Delete - usunięcie użytkownika z bazy.
## Suppliers endpoints
Informacje na temat dostawców takich jak Botland, Kamami itp...
- [x] Create - dodanie nowego dostawcy
- [x] Get all
- [x] Get by ID
- [x] Update
- [x] Delete
## Purchases endpoints
Informacje na temat zakupu, coś rodzaju koszyka. Nie widze potrzeby żeby modyfikować
tego typu rekordy.
- [x] Create
- [x] Get all
- [x] Get by id
- [x] Delete
## PurchaseItems endpoints
To jest jeden rodzaj przedmiotu kupionego w ramach koszyka.
Nie widze potrzeby żeby można było to modyfikować. Jak już coś zostało dodane
i miało jakąś cene to nie widze sensu żeby to zmieniać.
- [x] Create
- [x] Get all
- [x] Get by id
- [x] Delete

---
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
POST: ElectroDepot/Users/Create
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
GET: ElectroDepot/Users
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
GET: ElectroDepot/Users/{id}
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
DELETE: ElectroDepot/Users/Delete/{id}
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