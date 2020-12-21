using OWN.Repository;
using OWN.Repository.Tables;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace OWN.Service
{
    public class AddressService : IAddressService
    {
        //private readonly ApplicationDbContext _context;
        ////private readonly DbSet<Address> tAddress;

        //public AddressService(ApplicationDbContext context)
        //{
        //    _context = context;
        //    //tAddress = _context.Set<Address>();
        //}

        //public async Task<IList<Address>> GetAll()
        //{
        //    var addresses = await _context.Address.ToListAsync();
        //    return addresses;
        //    //var addresses = tAddress.GetAll();
        //}

        private readonly IRepositoryBase<Address> _addressRepo;

        public AddressService(IRepositoryBase<Address> addressRepo)
        {
            _addressRepo = addressRepo;
        }

        public async Task<IList<Address>> GetAll()
        {
            return await _addressRepo.GetAll();
        }
    }
}
