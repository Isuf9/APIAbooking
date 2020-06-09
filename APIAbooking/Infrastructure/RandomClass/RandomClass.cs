using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIAbooking.Infrastructure.RandomClass
{
    public class RandomClass
    {
        
        public int generateIdRandom(int? id)
        {
            Random random = new Random();

             id = random.Next(1, 100);
                return (int)id;
        }

        //public int Next(int value)
        //{
        //    return value;
        //}

      
    }
}
