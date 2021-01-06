using OWN.Repository.Tables;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OWN.Service
{
    public interface IAddressService : IBaseService
    {
        Task<IList<Address>> GetAll(int? pageNumber);
    }
}
