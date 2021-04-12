using Dapper;
using TiendaVirtual.Models;
using TiendaVirtual.Repository;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Data;

namespace TiendaVirtual.DataAccess
{
    public class WriteOperationRepository : IWriteOperationRepository
    {
        protected string _connectionString;
        public WriteOperationRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<string> GetStoreProcedure(int idOperacion)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@IdOperacion", idOperacion);

            using (var connection = new SqlConnection(_connectionString))
            {
                var response = (await connection.QuerySingleOrDefaultAsync<string>("[dbo].[Get_MuratOperacion]", parameters, commandType: CommandType.StoredProcedure));
                return response;
            }
        }

        public async Task<List<WriteOutput>> WriteOperation(WriteOperation writeOperation)
        {
            List<WriteOutput> obj = new List<WriteOutput>();
            var parameters = new DynamicParameters();
            parameters.Add("@ACCION", writeOperation.Accion);
            parameters.Add("@IDDATO", writeOperation.IdDato);
            parameters.Add("@XMLDatos", writeOperation.XML);


            using (var connection = new SqlConnection(_connectionString))
            {
                if ((writeOperation.IdOperacion).Equals(1)) {
                    return (await connection.QueryAsync<WriteOutput>("[dbo].[SP_UDP_CLIENTE]", parameters, commandType: CommandType.StoredProcedure)).ToList();
                }
                else if ((writeOperation.IdOperacion).Equals(2))
                {
                    return (await connection.QueryAsync<WriteOutput>("[dbo].[SP_UDP_OPERACION]", parameters, commandType: CommandType.StoredProcedure)).ToList();
                }
                return obj;
            }
        }
    }
}
