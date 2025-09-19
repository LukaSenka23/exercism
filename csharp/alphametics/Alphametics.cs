using System;
using System.Collections.Generic;
using System.Linq;
using Sprache;

public static class Alphametics
{
    private static readonly Parser<string> Word = Parse.Letter.AtLeastOnce().Text();//parsiranje jedne reci kaoja se sastoji od velikih slova.

    private static readonly Parser<List<string>> Expression =
        from first in Word
        from rest in (from plus in Parse.Char('+').Token()// ocekuje plus.
            from word in Word//pa sledecu red.
            select word).Many()//moze da bude vise.
        select new[] { first }.Concat(rest).ToList();//napravi listu svih reci


    private static readonly Parser<(List<string> Left, string Right)> Equation =
        from left in Expression
        from eq in Parse.String("==").Token()
        from right in Word
        select (left, right);
    
    public static IDictionary<char, int> Solve(string equation)
    {
        var parsed = Equation.Parse(equation);// Parsira string "SEND + MORE == MONEY" u strukturu (left, right).
        var letters = equation.Where(char.IsLetter).Distinct().ToArray();//izvalvi sva slova
        var digits = Enumerable.Range(0, 10).ToArray(); // sve cifre 0-9.

        foreach (var p in Permute(digits,letters.Length))
        {
            var map = new Dictionary<char, int>();
            for (int i = 0; i < letters.Length; i++)
                map[letters[i]] = p[i];
            if (Check(parsed, map))
                return map;
        }

        throw new ArgumentException();
    }
    

    static bool Check((List<string> Left, string Right) eq, Dictionary<char, int> map)
    {
        foreach (var word in eq.Left.Append(eq.Right))
        {
            if (map[word[0]] == 0)
                return false; // ignoriši ovu permutaciju
        }
        
        long left = 0;
        foreach (var word in eq.Left)
            left += WordToNum(word, map);

        long right = WordToNum(eq.Right, map);

        return left == right;
    }
    static long WordToNum(string word, Dictionary<char, int> map)
    {
        long n = 0;
        foreach (var c in word)
            n = n * 10 + map[c]; // dodaj cifru za svako slovo
        return n;
    }

    static IEnumerable<int[]> Permute(int[] nums, int k)
    {
        if (k == 1)
        {
            foreach (var n in nums)
                yield return new int[] { n };
        }
        else
        {
            foreach (var p in Permute(nums, k - 1))
            {
                foreach (var n in nums.Except(p))
                {
                    var arr = new int[k];
                    p.CopyTo(arr, 0);   // kopiraj stare cifre
                    arr[k - 1] = n;     // dodaj novu cifru
                    yield return arr;   // vrati novu permutaciju
                } 
            }
        }
    }
}