using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zekavit_Shared.Entity;

namespace Zekavit_Shared
{
    public class ProductSearchResult
    {
        public List<Product> Products { get; set; } = new List<Product>();

        public int Pages { get; set; }

        public int CurrentPages { get; set; }
    }
}
