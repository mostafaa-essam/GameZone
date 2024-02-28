
namespace GameZone.Configurations
{
    public class DeviceConfigurations : IEntityTypeConfiguration<Device>
    {
        public void Configure(EntityTypeBuilder<Device> builder)
        {
           builder.HasKey(d => d.Id);
           builder.Property(d => d.Name)
                   .HasMaxLength(256);
           builder.Property(d=>d.Icon)
                .HasMaxLength(50);
        }
    }
}
