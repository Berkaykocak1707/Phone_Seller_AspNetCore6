using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.RequestParameters
{
    public class OrderRequestParameters : RequestParameters
    {
        public string UserId
        {
            get; set; 
        }
        public int PageNumber
        {
            get; set;
        }
        public int PageSize
        {
            get; set;
        }
        public OrderRequestParameters() : this(1, 5)
        {

        }
        public OrderRequestParameters(int pageNumber = 1, int pageSize = 5)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }

    }
}
