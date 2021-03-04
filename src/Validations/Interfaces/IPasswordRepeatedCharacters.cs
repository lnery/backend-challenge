namespace Validations.Interfaces
{
    public interface IPasswordRepeatedCharacters : IValidation
    {
        bool ContainsRepeatedCharacters();
    }
}
