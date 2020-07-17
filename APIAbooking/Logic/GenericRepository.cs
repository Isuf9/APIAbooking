using APIAbooking.Logic.Client;
using APIAbooking.Models;
using APIAbooking.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIAbooking.Logic
{
    public class GenericRepository<TEntity> : IRepositoryEntity<TEntity> where TEntity : class
    {
        private APIAbookingContext _dbContext;
        
        public GenericRepository(APIAbookingContext db)
        {
            _dbContext = db;
        }


        public TEntity Create(TEntity entity)
        {
            _dbContext.Add(entity);
            Save();
            return entity;
        }

        public void Delete(TEntity entity)
        {
          
            _dbContext.Remove(entity);
            Save();
        }

        public TEntity Edit(TEntity entity)
        {
            
            _dbContext.Update(entity);
            Save();
            return entity;
        }

        //public TEntity GetById(string id)
        //{
        //    //if (id == null) return null;
        //    //var entity = _dbContext.Find(id);
        //    return id;
        //}

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void SaveAsync()
        {
            _dbContext.SaveChangesAsync();
        }
    }
}
