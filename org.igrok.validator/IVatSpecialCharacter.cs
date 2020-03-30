namespace org.igrok.validator
{
    internal interface IVatSpecialCharacter
    {
        bool CharacterPositionValid(string nbPart);
        bool CharacterPositionValid(string nbPart, int length);
    }
}
