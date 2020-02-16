using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WordBook.Models
{
    public class Word
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Word")]
        public string Name { get; set; }

        public List<WordDefinition> Definitions { get; set; }

        public string Pronunciation { get; set; }

        public byte[] Image { get; set; }
    }
}