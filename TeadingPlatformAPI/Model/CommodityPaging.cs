using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class CommodityPaging
    {
        public int PagingPagIndex { get; set; }

        public int PagingSize { get; set; }

        public List<CommodityInfo> GetInfos { get; set; }
    }
}
