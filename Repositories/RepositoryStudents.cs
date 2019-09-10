using LiteDB;
namespace Repositories
{
    public class RepositoryStudents : RepositoryStudentsBase
    {
        public RepositoryStudents(LiteDatabase liteDatabase) : base(liteDatabase)
        {
        }
    }
}
