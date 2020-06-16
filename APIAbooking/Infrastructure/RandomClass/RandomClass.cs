using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIAbooking.Infrastructure.RandomClass
{
    public class RandomClass
    {
      
        
        public string generateIdRandom(string? id)
        {
             var guid = Guid.NewGuid().ToString();
             id = guid;
           
             return id;
        }

        //public int Next(int value)
        //{
        //    return value;
        //}

      
    }
}
