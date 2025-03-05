using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductDomain.Querys.Objects
{
    public class SearchCardProduct : IQuery
    {
        public int Start { get; set; }
        public int Count { get; set; }

    }
}
