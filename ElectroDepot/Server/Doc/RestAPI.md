# Common Endpoints
- [ ] **All Users**
- [ ] **All Projects for a Specific User**
- [ ] **All Categories**
- [ ] **All Components Used in a Project, with Quantities**  
  `GET: ElectroDepot/Projects/GetAllComponentsFromProject/{ID}`
- [ ] **Quantity of a Specific Component Used in a Project**  
  `GET: ElectroDepot/ProjectComponents/GetProjectComponentForProject/{ProjectID}/Component/{ComponentID}`
- [ ] **Components Owned by a User**  
  `GET: ElectroDepot/Components/GetUserComponents/{ID}`
- [ ] **Quantity of a Specific Component Owned by a User**  
  `GET: ElectroDepot/OwnsComponents/GetOwnComponentFromUser/{UserID}/Component/{ComponentID}`
- [ ] **All Purchases by a User**  
  `GET: ElectroDepot/Purchases/GetAllByUserID/{ID}`
- [ ] **Components Purchased in a Transaction**  
  `GET: ElectroDepot/PurchaseItems/GetComponentsFromPurchase/{PurchaseID}`
- [ ] **Quantity of a Specific Component Purchased in a Transaction**  
  `GET: ElectroDepot/PurchaseItems/GetPurchaseItemsFromPurchase/{PurchaseID}/Component/{ComponentID}`
