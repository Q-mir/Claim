using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthDomain.Querys.Object
{
    public class EntryDTO : IQuery
    {
        public string Login { get; set; } = null!;
        public string Password { get; set; } = null!;
        
    }
}
