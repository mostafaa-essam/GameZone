namespace GameZone.Models
{
    public class Game:Base
    {

        public string Description { get; set; }=string.Empty;

        public string Cover { get; set; } = string.Empty;
        //FK
        public int CategoryId { get; set; }
        //Navigation Prop
        public Category Category { get; set; }=default!;
        public ICollection<GameDevice> GameDevices { get; set; }=new List<GameDevice>();


    }
}
