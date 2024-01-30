using Microsoft.EntityFrameworkCore;
using Oracle2023Ddd.Infra.Data.Contexts.TmsDb.Mappings;

namespace Oracle2023Ddd.Infra.Data.Contexts.TmsDb
{
    public static class TmsDbContextSequences
    {
        public static ModelBuilder AddSequences(this ModelBuilder builder)
        {
            builder.HasSequence<int>(AddressMapping._sequenceName)
                .StartsAt(1)
                .IncrementsBy(1)
                .HasMax(int.MaxValue);

            builder.HasSequence<int>(CustomerMapping._sequenceName)
                .StartsAt(1)
                .IncrementsBy(1)
                .HasMax(int.MaxValue);

            builder.HasSequence<int>(PersonMapping._sequenceName)
            .StartsAt(1)
            .IncrementsBy(1)
            .HasMax(int.MaxValue);

            return builder;
        }
    }
}
