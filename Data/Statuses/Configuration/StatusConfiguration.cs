using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace space_colonization_api.Data.Statuses.Configuration
{
    public class StatusConfiguration : IEntityTypeConfiguration<Status>
    {
        public void Configure(EntityTypeBuilder<Status> builder)
        {
            builder.HasKey(x => x.StatusId);
            builder.HasData(
                    new Status { StatusId = 1, Name = "OK" },
                    new Status { StatusId = 2, Name = "!OK" },
                    new Status { StatusId = 3, Name = "!TODO" },
                    new Status { StatusId = 4, Name = "!En route" }
                );
        }
    }
}
