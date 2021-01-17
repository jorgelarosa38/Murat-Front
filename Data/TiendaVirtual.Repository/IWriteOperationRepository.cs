using TiendaVirtual.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TiendaVirtual.Repository
{
    public interface IWriteOperationRepository
    {
        Task<List<WriteOutput>> WriteOperation(WriteOperation writeOperation);
        Task<string> GetStoreProcedure(int idOperacion);
    }
}
