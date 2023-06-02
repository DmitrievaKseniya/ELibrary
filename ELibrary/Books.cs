using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELibrary
{
    public class Books
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public int? UserId { get; set; }
        public Users? User { get; set; }
    }
}
