using LiteDB;
using Models;
namespace Repositories
{
    public abstract class RepositoryStudentsBase : RepositoryBase<Students>
    {
        public RepositoryStudentsBase(LiteDatabase liteDatabase) : base(liteDatabase)
        {
            Collection.EnsureIndex(x => x.Name);
            Collection.EnsureIndex(x => x.Active);
        }
    }
}
