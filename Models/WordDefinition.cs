using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WordBook.Models
{
    public class WordDefinition
    {
        public int Id { get; set; }
        public List<string> Translate { get; set; }
        public string Definition { get; set; }
        public PartOfSpeech Type { get; set; }
        public List<string> Synonyms { get; set; }
        public List<string> Derivation { get; set;}
        public List<string> Examples { get; set; }
    }
}