namespace RandomNumbers.Services;

public class RandomNumber : IRandomNumber
{
    private readonly Random _random = new Random();
    private int? _targetNumber = null;
    private int  _numberOfGuesses = 0;
    public Task ChooseNewNumber(int min, int max)
    {
        _targetNumber = _random.Next(min, max + 1);
        _numberOfGuesses = 0;
        return Task.CompletedTask;  
    }

    public string TryGuessNumber(int guess)
    {
        _numberOfGuesses++;
        if (!_targetNumber.HasValue)
        {
            return "No number has been chosen yet. Please choose a number first.";
        }
        if (guess < _targetNumber)
        {
            return "Your guess is too low.";
        }
        else if (guess > _targetNumber)
        {
            return "Your guess is too high.";
        }
        else
        {
            return $"Congratulations! You've guessed the number! in {_numberOfGuesses} tries";
        }
    }
}
