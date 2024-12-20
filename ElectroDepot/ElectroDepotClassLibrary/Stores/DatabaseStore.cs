﻿using ElectroDepotClassLibrary.DataProviders;

namespace ElectroDepotClassLibrary.Stores
{
    public class DatabaseStore
    {
        private SuppliersStore _supplierStore;
        private ComponentsStore _componentsStore;
        private CategoriesStore _categoriesStore;
        private ProjectsStore _projectsStore;
        private PurchasesStore _purchasesStore;
        private UsersStore _usersStore;
        public SuppliersStore SupplierStore
        {
            get
            {
                return _supplierStore;
            }
        }

        public ComponentsStore ComponentStore
        {
            get
            {
                return _componentsStore;
            }
        }

        public CategoriesStore CategorieStore
        {
            get
            {
                return _categoriesStore;
            }
        }

        public ProjectsStore ProjectStore
        {
            get
            {
                return _projectsStore;
            }
        }

        public PurchasesStore PurchaseStore
        {
            get
            {
                return _purchasesStore;
            }
        }

        public UsersStore UsersStore
        {
            get
            {
                return _usersStore;
            }
        }

        public DatabaseStore(
            SupplierDataProvider supplierDataProvider, ComponentDataProvider componentDataProvider, 
            CategoryDataProvider categoryDataProvider, ProjectDataProvider projectDataProvider,
            PurchaseDataProvider purchaseDataProvicer, UserDataProvider userDataProvider,
            OwnsComponentDataProvider ownsComponentDataProvider, ProjectComponentDataProvider projectComponentDataProvider)
        {
            _supplierStore = new SuppliersStore(this, supplierDataProvider);
            _componentsStore = new ComponentsStore(this, componentDataProvider, ownsComponentDataProvider);
            _categoriesStore = new CategoriesStore(this, categoryDataProvider);
            _projectsStore = new ProjectsStore(this, projectDataProvider);
            _purchasesStore = new PurchasesStore(this, purchaseDataProvicer);
            _usersStore = new UsersStore(this, userDataProvider);
        }
    }
}
