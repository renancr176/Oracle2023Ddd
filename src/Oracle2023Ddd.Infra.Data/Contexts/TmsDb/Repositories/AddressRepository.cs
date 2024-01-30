using Oracle2023Ddd.Domain.TmsContext.Entities;
using Oracle2023Ddd.Domain.TmsContext.Interfaces.Repositories;

namespace Oracle2023Ddd.Infra.Data.Contexts.TmsDb.Repositories;

public class AddressRepository :
    TmsRepository<Address>,
    IAddressRepository
{
    public AddressRepository(TmsDbContext context) : base(context)
    {
    }
}
