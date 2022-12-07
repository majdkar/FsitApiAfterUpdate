using DL.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DL.ViewModels
{
    public class ProductVM : BaseModel
    {
        public int Id { get; set; }

        public double Price { get; set; }

        public List<int> categories { get; set; }
    }
}