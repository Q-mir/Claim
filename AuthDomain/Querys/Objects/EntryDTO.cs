using Service;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthDomain.Querys.Object
{
    public class EntryDTO : IQuery
    {
        [MaxLength(30)] //TODO
        public string Login { get; set; } = null!;

        [MaxLength(30)] //TODO
        public string Password { get; set; } = null!;
        
    }
}
