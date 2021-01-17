using System.Threading.Tasks;
using TiendaVirtual.Models;

namespace TiendaVirtual.BusinessLogic.Interfaces
{
    public interface IWriteOperationLogic
    {
        Task<object> WriteOperation(WriteOperation writeOperation);
    }
}
