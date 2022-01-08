using System.Collections.Generic;
using Codecool.CodecoolShop.Daos;
using Codecool.CodecoolShop.Daos.Implementations;
using Codecool.CodecoolShop.Models;

namespace Codecool.CodecoolShop.Services
{
    public class ProductService
    {
        private readonly IProductDao productDao;
        private readonly IProductCategoryDao productCategoryDao;
        private readonly ISupplierDao supplierDao;

        public ProductService(IProductDao productDao, IProductCategoryDao productCategoryDao, ISupplierDao supplierDao)
        {
            this.productDao = productDao;
            this.productCategoryDao = productCategoryDao;
            this.supplierDao = supplierDao;

        }

        public IEnumerable<ProductCategory> GetCategories()
        {
            IEnumerable<ProductCategory> categories = this.productCategoryDao.GetAll();
            return categories;
        }

        public IEnumerable<Supplier> GetSuppliers()
        {
            IEnumerable<Supplier> suppliers = this.supplierDao.GetAll();
            return suppliers;
        }

        public ProductCategory GetProductCategory(int categoryId)
        {
            return this.productCategoryDao.Get(categoryId);
        }

        public IEnumerable<Product> GetProductsBy(string sortBy, int id)
        {
            if (sortBy == "supplier")
            {
                Supplier supplier = this.supplierDao.Get(id);
                return this.productDao.GetBy(supplier);
            }
            ProductCategory category = this.productCategoryDao.Get(id);
            return this.productDao.GetBy(category);
        }
        
        

    }
}
