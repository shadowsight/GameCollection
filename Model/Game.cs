using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GameCollection.Model
{
    public class Game
    {
        public int Id { get; set; }

        [Required, StringLength(80)]
        public string Title { get; set; }

        [Required, StringLength(80)]
        public string Genre { get; set;  }

        [Required, StringLength(80)]
        public string System { get; set; }
    }
}
