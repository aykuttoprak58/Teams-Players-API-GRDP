using DataAccessLayer.Abstract;
using DataAccessLayer;
using EntityLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Repository<T> : IRepository<T> where T : class
    {
        EPLDbContext context = new EPLDbContext(); 
        DbSet<T> dbSet;
     
        
        public Repository()
        {
            dbSet = context.Set<T>();
           
        }

        public void Add(T entity)
        {
          dbSet.Add(entity);
          context.SaveChanges();    
           
        }

        public void Delete(T entity)
        {
            dbSet.Remove(entity);
            context.SaveChanges();
        }

        public List<T> GetAll()
        {
            var teams =dbSet.ToList();  
            
            return teams; 

        }

        public T GetById(int id)
        {

            var teams = dbSet.Find(id);

            return teams;    
        }

        public void Update(T entity)
        {
            dbSet.Update(entity);
            context.SaveChanges();
        }
    }

}
