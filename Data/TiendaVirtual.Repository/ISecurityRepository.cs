using TiendaVirtual.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TiendaVirtual.Repository
{
    public interface ISecurityRepository
    {
        Task<List<DetalleUsuario>> ValidarAccesos(Credenciales credenciales);
    }
}
