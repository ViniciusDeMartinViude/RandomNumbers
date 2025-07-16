namespace RandomNumbers.Services;

public interface IRandomNumber
{
    public Task ChooseNewNumber(int min, int max);
    public string TryGuessNumber(int guess);
}
