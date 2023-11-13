using Rte2023Ddd.Domain.TmsContext.Entities;
using Rte2023Ddd.Domain.TmsContext.Interfaces.Repositories;

namespace Rte2023Ddd.Infra.Data.Contexts.TmsDb.Repositories;

public class AddressRepository :
    TmsRepository<Address>,
    IAddressRepository
{
    public AddressRepository(TmsDbContext context) : base(context)
    {
    }
}
