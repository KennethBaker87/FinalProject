using FinalProject.Controllers;
using System.Text;

namespace FinalProject.Models
{
    public class SegaSaturn
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Developer { get; set; }
        public string Publisher { get; set; }
        public string Genre { get; set; }
        public string Raiting { get; set; }
        public int NumberOfPlayers { get; set; }
        public string ReleaseDate { get; set; }
        public byte[] BoxArt { get; set; }
        public IEnumerable<Category> Categories { get; set; }

        
    }
    
    
    
}
