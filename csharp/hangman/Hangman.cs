using System.Collections.Immutable;
using System.Reactive.Linq;
using System.Reactive.Subjects;
public class HangmanState
{
    public string MaskedWord { get; }
    public ImmutableHashSet<char> GuessedChars { get; }
    public int RemainingGuesses { get; }
    public bool IsGameOver { get; }

    public HangmanState(string maskedWord, ImmutableHashSet<char> guessedChars, int remainingGuesses,bool isGameOver = false)
    {
        MaskedWord = maskedWord;
        GuessedChars = guessedChars;
        RemainingGuesses = remainingGuesses;
        IsGameOver = isGameOver;
    }
}

public class TooManyGuessesException : Exception
{
    public TooManyGuessesException() : base("Too many guesses") { }
}

public class Hangman
{
    private readonly string _word; 
    private readonly BehaviorSubject<HangmanState> _stateSubject;
    private readonly Subject<char> _guessSubject;// ulaz za pokušaje 

    public IObservable<HangmanState> StateObservable => _stateSubject.AsObservable();
    public IObserver<char> GuessObserver => _guessSubject;

  
    public Hangman(string word)
    {
        _word = word ?? throw new ArgumentNullException(nameof(word));;
        
        var initialState = new HangmanState(
        new string('_',word.Length),
        ImmutableHashSet<char>.Empty,
        9 
            );

        _stateSubject = new BehaviorSubject<HangmanState>(initialState);
        _guessSubject = new Subject<char>();
        _guessSubject.Subscribe(ProcessGuess);
        
        
    }
    private void ProcessGuess(char guess)
    {
        var state = _stateSubject.Value;
        
        if (!state.MaskedWord.Contains('_')) return;
        if (state.RemainingGuesses <= 0)
        {
            _stateSubject.OnError(new TooManyGuessesException());
            return;
        }


        if (state.GuessedChars.Contains(guess))
        {
            var repeatedState = new HangmanState(
            state.MaskedWord,
            state.GuessedChars,
            state.RemainingGuesses -1
            );
            EmitOrEnd(repeatedState);
             return;
        }
        var newGuessed = state.GuessedChars.Add(guess);// dodaje nov slovo u listu.
        if (_word.Contains(guess))
        {
            var newMasked = new string(_word.Select(c => newGuessed.Contains(c) ? c : '_').ToArray());
            bool isOver = !newMasked.Contains('_');
            int remaining = state.RemainingGuesses;

            // Ako je pogrešan pokušaj
            if (!_word.Contains(guess))
                remaining--;
            var nextState = new HangmanState(newMasked, newGuessed, state.RemainingGuesses,isOver);
            _stateSubject.OnNext(nextState);

            if (isOver)
            {
                _stateSubject.OnCompleted();
            }
            if (remaining == 0)
            {
                _stateSubject.OnError(new TooManyGuessesException());
            }
            else if (!newMasked.Contains('_'))
            {
                _stateSubject.OnCompleted();
            }
        }
        else
        {
            var nextState = new HangmanState(
                state.MaskedWord,
                newGuessed,
                state.RemainingGuesses-1,
                    (state.RemainingGuesses - 1) == 0
            );
            EmitOrEnd(nextState);
        }
    }

    private void EmitOrEnd(HangmanState nextState)
    {
        
        if (nextState.RemainingGuesses == 0)
        {
            _stateSubject.OnNext(nextState);
            _stateSubject.OnError(new TooManyGuessesException());
        }
        else
        {
            _stateSubject.OnNext(nextState);
        }
    }
}