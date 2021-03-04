using OWN.Repository;
using OWN.Repository.Paging;
using OWN.Repository.Tables;
using OWN.Service.Paging.Dto;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OWN.Service
{
    public class AddressService : IAddressService
    {
        private readonly IRepositoryBase<Address> _addressRepo;

        public AddressService(IRepositoryBase<Address> addressRepo)
        {
            _addressRepo = addressRepo;
        }

        public DtResult<Address> GetAll(PagingQueryDto input)
        {
            var query = _addressRepo.GetAll();
            if (!string.IsNullOrWhiteSpace(input.City))
            {
                query = query.Where(q => q.City == input.City);
            }

            var filteredResultsCount = query.Count();
            var totalResultsCount = query.Count();

            var result = new DtResult<Address>
            {
                Draw = input.Draw,
                RecordsTotal = totalResultsCount,
                RecordsFiltered = filteredResultsCount,
                Data = query
                    .Skip(input.Start)
                    .Take(input.Length)
                    .ToList()
            };
            return result;
        }

        public List<Address> GetAllList(PagingQueryDto input)
        {
            var query = _addressRepo.GetAll();
            if (!string.IsNullOrWhiteSpace(input.City))
            {
                query = query.Where(q => q.City == input.City);
            }

            //var filteredResultsCount = query.Count();
            //var totalResultsCount = query.Count();

            //var result = new DtResult<Address>
            //{
            //    Draw = input.Draw,
            //    RecordsTotal = totalResultsCount,
            //    RecordsFiltered = filteredResultsCount,
            //    Data = query
            //        .Skip(input.Start)
            //        .Take(input.Length)
            //        .ToList()
            //};
            var result = query.ToList();
            return result;
        }
    }
}
