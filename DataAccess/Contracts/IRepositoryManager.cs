using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Contracts
{
    public interface IRepositoryManager
    {
        IPhoneRepository Phone
        {
            get;
        }
        IBrandRepository Brand
        {
            get;
        }
        IOrderRepository Order
        {
            get;
        }
        IPhoneRatingRepository phoneRatingRepository
        {
        get; }

        void Save();
    }
}
