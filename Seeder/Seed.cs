using CompanyManager.Database;
using CompanyManager.Database.Entities;
using CompanyManager.Interfaces.ControllerInterfaces;

namespace CompanyManager.Seeder
{
    public class Seed<T> where T : BaseEntity
    {
        private readonly IBaseServiceInterface<T> _Service;

        public Seed(IBaseServiceInterface<T> Service)
        { 
            _Service = Service;
        }
        
        public void seedData(T data)
        { 
            _Service.Edit(data);
        }
    }
}
