using DL.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DL.ViewModels
{
  public class CategoryVM : BaseModel
    {
        public int Id { get; set; }

        public List<int> products { get; set; }
    }
}
