using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IQueryService<in Tin, out Tout> where Tin : IQuery
    {
        Tout Execute(Tin obj);
    }
}
