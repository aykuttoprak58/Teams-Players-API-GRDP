using BusinessLayer.Abstract;
using DataAccessLayer;
using DataAccessLayer.Concrete;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class TeamService<T> : ITeamService<T> where T : class
    {
        Repository<T> repository = new Repository<T>(); 


        public void Add(T entity)
        {
            repository.Add(entity); 
        
        }

        public void Delete(T entity)
        {
            repository.Delete(entity);
          
        }

        public List<T> GetAll()
        {
          
            return repository.GetAll();     
        }

        public T GetById(int id)
        {
           return repository.GetById(id);       
        }

        public void Update(T entity)
        {
            repository.Update(entity);
    
        }
    }
    
}
