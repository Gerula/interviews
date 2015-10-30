// https://www.reddit.com/r/dailyprogrammer/comments/3qjnil/20151028_challenge_238_intermediate_fallout/
//
// The popular video games Fallout 3 and Fallout:
// New Vegas have a computer "hacking" minigame where the player must correctly guess the correct password from a list of same-length words.
// Your challenge is to implement this game yourself.
//

using System;
using System.IO;
using System.Linq;

class Game
{
    public enum Difficulty
    {
        VeryEasy,
        Easy,
        Average,
        Hard,
        VeryHard
    }

    class GameData
    {
        public int WordCount;
        public int WordSize;
    }

    private int Tries { get; set; }
    private String Words { get; set; }
    private String PassWord { get; set; }

    public Game(Difficulty difficulty)
    {
        LoadWords(GetGameDataPerDifficulty(difficulty));
        Tries = 4;
    }

    private void LoadWords(GameData gameData)
    {
        var words = File.
                        ReadLines("/usr/share/dict/words").
                        Where(x => x.Length == gameData.WordSize).
                        Take(gameData.WordCount).
                        Select(y => y.ToUpper()).
                        ToArray();

        var random = new Random();
        PassWord = words[random.Next(words.Length)];
        Words = String.Join(Environment.NewLine, words);
    }

    private GameData GetGameDataPerDifficulty(Difficulty difficulty)
    {
        switch (difficulty)
        {
            case Difficulty.VeryEasy: return new GameData { WordCount = 5, WordSize = 4};
            case Difficulty.Easy: return new GameData { WordCount = 7, WordSize = 7};
            case Difficulty.Average: return new GameData { WordCount = 10, WordSize = 10};
            case Difficulty.Hard: return new GameData { WordCount = 12, WordSize = 12};
            case Difficulty.VeryHard: return new GameData { WordCount = 15, WordSize = 15};
        }

        return null;
    }

    private static int Distance(String first, String second)
    {
        if (first.Length != second.Length)
        {
            return -1;
        }
        
        return first.
                Zip(second, (x, y) => x == y).
                Count(z => z);
    }

    public void Run()
    {
        Console.WriteLine(Words);

        while (Tries > 0) 
        {
            Console.Write("Guess ({0} left)? ", Tries--);
            var result = Distance(PassWord, Console.ReadLine());
            if (result < 0)
            {
                Console.WriteLine("No!");
                continue;
            }
            
            if (result == PassWord.Length)
            {
                Console.WriteLine("You win");
                return;
            }

            Console.WriteLine("{0}/{1} Correct", result, PassWord.Length);
        }
    }

    static void Main()
    {
        new Game(Difficulty.Easy).Run();
    }
}
