using Oracle2023Ddd.Domain.TmsContext.Entities;
using Oracle2023Ddd.Domain.TmsContext.Interfaces.Repositories;

namespace Oracle2023Ddd.Infra.Data.Contexts.TmsDb.Repositories;

public class PersonRepository :
    TmsRepository<Person>,
    IPersonRepository
{
    public PersonRepository(TmsDbContext context) : base(context)
    {
    }
}
