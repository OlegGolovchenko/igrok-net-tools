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
