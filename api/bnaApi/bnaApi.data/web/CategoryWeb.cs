using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bnaApi.data.web
{
    public class CategoryWeb
    {
        public System.Guid id { get; set; }
        public string name { get; set; }

        public CategoryWeb() { }

        public CategoryWeb(Category category)
        {

            id = category.id;
            name = category.name;
        }
    }
}
