namespace org.igrok.validator
{
    internal class VatAlphaSpecialCharacter : IVatSpecialCharacter
    {
        private int _position;
        private int _length;

        public VatAlphaSpecialCharacter(int position)
        {
            _position = position;
            _length = -1;
        }

        public VatAlphaSpecialCharacter(int position, int length)
        {
            _length = length;
        }

        public bool CharacterPositionValid(string nbPart)
        {
            return char.IsLetter(nbPart[_position]);
        }

        public bool CharacterPositionValid(string nbPart, int length)
        {
            return char.IsLetter(nbPart[_position])&& length == _length;
        }
    }
}
