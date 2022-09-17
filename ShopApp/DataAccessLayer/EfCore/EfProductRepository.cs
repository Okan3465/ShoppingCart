using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EfCore
{
  public  class EfProductRepository:GenericRepository<Product>,IProductDal
    {
        public EfProductRepository(Context context):base(context)
        {

        }
        
        
    }
}
