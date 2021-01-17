using TiendaVirtual.Repository;

namespace TiendaVirtual.UnitOfWork
{
    public interface IUnitOfWork
    {
        ISecurityRepository Security { get; }
        IMuratServiceRepository Murat { get; }
        IWriteOperationRepository WriteOperation { get; }
    }
}
