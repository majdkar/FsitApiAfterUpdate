using BLL.Context;
using DL.Model;
using DL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Repository
{
  public  class RepoProduct : RepositoryGeneric<Product> 
    {
        private readonly ApplicationContext _context;


        public RepoProduct(ApplicationContext context) : base(context)
        {
            this._context = context;
        }

        public void Add(ProductVM p)
        {
            var prod = new Product();
            prod.Title = p.Title;
            prod.Description = p.Description;
            prod.CreateOfDate = p.CreateOfDate;
            prod.Price = p.Price;
            prod.Id = p.Id;

            var result = _context.TblProduct.Add(prod);
            _context.SaveChanges();

            foreach (var categoryId in p.categories)
            {
                var categoruproducts = new Category_Product();
                categoruproducts.CategoryId = categoryId;
                categoruproducts.ProductId = prod.Id;

                _context.TblCategory_Product.Add(categoruproducts);
            }
            _context.SaveChanges();

        }

        public void UpdateProductById(int id, ProductVM c)
        {
            var _prod = _context.TblProduct.FirstOrDefault(p => p.Id == id);
            if (_prod != null)
            {
                _prod.Title = c.Title;
                _prod.Description = c.Description;
                _prod.CreateOfDate = c.CreateOfDate;
                _prod.Price = c.Price;
                _prod.Id = id;

                _context.TblProduct.Update(_prod);
                _context.SaveChanges();

                foreach (var categoryId in c.categories)
                {
                    var categoruproducts = new Category_Product();
                    categoruproducts.CategoryId = categoryId;
                    categoruproducts.ProductId = id;

                    _context.TblCategory_Product.Update(categoruproducts);
                }
                _context.SaveChanges();
            }

        }

      
    }
}
