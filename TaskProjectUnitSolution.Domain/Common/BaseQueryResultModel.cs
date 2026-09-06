using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewtonAffendi.Course.Domain.Common
{
    public class BaseQueryResultModel<T>
    {
        public List<T> Items { get; set; }
        public int TotalCount { get; set; }
        public BaseQueryResultModel(List<T> items, int count)
        {
            TotalCount = count;
            Items = items;
        }
    }
}
