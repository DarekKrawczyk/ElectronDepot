# Database
![Database diagram](Images/DBDiagram.svg)

## Table `Users`
Stores registered users' data.

| Column       | Type         | Description                          |
|--------------|--------------|--------------------------------------|
| `UserID`     | INT (PK)     | Unique identifier for the user       |
| `Username`   | VARCHAR(255) | Username                             |
| `Password`   | VARCHAR(255) | Password                             |
| `Email`      | VARCHAR(255) | Email address                        |

## Table `Suppliers`
Stores information about component suppliers.

| Column       | Type         | Description                          |
|--------------|--------------|--------------------------------------|
| `SupplierID` | INT (PK)     | Unique identifier for the supplier    |
| `Name`       | VARCHAR(255) | Supplier name                        |
| `Website`    | VARCHAR(255) | Supplier website                     |

## Table `Purchases`
Stores data about purchases made by users.

| Column        | Type         | Description                              |
|---------------|--------------|------------------------------------------|
| `PurchaseID`  | INT (PK)     | Unique identifier for the purchase       |
| `UserID`      | INT (FK)     | ID of the user who made the purchase     |
| `SupplierID`  | INT (FK)     | ID of the supplier the purchase was made from |
| `PurchasedDate`| DATE        | Date of purchase                        |
| `TotalPrice`  | DECIMAL      | Total price of the purchase              |

## Table `PurchaseItems`
Stores information about individual items in a purchase.

| Column         | Type         | Description                              |
|----------------|--------------|------------------------------------------|
| `PurchaseItemID`| INT (PK)    | Unique identifier for the purchase item  |
| `PurchaseID`   | INT (FK)     | ID of the purchase                       |
| `ComponentID`  | INT (FK)     | ID of the component                      |
| `Quantity`     | INT          | Number of units purchased                |
| `PricePerUnit` | DECIMAL      | Price per unit                           |

## Table `Components`
Stores information about electronic components, including microchips and other parts.

| Column        | Type           | Description                             |
|---------------|----------------|-----------------------------------------|
| `ComponentID` | INT (PK)       | Unique identifier for the component     |
| `CategoryID`  | INT (FK)       | ID of the category from the `categories` table |
| `Name`        | VARCHAR(255)   | Name of the component                   |
| `Manufacturer`| VARCHAR(255)   | Manufacturer                           |
| `Description` | TEXT           | Description of the component            |

## Table `Categories`
Stores information about component categories.

| Column       | Type           | Description                             |
|--------------|----------------|-----------------------------------------|
| `CategoryID` | INT (PK)       | Unique identifier for the category      |
| `Name`       | VARCHAR(255)   | Name of the category                    |
| `Description`| TEXT           | Description of the category             |

## Table `Projects`
Stores information about users' projects.

| Column       | Type         | Description                              |
|--------------|--------------|------------------------------------------|
| `ProjectID`  | INT (PK)     | Unique identifier for the project        |
| `UserID`     | INT (FK)     | ID of the user who created the project   |
| `Name`       | VARCHAR(255) | Project name                            |
| `Description`| TEXT         | Project description                     |
| `CreatedAt`  | TIMESTAMP    | Date and time the project was created    |

## Table `ProjectComponents`
Stores information about components assigned to projects.

| Column             | Type         | Description                             |
|--------------------|--------------|-----------------------------------------|
| `ProjectComponentID`| INT (PK)    | Unique identifier for the project component |
| `ComponentID`      | INT (FK)     | ID of the component                    |
| `ProjectID`        | INT (FK)     | ID of the project                      |
| `Quantity`         | INT          | Number of components used in the project |

## Table `OwnsComponents`
Stores information about components owned by users.

| Column             | Type         | Description                             |
|--------------------|--------------|-----------------------------------------|
| `OwnsComponentID`   | INT (PK)    | Unique identifier                      |
| `UserID`           | INT (FK)     | ID of the user                         |
| `ComponentID`      | INT (FK)     | ID of the component                    |
| `Quantity`         | INT          | Number of components owned             |
