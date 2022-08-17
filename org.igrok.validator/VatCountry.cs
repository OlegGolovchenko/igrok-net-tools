//###########################################################################################################
//    Igrok-Net validators
//    Copyright(C) 2017  Oleg Golovchenko
//
//    This program is free software: you can redistribute it and/or modify
//    it under the terms of the GNU General Public License as published by
//    the Free Software Foundation, either version 3 of the License, or
//    (at your option) any later version.
//
//    This program is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//    GNU General Public License for more details.
//
//    You should have received a copy of the GNU General Public License
//    along with this program.  If not, see <https://www.gnu.org/licenses/>.
//###########################################################################################################
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
