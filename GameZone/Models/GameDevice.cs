namespace GameZone.Models
{
    public class GameDevice
    {
        public int GameId { get; set; }
        public int DevicId { get; set; }

        //Navigation:-
        public Game Game { get; set; } = default!;
        public Device Device { get; set; }=default!;
    }
}
