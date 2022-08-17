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
    internal class VatSpecialCharacter : IVatSpecialCharacter
    {
        public char Character { get; private set; }
        public int Position { get; private set; }
        public int Length { get; private set; }

        public VatSpecialCharacter(char character, int position)
        {
            Character = character;
            Position = position;
        }

        public VatSpecialCharacter(char character, int position, int length)
        {
            Character = character;
            Position = position;
            Length = length;
        }

        public virtual bool CharacterPositionValid(string nbPart)
        {
            return nbPart[Position] == Character;
        }

        public bool CharacterPositionValid(string nbPart, int length)
        {
            return nbPart[Position] == Character && length == Length;
        }
    }
}
