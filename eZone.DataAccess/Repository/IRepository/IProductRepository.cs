using eZone.Models;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eZone.DataAccess.Repository.IRepository
{
    public interface IProductRepository : IRepository<Product>
    {
       
        void Update(Product obj);
        //void Save();
    }
}
