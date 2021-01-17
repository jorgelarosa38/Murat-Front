using Microsoft.Extensions.Configuration;
using TiendaVirtual.Repository;
using TiendaVirtual.UnitOfWork;

namespace TiendaVirtual.DataAccess
{
    public class ProjectUnitOfWork : IUnitOfWork
    {
        public ISecurityRepository Security { get; private set; }
        public IMuratServiceRepository Murat { get; private set; }
        public IWriteOperationRepository WriteOperation { get; private set; }

        public ProjectUnitOfWork(string connectionString, IConfiguration _configuration)
        {
            Security = new SecurityRepository(connectionString, _configuration);
            Murat = new MuratServiceRepository(connectionString);
            WriteOperation = new WriteOperationRepository(connectionString);
        }
    } 
}
