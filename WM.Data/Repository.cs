using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WM.Bussiness.Interfaces;

namespace WM.Data
{
    public abstract class Repository<TEntity> : IRepository<TEntity>
    {
        public void Dispose()
        {
           
        }
    }
}
