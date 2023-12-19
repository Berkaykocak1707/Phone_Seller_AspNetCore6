using DataAccess.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _context;
        private IPhoneRepository _phoneRepository;
        private IBrandRepository _brandRepository;
        private IOrderRepository _orderRepository;
        private IPhoneRatingRepository _ratingRepository;

        public RepositoryManager(RepositoryContext context, IPhoneRepository phoneRepository,
                                 IBrandRepository brandRepository,
                                 IOrderRepository orderRepository, IPhoneRatingRepository priceRepository)
        {
            _context = context;
            _phoneRepository = phoneRepository;
            _brandRepository = brandRepository;
            _orderRepository = orderRepository;
            _ratingRepository = priceRepository;
        }

        public IPhoneRepository Phone => _phoneRepository;

        public IBrandRepository Brand => _brandRepository;

        public IOrderRepository Order => _orderRepository;

        public IPhoneRatingRepository phoneRatingRepository => _ratingRepository;

        public void Save()
        {
            _context.SaveChanges();
        }
    }

}
