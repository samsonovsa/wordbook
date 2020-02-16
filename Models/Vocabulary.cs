using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WordBook.Models
{
    public class Vocabulary
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int User { get; set; }

        public List<Word> Words { get; set; }
    }
}