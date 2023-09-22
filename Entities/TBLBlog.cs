using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class TBLBlog
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string BlogName { get; set; }
        public string Explanation { get; set; }
        public string Images { get; set; }
        public int CategoriesId { get; set; }
        public TBLCategories TBLCategory { get; set; }
    }
}
