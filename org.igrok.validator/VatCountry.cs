using System.Collections.Generic;
using System.Linq;

namespace org.igrok.validator
{
    internal class VatCountry
    {
        public string Code { get; set; }
        public List<int> Lengths { get; set; }
        public List<IVatSpecialCharacter> SpecialCharacters { get; set; }
        public string ExcludedCharacters { get; set; }
        
        public bool ValidateLength(string nbPart)
        {
            return Lengths.Any(e=>e == nbPart.Length);
        }

        public bool ValidateSpecialCharacters(string nbPart)
        {
            return SpecialCharacters.Count == 0 ? true : SpecialCharacters.
                Any(e => e.CharacterPositionValid(nbPart));
        }

        public bool ValidateExcludedCharacters (string nbPart)
        {
            return ExcludedCharacters == "alpha" ? !nbPart.ToCharArray().
                Any(e => char.IsLetter(e)) : !nbPart.ToCharArray().
                Any(e => ExcludedCharacters.ToCharArray().Any(ch => ch == e));
        }
    }
}
