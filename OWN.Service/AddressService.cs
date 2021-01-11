using OWN.Repository;
using OWN.Repository.Tables;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using OWN.Repository.Paging;
using Microsoft.EntityFrameworkCore;

namespace OWN.Service
{
    public class AddressService : IAddressService
    {
        private readonly IRepositoryBase<Address> _addressRepo;

        public AddressService(IRepositoryBase<Address> addressRepo)
        {
            _addressRepo = addressRepo;
        }

        //public async Task<IList<Address>> GetAll(int? pageNumber)
        //{
        //    var data = _addressRepo.GetAll().OrderBy(d => d.CountryRegion);
        //    int pageSize = 10;
        //    var result = await PaginatedList<Address>.CreateAsync(data.AsNoTracking(), pageNumber ?? 1, pageSize);
        //    return result;
        //}

        public async Task<IList<Address>> GetAll(int? pageNumber)
        {
            var data = _addressRepo.GetAll().OrderBy(d => d.CountryRegion);
            return data.ToList();
        }
    }
}
