namespace GameZone.Models
{
    public class Device:Base
    {
        public string Icon { get; set; } = string.Empty;
        public ICollection<GameDevice> GameDevices { get; set; } = new List<GameDevice>();

    }
}
