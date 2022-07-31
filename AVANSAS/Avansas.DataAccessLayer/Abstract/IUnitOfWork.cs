using System.Threading.Tasks;

namespace Avansas.DataAccessLayer.Abstract
{
    public interface IUnitOfWork
    {
        Task CommitAsync();
        void Commit();
    }
}
