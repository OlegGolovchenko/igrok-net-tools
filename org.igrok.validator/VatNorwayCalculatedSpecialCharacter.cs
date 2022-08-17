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
namespace org.igrok.validator
{
    internal class VatNorwayCalculatedSpecialCharacter : IVatSpecialCharacter
    {
        public int Position { get; private set; }

        public VatNorwayCalculatedSpecialCharacter(int position)
        {
            Position = position;
        }

        public bool CharacterPositionValid(string nbPart)
        {
            return CalculateModulo(nbPart);
        }

        public bool CharacterPositionValid(string nbPart, int length)
        {
            return CalculateModulo(nbPart);
        }

        private bool CalculateModulo(string nbPart)
        {
            var numbersToValidate = nbPart.Substring(0, 8);
            var controlDigit = nbPart[8].ToString();
            var weights = new int[]{ 3, 2, 7, 6, 5, 4, 3 ,2 };
            var sum = 0;
            var modulo = 0;
            var result = false;
            if(int.TryParse(controlDigit,out int ctrl))
            {
                for(var i = 0; i < 8; i++)
                {
                    var isNumber = int.TryParse(numbersToValidate[i].ToString(),out int crntDgt);
                    var prod = crntDgt * weights[i];
                    sum += prod;
                }
                modulo = sum % 11;
                result = ctrl == (11 - modulo);
            }
            return result;
        }
    }
}
