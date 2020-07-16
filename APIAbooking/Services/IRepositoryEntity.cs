using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIAbooking.Services
{
    public interface IRepositoryEntity<TEntity>
    {
        TEntity Create(TEntity entity);
        TEntity Edit(TEntity entity);
        void Delete(TEntity entity);
        //TEntity GetById(string id);
        void SaveAsync();
        void Save();
        
    }
}
