using Microsoft.EntityFrameworkCore;
using Rte2023Ddd.Infra.Data.Contexts.TmsDb.Mappings;

namespace Rte2023Ddd.Infra.Data.Contexts.TmsDb
{
    public static class TmsDbContextSequences
    {
        public static ModelBuilder AddSequences(this ModelBuilder builder)
        {
            builder.HasSequence<int>(PersonMapping._sequenceName)
            .StartsAt(1)
            .IncrementsBy(1)
            .HasMax(int.MaxValue);

            builder.HasSequence<int>(AddressMapping._sequenceName)
            .StartsAt(1)
            .IncrementsBy(1)
            .HasMax(int.MaxValue);

            return builder;
        }
    }
}
