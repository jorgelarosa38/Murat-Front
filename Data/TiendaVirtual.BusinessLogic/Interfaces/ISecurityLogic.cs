using System.Threading.Tasks;
using TiendaVirtual.BusinessLogic.Utilities;
using TiendaVirtual.Models;

namespace TiendaVirtual.BusinessLogic.Interfaces
{
    public interface ISecurityLogic
    {
        Task<Response> ValidarAccesos(Credenciales credenciales);
    }
}
