using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EK7TKN_HFT_2021221.Repository
{
    public abstract class AbstractRepository<T> 
    {
        protected DbContext context;
        public AbstractRepository(DbContext dbContext)
        {
            this.context = dbContext;
        }

    }
}
