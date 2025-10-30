using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acapra.Domain.Interfaces.Dapper;

namespace Vendas.Infra.Dapper
{
    public class DapperAcapra : IDapperAcapra
    {
        private readonly IDbConnection _sqlConnection;

        public DapperAcapra(IDbConnection connection)
        {
            _sqlConnection = connection;
        }

        public T QueryFirstOrDefault<T>(string query, object parametros = null)
        {
            return _sqlConnection.QueryFirstOrDefault<T>(query, parametros);
        }

        public IEnumerable<T> RunQuery<T>(string query, object parametros = null)
        {
            return _sqlConnection.Query<T>(query, parametros);
        }
    }
}
