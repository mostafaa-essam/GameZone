namespace GameZone.Models
{
    public class Category:Base
    {


        //Navigation
        public ICollection<Game> Games { get; set;}=new List<Game>();
    }
}
