namespace FlexBook.Application.Common.Interfaces;
public interface IAccountService
{
     Task<string> GetHashString(string inputString);
}
