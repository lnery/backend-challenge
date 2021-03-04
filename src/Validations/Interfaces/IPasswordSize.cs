namespace Validations.Interfaces
{
    public interface IPasswordSize : IValidation
    {
        int GetQuantityOfCharacters();
    }
}
