
namespace GameZone.Configurations
{
    public class GameConfigurations : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder.HasKey(g => g.Id);
            builder.Property(g => g.Name)
                .HasMaxLength(250);
            builder.Property(g => g.Description)
                    .HasMaxLength(500);
          
        }
       
    }
}
