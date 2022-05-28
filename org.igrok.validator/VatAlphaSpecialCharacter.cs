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
