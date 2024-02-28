
namespace GameZone.Configurations
{
    public class GameDeviceConfigurations : IEntityTypeConfiguration<GameDevice>
    {
        public void Configure(EntityTypeBuilder<GameDevice> builder)
        {
            builder.HasKey(g => new
            {
                g.GameId,g.DevicId
            });
        }
    }
}
