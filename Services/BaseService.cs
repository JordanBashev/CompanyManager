using CompanyManager.Database;
using CompanyManager.Interfaces.ControllerInterfaces;
using CompanyManager.Services.NewFolder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CompanyManager.Services
{
    public class BaseService<T> : IBaseServiceInterface<T> where T : BaseEntity
    {
        private readonly CompanyManagerContext _context;
        private readonly DbSet<T> _dbSet;

        public BaseService(CompanyManagerContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        [HttpGet]
        public List<T> GetAll()
        {
            return _dbSet.ToList();
        }

        [HttpGet("{id}")]
        public T Get(int id)
        {
            var result = _dbSet.FirstOrDefault(x => x.id == id);

            if (result == null)
                return result;

            return result;
        }

        [HttpPost("{id}")]
        public bool Edit(T? data = null, int id = 0)
        {
            var result = _dbSet.FirstOrDefault(x => x.id == id);

            if (result == null && data == null)
                return false;

            //Ne ma kefi tui da se preraboti ako svursha dneska mnogo grozno sus skobi
            if (result == null && data != null)         
                _dbSet.Add(data);
            else if (id != 0 && data != null)
            {
                _context.Entry(result).State = EntityState.Detached;
                _dbSet.UpdateRange(data);
            }
                
            _context.SaveChanges();
            return true;
        }

        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            var result = Get(id);

            if(result == null)
                return false;

            _dbSet.Remove(result);
            _context.SaveChanges();

            return true;
        }

        public DbSet<T> CustomQuery()
        {
            return _dbSet;
        }
    }
}
