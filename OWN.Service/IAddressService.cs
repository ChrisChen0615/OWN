using OWN.Repository.Paging;
using OWN.Repository.Tables;
using OWN.Service.Paging.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OWN.Service
{
    public interface IAddressService : IBaseService
    {
        DtResult<Address> GetAll(PagingQueryDto input);
    }
}
