using BLL.Context;
using DL.Model;
using DL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Repository
{
   public class RepoCategory : RepositoryGeneric<Category>
    {
        private readonly ApplicationContext _context;
       
        public RepoCategory(ApplicationContext context) : base(context)
        {
            _context = context;
        }

        public  void Add(CategoryVM c)
        {
            var cate = new Category();
            cate.Title = c.Title;
            cate.Description = c.Description;
            cate.CreateOfDate = c.CreateOfDate;
            cate.Id = c.Id;

            var result =  _context.TblCategory.Add(cate);
             _context.SaveChanges();

            foreach (var productId in c.products)
            {
                var categoruproducts = new Category_Product();
                categoruproducts.CategoryId = cate.Id;
                categoruproducts.ProductId = productId;

                 _context.TblCategory_Product.Add(categoruproducts);
            }
             _context.SaveChanges();

        }

        public void UpdateCategoryById(int id , CategoryVM c)
        {
            var _category = _context.TblCategory.FirstOrDefault(p => p.Id == id);
            if(_category != null)
            {
                _category.Title = c.Title;
                _category.Description = c.Description;
                _category.CreateOfDate = c.CreateOfDate;
                _category.Id = id;

                 _context.TblCategory.Update(_category);
                _context.SaveChanges();

                foreach (var productId in c.products)
                {
                    var categoruproducts = new Category_Product();
                    categoruproducts.CategoryId = id;
                    categoruproducts.ProductId = productId;

                    _context.TblCategory_Product.Update(categoruproducts);
                }
                _context.SaveChanges();
            }
            
        }
    }
}
