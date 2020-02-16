using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WordBook.Models
{
    public enum PartOfSpeech
    {
        Noun, 
        Pronoun,        // A pronoun is a word used in place of a noun.She... we... they... it
        Verb,
        Adjective,      // An adjective modifies or describes a noun or pronoun.
        Adverb,         // An adverb modifies or describes a verb, an adjective, or another adverb. gently... extremely... carefully... well
        Preposition,    // A preposition is a word placed before a noun or pronoun to form a phrase modifying another word in the sentence. by... with.... about... until
        Conjunction,    // A conjunction joins words, phrases, or clauses. and... but... or... while... because
        Interjunction   // An interjection is a word used to express emotion.Oh!... Wow!... Oops!
    }
}