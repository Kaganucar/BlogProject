﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class TBLCategories
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public IList<TBLBlog> TBLBlog { get; set; }
    }
}
