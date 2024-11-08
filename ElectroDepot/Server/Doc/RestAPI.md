# API Endpoints

---

# Categories API Endpoints

## Base URL
All endpoints are prefixed with `/ElectroDepot/Categories`.

---

## Create a Category

### `POST /ElectroDepot/Categories/Create`

**Description:** Creates a new category.

**Request Body:**
- `CreateCategoryDTO` - The category data to create.

---

## Get All Categories

### `GET /ElectroDepot/Categories/GetAll`

**Description:** Retrieves all categories.

---

## Get Category by ID

### `GET /ElectroDepot/Categories/GetCategoryByID/{id}`

**Description:** Retrieves a specific category by its ID.

**Path Parameters:**
- `id` (int) - The ID of the category.

---

## Get Category by Name

### `GET /ElectroDepot/Categories/GetCategoryByName/{name}`

**Description:** Retrieves a specific category by its name.

**Path Parameters:**
- `name` (string) - The name of the category.

---

## Update Category

### `PUT /ElectroDepot/Categories/Update/{id}`

**Description:** Updates an existing category by its ID.

**Path Parameters:**
- `id` (int) - The ID of the category to update.

**Request Body:**
- `UpdateCategoryDTO` - The category data to update.

---

## Delete Category

### `DELETE /ElectroDepot/Categories/Delete/{id}`

**Description:** Deletes a category by its ID.

**Path Parameters:**
- `id` (int) - The ID of the category to delete.

---

# Components API Endpoints

## Base URL
All endpoints are prefixed with `/ElectroDepot/Components`.

---

## Create a Component

### `POST /ElectroDepot/Components/Create`

**Description:** Creates a new component.

**Request Body:**
- `CreateComponentDTO` - The component data to create.

---

## Get All Components

### `GET /ElectroDepot/Components/GetAll`

**Description:** Retrieves all components.

---

## Get Component by ID

### `GET /ElectroDepot/Components/GetComponentByID/{id}`

**Description:** Retrieves a specific component by its ID.

**Path Parameters:**
- `id` (int) - The ID of the component.

---

## Get Component by Name

### `GET /ElectroDepot/Components/GetComponentByName/{name}`

**Description:** Retrieves a specific component by its name.

**Path Parameters:**
- `name` (string) - The name of the component.

---

## Get Available Components from User

### `GET /ElectroDepot/Components/GetAvailableComponentsFromUser/{ID}`

**Description:** Retrieves available components owned by a specific user.

**Path Parameters:**
- `ID` (int) - The ID of the user.

**Response:** Returns a list of `ComponentDTO` objects owned by the specified user.

---

## Get User Components

### `GET /ElectroDepot/Components/GetUserComponents/{ID}`

**Description:** Retrieves all components owned by a specific user.

**Path Parameters:**
- `ID` (int) - The ID of the user.

**Response:** Returns a list of `ComponentDTO` objects owned by the specified user.

---

## Update Component

### `PUT /ElectroDepot/Components/Update/{id}`

**Description:** Updates an existing component by its ID.

**Path Parameters:**
- `id` (int) - The ID of the component to update.

**Request Body:**
- `UpdateComponentDTO` - The updated component data.

**Response:** Returns a 204 No Content status on successful update.

---

## Delete Component

### `DELETE /ElectroDepot/Components/Delete/{id}`

**Description:** Deletes a component by its ID.

**Path Parameters:**
- `id` (int) - The ID of the component to delete.

**Response:** Returns a 204 No Content status on successful deletion.

---

# OwnsComponents API Endpoints

## Base URL
All endpoints are prefixed with `/ElectroDepot/OwnsComponents`.

---

## Create an OwnsComponent

### `POST /ElectroDepot/OwnsComponents/Create`

**Description:** Creates a new record indicating that a user owns a specific component.

**Request Body:**
- `CreateOwnsComponentDTO` - Contains `UserID` and `ComponentID` to establish ownership and the quantity owned.

**Responses:**
- **200 OK** - Returns the created `OwnsComponentDTO`.
- **400 Bad Request** - If the user or component does not exist.

---

## Get All OwnsComponents

### `GET /ElectroDepot/OwnsComponents/GetAll`

**Description:** Retrieves all `OwnsComponent` records.

---

## Get OwnsComponent by ID

### `GET /ElectroDepot/OwnsComponents/GetByID/{id}`

**Description:** Retrieves a specific `OwnsComponent` by its ID.

**Path Parameters:**
- `id` (int) - The ID of the owns component record.

---

## Get OwnsComponent for Specific User and Component

### `GET /ElectroDepot/OwnsComponents/GetOwnComponentFromUser/{UserID}/Component/{ComponentID}`

**Description:** Retrieves a specific `OwnsComponent` record showing how much of a given component a user owns.

**Path Parameters:**
- `UserID` (int) - The ID of the user.
- `ComponentID` (int) - The ID of the component.

**Response:** 
- **200 OK** - Returns the found `OwnsComponentDTO`.
- **404 Not Found** - If the user, component, or ownership record does not exist.

---

## Get All Components Owned by a User

### `GET /ElectroDepot/OwnsComponents/GetAllOwnComponentFromUser/{UserID}`

**Description:** Retrieves all `OwnsComponent` records for a specific user.

**Path Parameters:**
- `UserID` (int) - The ID of the user.

**Response:** Returns a list of `OwnsComponentDTO` objects that the user owns.

---

## Get All Free-to-Use Components for a User

### `GET /ElectroDepot/OwnsComponents/GetAllFreeToUseFromUser/{UserID}`

**Description:** Retrieves all components owned by the user that are not currently being used in any project.

**Path Parameters:**
- `UserID` (int) - The ID of the user.

**Response:** Returns a list of `OwnsComponentDTO` objects that are free to use.

---

## Get All Used Components for a User

### `GET /ElectroDepot/OwnsComponents/GetAllUsedFromUser/{UserID}`

**Description:** Retrieves all components owned by the user that are currently being used in projects.

**Path Parameters:**
- `UserID` (int) - The ID of the user.

**Response:** Returns a list of `OwnsComponentDTO` objects that are in use.

---

## Update OwnsComponent Quantity

### `PUT /ElectroDepot/OwnsComponents/Update/{id}`

**Description:** Updates the quantity of a specific `OwnsComponent` record.

**Path Parameters:**
- `id` (int) - The ID of the owns component record.

**Request Body:**
- `UpdateOwnsComponentDTO` - Contains the new quantity.

**Response:** 
- **204 No Content** - On successful update.
- **404 Not Found** - If the owns component record no longer exists.

---

## Delete OwnsComponent

### `DELETE /ElectroDepot/OwnsComponents/Delete/{id}`

**Description:** Deletes a specific `OwnsComponent` record.

**Path Parameters:**
- `id` (int) - The ID of the owns component record.

**Response:** 
- **204 No Content** - On successful deletion.
- **404 Not Found** - If the owns component record does not exist.

---

# ProjectComponents API Endpoints

## Base URL
All endpoints are prefixed with `/ElectroDepot/ProjectComponents`.

---

## Create a ProjectComponent

### `POST /ElectroDepot/ProjectComponents/Create`

**Description:** Creates a new record indicating that a project uses a specific component with a given quantity.

**Request Body:**
- `CreateProjectComponentDTO` - Contains details about the project, component, and quantity.

**Responses:**
- **201 Created** - Returns the created `ProjectComponentDTO`, including the location of the new resource.
- **404 Not Found** - If the project or component does not exist.

---

## Get All ProjectComponents

### `GET /ElectroDepot/ProjectComponents/GetAll`

**Description:** Retrieves all `ProjectComponent` records.

**Response:** Returns a list of all `ProjectComponentDTO` objects.

---

## Get All ProjectComponents by Project

### `GET /ElectroDepot/ProjectComponents/GetAllByProject/{ID}`

**Description:** Retrieves all components associated with a specific project.

**Path Parameters:**
- `ID` (int) - The ID of the project.

**Response:** 
- **200 OK** - Returns a list of `ProjectComponentDTO` objects for the specified project.
- **404 Not Found** - If the project does not exist.

---

## Get Specific ProjectComponent by Project and Component

### `GET /ElectroDepot/ProjectComponents/GetProjectComponentForProject/{ProjectID}/Component/{ComponentID}`

**Description:** Retrieves a specific `ProjectComponent` record for a given project and component combination.

**Path Parameters:**
- `ProjectID` (int) - The ID of the project.
- `ComponentID` (int) - The ID of the component.

**Response:**
- **200 OK** - Returns the `ProjectComponentDTO` for the specified project and component.
- **404 Not Found** - If the project, component, or the relationship does not exist.

---

## Get ProjectComponent by ID

### `GET /ElectroDepot/ProjectComponents/GetByID/{id}`

**Description:** Retrieves a specific `ProjectComponent` by its ID.

**Path Parameters:**
- `id` (int) - The ID of the project component record.

**Response:**
- **200 OK** - Returns the `ProjectComponentDTO` for the specified ID.
- **404 Not Found** - If the project component does not exist.

---

## Update ProjectComponent Quantity

### `PUT /ElectroDepot/ProjectComponents/Update/{id}`

**Description:** Updates the quantity of a specific `ProjectComponent` record.

**Path Parameters:**
- `id` (int) - The ID of the project component record.

**Request Body:**
- `UpdateProjectComponentDTO` - Contains the new quantity.

**Response:** 
- **200 OK** - On successful update.
- **404 Not Found** - If the project component does not exist.

---

## Delete ProjectComponent

### `DELETE /ElectroDepot/ProjectComponents/Delete/{id}`

**Description:** Deletes a specific `ProjectComponent` record.

**Path Parameters:**
- `id` (int) - The ID of the project component record.

**Response:** 
- **200 OK** - On successful deletion.
- **404 Not Found** - If the project component does not exist.

---

# Projects API Endpoints

## Base URL
All endpoints are prefixed with `/ElectroDepot/Projects`.

---

## Create a Project

### `POST /ElectroDepot/Projects/Create`

**Description:** Creates a new project and records the current timestamp as the creation date.

**Request Body:**
- `CreateProjectDTO` - Contains details about the project, including user information, name, description, etc.

**Responses:**
- **201 Created** - Returns the created `ProjectDTO` with the resource location.
- **400 Bad Request** - If the input data is invalid.

---

## Get All Projects

### `GET /ElectroDepot/Projects/GetAll`

**Description:** Retrieves all project records.

**Response:** 
- **200 OK** - Returns a list of `ProjectDTO` objects for all projects.

---

## Get All Projects of a User

### `GET /ElectroDepot/Projects/GetAllOfUser/{ID}`

**Description:** Retrieves all projects associated with a specific user.

**Path Parameters:**
- `ID` (int) - The ID of the user.

**Response:** 
- **200 OK** - Returns a list of `ProjectDTO` objects for the specified user.
- **404 Not Found** - If the user does not exist.

---

## Get Project by ID

### `GET /ElectroDepot/Projects/GetByID/{ID}`

**Description:** Retrieves a specific project by its ID.

**Path Parameters:**
- `ID` (int) - The ID of the project.

**Response:** 
- **200 OK** - Returns the `ProjectDTO` for the specified project ID.
- **404 Not Found** - If the project does not exist.

---

## Get Project Price by ID

### `GET /ElectroDepot/Projects/GetPriceByID/{ID}`

**Description:** Calculates and returns the total price of all components used in a specific project by summing the costs of associated `PurchaseItem` records.

**Path Parameters:**
- `ID` (int) - The ID of the project.

**Response:** 
- **200 OK** - Returns the total price as a `double`.
- **404 Not Found** - If the project does not exist.
- **400 Bad Request** - If there is an error during the calculation.

---

## Get All Components in a Project

### `GET /ElectroDepot/Projects/GetAllComponentsFromProject/{ID}`

**Description:** Retrieves all components associated with a specific project.

**Path Parameters:**
- `ID` (int) - The ID of the project.

**Response:**
- **200 OK** - Returns a list of `ComponentDTO` objects for components in the specified project.
- **404 Not Found** - If the project does not exist.
- **400 Bad Request** - If there is an error during the retrieval.

---

## Update a Project

### `PUT /ElectroDepot/Projects/Update/{id}`

**Description:** Updates the name and description of a specific project.

**Path Parameters:**
- `id` (int) - The ID of the project.

**Request Body:**
- `UpdateProjectDTO` - Contains updated values for project name and description.

**Response:** 
- **200 OK** - On successful update.
- **404 Not Found** - If the project does not exist.

---

## Delete a Project

### `DELETE /ElectroDepot/Projects/Delete/{id}`

**Description:** Deletes a specific project by its ID.

**Path Parameters:**
- `id` (int) - The ID of the project.

**Response:** 
- **200 OK** - On successful deletion.
- **404 Not Found** - If the project does not exist.

---

# PurchaseItems API Endpoints

## Base URL
All endpoints are prefixed with `/ElectroDepot/PurchaseItems`.

---

## Create a Purchase Item

### `POST /ElectroDepot/PurchaseItems/Create`

**Description:** Creates a new `PurchaseItem` associated with a specified purchase and component.

**Request Body:**
- `CreatePurchaseItemDTO` - Contains details such as `PurchaseID`, `ComponentID`, `Quantity`, and `PricePerUnit`.

**Responses:**
- **200 OK** - Returns the created `PurchaseItemDTO` on successful creation.
- **404 Not Found** - If the `PurchaseID` or `ComponentID` doesn't exist.

---

## Get All Purchase Items

### `GET /ElectroDepot/PurchaseItems/GetAll`

**Description:** Retrieves all `PurchaseItem` records.

**Response:** 
- **200 OK** - Returns a list of `PurchaseItemDTO` objects for all purchase items.

---

## Get Purchase Item by ID

### `GET /ElectroDepot/PurchaseItems/GetByID/{id}`

**Description:** Retrieves a specific purchase item by its ID.

**Path Parameters:**
- `id` (int) - The ID of the purchase item.

**Response:** 
- **200 OK** - Returns the `PurchaseItemDTO` for the specified purchase item ID.
- **404 Not Found** - If the purchase item does not exist.

---

## Get All Purchase Items from a Purchase

### `GET /ElectroDepot/PurchaseItems/GetAllPurchaseItemsFromPurchase/{PurchaseID}`

**Description:** Retrieves all purchase items associated with a specific purchase ID.

**Path Parameters:**
- `PurchaseID` (int) - The ID of the purchase.

**Response:** 
- **200 OK** - Returns a list of `PurchaseItemDTO` objects for the specified purchase.
- **404 Not Found** - If the purchase does not exist.
- **400 Bad Request** - If there is an error during retrieval.

---

## Get Components from a Purchase

### `GET /ElectroDepot/PurchaseItems/GetComponentsFromPurchase/{PurchaseID}`

**Description:** Retrieves all components associated with a specific purchase.

**Path Parameters:**
- `PurchaseID` (int) - The ID of the purchase.

**Response:** 
- **200 OK** - Returns a list of `ComponentDTO` objects for the specified purchase.
- **404 Not Found** - If the purchase does not exist.
- **400 Bad Request** - If there is an error during retrieval.

---

## Get Specific Purchase Item by Purchase and Component ID

### `GET /ElectroDepot/PurchaseItems/GetPurchaseItemsFromPurchase/{PurchaseID}/Component/{ComponentID}`

**Description:** Retrieves specific purchase items from a purchase based on `PurchaseID` and `ComponentID`.

**Path Parameters:**
- `PurchaseID` (int) - The ID of the purchase.
- `ComponentID` (int) - The ID of the component.

**Response:** 
- **200 OK** - Returns a list of `PurchaseItemDTO` objects for the specified purchase and component.
- **404 Not Found** - If either the purchase or component does not exist.
- **400 Bad Request** - If there is an error during retrieval.

---

## Update a Purchase Item

### `PUT /ElectroDepot/PurchaseItems/Update/{id}`

**Description:** Updates the quantity and price per unit for a specific purchase item.

**Path Parameters:**
- `id` (int) - The ID of the purchase item.

**Request Body:**
- `UpdatePurchaseItemDTO` - Contains the updated values for `Quantity` and `PricePerUnit`.

**Response:** 
- **200 OK** - On successful update.
- **404 Not Found** - If the purchase item does not exist.
- **400 Bad Request** - If there is an error during the update.

---

## Delete a Purchase Item

### `DELETE /ElectroDepot/PurchaseItems/Delete/{id}`

**Description:** Deletes a specific purchase item by its ID.

**Path Parameters:**
- `id` (int) - The ID of the purchase item.

**Response:** 
- **204 No Content** - On successful deletion.
- **404 Not Found** - If the purchase item does not exist.

---

# PurchasesController API Documentation

This documentation outlines the available endpoints for managing purchases in the `PurchasesController`.

## Base URL
All endpoints are accessible under the `/ElectroDepot/Purchases` base URL.

---

### Endpoints

#### 1. Create Purchase
**Endpoint:** `POST /ElectroDepot/Purchases/Create`

- **Description:** Creates a new purchase associated with a user and supplier.
- **Request Body:**
  - `CreatePurchaseDTO`:
    - **UserID**: ID of the user making the purchase.
    - **SupplierID**: ID of the supplier for this purchase.
    - **TotalPrice**: Total price of the purchase.
    - **PurchaseDate**: Date of the purchase.
- **Response:**
  - **200 OK**: Returns the created `PurchaseDTO`.
  - **404 Not Found**: User or supplier with the given ID does not exist.

---

#### 2. Get All Purchases
**Endpoint:** `GET /ElectroDepot/Purchases/GetAll`

- **Description:** Retrieves all purchase records in the system.
- **Response:**
  - **200 OK**: Returns a list of `PurchaseDTO` objects.

---

#### 3. Get Purchase by ID
**Endpoint:** `GET /ElectroDepot/Purchases/GetByID/{ID}`

- **Description:** Retrieves a specific purchase by its ID.
- **Parameters:**
  - **ID** (int): The unique ID of the purchase.
- **Response:**
  - **200 OK**: Returns the `PurchaseDTO` for the specified ID.
  - **404 Not Found**: Purchase with the given ID does not exist.

---

#### 4. Get Purchase Items by Purchase ID
**Endpoint:** `GET /ElectroDepot/Purchases/GetPurchaseItemByID/{ID}`

- **Description:** Retrieves all items associated with a specified purchase.
- **Parameters:**
  - **ID** (int): The ID of the purchase.
- **Response:**
  - **200 OK**: Returns a list of `PurchaseItemDTO` objects for the specified purchase.
  - **404 Not Found**: Purchase with the given ID does not exist.

---

#### 5. Get All Purchases by User ID
**Endpoint:** `GET /ElectroDepot/Purchases/GetAllByUserID/{ID}`

- **Description:** Retrieves all purchases made by a specified user.
- **Parameters:**
  - **ID** (int): The unique ID of the user.
- **Response:**
  - **200 OK**: Returns a list of `PurchaseDTO` objects for the specified user.
  - **404 Not Found**: User with the given ID does not exist.

---

#### 6. Get All Purchases by Supplier ID
**Endpoint:** `GET /ElectroDepot/Purchases/GetAllBySupplierID/{ID}`

- **Description:** Retrieves all purchases associated with a specified supplier.
- **Parameters:**
  - **ID** (int): The unique ID of the supplier.
- **Response:**
  - **200 OK**: Returns a list of `PurchaseDTO` objects for the specified supplier.
  - **404 Not Found**: Supplier with the given ID does not exist.

---

#### 7. Update Purchase
**Endpoint:** `PUT /ElectroDepot/Purchases/Update/{ID}`

- **Description:** Updates an existing purchase's `TotalPrice` and `PurchaseDate`.
- **Parameters:**
  - **ID** (int): The unique ID of the purchase to update.
- **Request Body:**
  - `UpdatePurchaseDTO`:
    - **TotalPrice**: Updated total price of the purchase.
    - **PurchaseDate**: Updated date of the purchase.
- **Response:**
  - **200 OK**: Purchase updated successfully.
  - **404 Not Found**: Purchase with the given ID does not exist.

---

#### 8. Delete Purchase
**Endpoint:** `DELETE /ElectroDepot/Purchases/Delete/{ID}`

- **Description:** Deletes a purchase by its ID.
- **Parameters:**
  - **ID** (int): The unique ID of the purchase to delete.
- **Response:**
  - **200 OK**: Purchase deleted successfully.
  - **404 Not Found**: Purchase with the given ID does not exist.

---

# SuppliersController API Documentation

This documentation outlines the available endpoints for managing suppliers in the `SuppliersController`.

## Base URL
All endpoints are accessible under the `/ElectroDepot/Suppliers` base URL.

---

### Endpoints

#### 1. Create Supplier
**Endpoint:** `POST /ElectroDepot/Suppliers/Create`

- **Description:** Creates a new supplier.
- **Request Body:**
  - `CreateSupplierDTO`:
    - **Name**: Name of the supplier (unique).
    - **Website**: Website URL of the supplier.
- **Response:**
  - **201 Created**: Returns the created `SupplierDTO` along with the resource's location.
  - **409 Conflict**: Supplier with the specified name already exists.

---

#### 2. Get All Suppliers
**Endpoint:** `GET /ElectroDepot/Suppliers/GetAll`

- **Description:** Retrieves all supplier records in the system.
- **Response:**
  - **200 OK**: Returns a list of `SupplierDTO` objects.

---

#### 3. Get Supplier by ID
**Endpoint:** `GET /ElectroDepot/Suppliers/GetByID/{id}`

- **Description:** Retrieves a specific supplier by its ID.
- **Parameters:**
  - **id** (int): The unique ID of the supplier.
- **Response:**
  - **200 OK**: Returns the `SupplierDTO` for the specified ID.
  - **404 Not Found**: Supplier with the given ID does not exist.

---

#### 4. Get Supplier by Name
**Endpoint:** `GET /ElectroDepot/Suppliers/GetByName/{name}`

- **Description:** Retrieves a supplier by its name.
- **Parameters:**
  - **name** (string): The name of the supplier.
- **Response:**
  - **200 OK**: Returns the `SupplierDTO` for the specified name.
  - **404 Not Found**: Supplier with the given name does not exist.

---

#### 5. Update Supplier
**Endpoint:** `PUT /ElectroDepot/Suppliers/Update/{id}`

- **Description:** Updates an existing supplier's details.
- **Parameters:**
  - **id** (int): The unique ID of the supplier to update.
- **Request Body:**
  - `UpdateSupplierDTO`:
    - **Name**: Updated name of the supplier.
    - **Website**: Updated website of the supplier.
- **Response:**
  - **200 OK**: Returns the updated `SupplierDTO`.
  - **404 Not Found**: Supplier with the given ID does not exist.
  - **409 Conflict**: A supplier with the updated name already exists.

---

#### 6. Delete Supplier
**Endpoint:** `DELETE /ElectroDepot/Suppliers/Delete/{id}`

- **Description:** Deletes a supplier by its ID.
- **Parameters:**
  - **id** (int): The unique ID of the supplier to delete.
- **Response:**
  - **200 OK**: Supplier deleted successfully.
  - **404 Not Found**: Supplier with the given ID does not exist.

---

# UsersController API Documentation

This documentation outlines the available endpoints for managing users in the `UsersController`.

## Base URL
All endpoints are accessible under the `/ElectroDepot/Users` base URL.

---

### Endpoints

#### 1. Create User
**Endpoint:** `POST /ElectroDepot/Users/Create`

- **Description:** Creates a new user.
- **Request Body:**
  - `CreateUserDTO`:
    - **Username**: Unique username for the user.
    - **Email**: Unique email address for the user.
    - **Password**: Password for the user account.
- **Response:**
  - **201 Created**: Returns the created `UserDTO` along with the resource’s location.
  - **400 Bad Request**: Model validation failed.
  - **409 Conflict**: A user with the specified username or email already exists.

---

#### 2. Get All Users
**Endpoint:** `GET /ElectroDepot/Users/GetAll`

- **Description:** Retrieves all user records in the system.
- **Response:**
  - **200 OK**: Returns a list of `UserDTO` objects.

---

#### 3. Get User by ID
**Endpoint:** `GET /ElectroDepot/Users/GetUserByID/{id}`

- **Description:** Retrieves a specific user by its ID.
- **Parameters:**
  - **id** (int): The unique ID of the user.
- **Response:**
  - **200 OK**: Returns the `UserDTO` for the specified ID.
  - **404 Not Found**: User with the given ID does not exist.

---

#### 4. Get User by Email
**Endpoint:** `GET /ElectroDepot/Users/GetUserByEMail/{EMail}`

- **Description:** Retrieves a user by their email address.
- **Parameters:**
  - **EMail** (string): The email of the user.
- **Response:**
  - **200 OK**: Returns the `UserDTO` for the specified email.
  - **404 Not Found**: User with the given email does not exist.

---

#### 5. Get User by Username
**Endpoint:** `GET /ElectroDepot/Users/GetUserByUsername/{Username}`

- **Description:** Retrieves a user by their username.
- **Parameters:**
  - **Username** (string): The username of the user.
- **Response:**
  - **200 OK**: Returns the `UserDTO` for the specified username.
  - **404 Not Found**: User with the given username does not exist.

---

#### 6. Update User
**Endpoint:** `PUT /ElectroDepot/Users/Update/{id}`

- **Description:** Updates an existing user’s details.
- **Parameters:**
  - **id** (int): The unique ID of the user to update.
- **Request Body:**
  - `UpdateUserDTO`:
    - **Username**: Updated username of the user.
    - **Email**: Updated email of the user.
    - **Password**: Updated password of the user.
- **Response:**
  - **200 OK**: User updated successfully.
  - **404 Not Found**: User with the given ID does not exist.
  - **409 Conflict**: Another user with the updated username or email already exists.

---

#### 7. Delete User
**Endpoint:** `DELETE /ElectroDepot/Users/Delete/{id}`

- **Description:** Deletes a user by its ID.
- **Parameters:**
  - **id** (int): The unique ID of the user to delete.
- **Response:**
  - **200 OK**: User deleted successfully.
  - **404 Not Found**: User with the given ID does not exist.

---