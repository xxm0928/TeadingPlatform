using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Model;

namespace BLL
{
    public class YxBll
    {
        YxDal YxDal = new YxDal();
        public UnitedReturn OrderShow(object data)
        {
            return YxDal.OrderShow(data);
        }
    }
}
