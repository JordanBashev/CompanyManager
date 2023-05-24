using Microsoft.EntityFrameworkCore;

namespace CompanyManager.Interfaces.ControllerInterfaces
{
    public interface IBaseServiceInterface<T> where T : class
    {
        public List<T> GetAll();
        public T Get( int id );
        public bool Edit( T? data = null, int id = 0 );
        public bool Delete( int id );
        public DbSet<T> CustomQuery();
    }
}
