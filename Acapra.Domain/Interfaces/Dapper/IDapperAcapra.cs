using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acapra.Domain.Interfaces.Dapper
{
    public interface IDapperAcapra
    {
        T QueryFirstOrDefault<T>(string query, object parametros = null);
        IEnumerable<T> RunQuery<T>(string query, object parametros = null);
    }
}
