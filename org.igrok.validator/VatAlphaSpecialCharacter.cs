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
using System.Linq;

namespace org.igrok.validator
{
    internal class VatAlphaSpecialCharacter : IVatSpecialCharacter
    {
        private int _position;
        private int _length;
        private int[] _otherPositions;

        public VatAlphaSpecialCharacter(int position)
        {
            _position = position;
            _length = -1;
            _otherPositions = null;
        }

        public VatAlphaSpecialCharacter(int position, int length) : this(position)
        {
            _length = length;
        }

        public VatAlphaSpecialCharacter(int position, int[] otherPositions, int length) : this(position, length)
        {
            _otherPositions = otherPositions;
        }

        public bool CharacterPositionValid(string nbPart)
        {
            var result = false;
            if(_position < nbPart.Length)
            {
                result = char.IsLetter(nbPart[_position]);
                if (_length > 0)
                {
                    result &= nbPart.Length == _length;
                }
                if (_otherPositions != null)
                {
                    foreach (int position in _otherPositions)
                    {
                        result &= char.IsLetter(nbPart[position]);
                    }
                    for (int i = 0; i < nbPart.Length; i++)
                    {
                        if (i != _position && !_otherPositions.Contains(i))
                        {
                            result &= !char.IsLetter(nbPart[i]);
                        }
                    }
                }
            }
            return result;
        }
    }
}
