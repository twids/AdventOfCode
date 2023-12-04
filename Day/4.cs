using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic;

namespace AdventOfCode;
public class App4()
{
    public static void Run1()
    {
        var lines = File.ReadAllLines(@"C:\dev\AdventOfCode\input\4.1");
        var count = 0;
        foreach (var line in lines)
        {
            var points = 0;
            string regexPattern = @"Card\s+\d{1,3}: ";
            var game = Regex.Match(line, regexPattern).Groups[0].Value;
            var trimmedLine = Regex.Replace(line, regexPattern, "");
            var cardStr = trimmedLine.Trim().Split(['|']);

            var winningCards = cardStr[0].Trim().Split(" ").Where(s => !string.IsNullOrEmpty(s)).ToHashSet();
            var myCards = cardStr[1].Trim().Split(" ").Where(s => !string.IsNullOrEmpty(s)).ToHashSet();

            var win = myCards.Intersect(winningCards);

            if (win.Any()) points = (int)Math.Pow(2, win.Count() - 1);

            count += points;
            Console.WriteLine($"{game}: WinCount: {win.Count()}, GamePoints: {points}, TotalPoints: {count}, Winning Cards: {string.Join(", ", win.ToList())}");

        }
        Console.WriteLine(count);
    }

    public static void Run2()
    {
        var lines = File.ReadAllLines(@"C:\dev\AdventOfCode\input\4.1");
        var count = 0;
        Dictionary<int, int> sCards = [];

        //Init dictionary
        for (var i = 1; i <= lines.Length; i++) sCards.Add(i, 1);

        foreach (var line in lines)
        {
            string regexPattern = @"Card\s+(\d{1,3}): ";
            var gameNo = int.Parse(Regex.Match(line, regexPattern).Groups[1].Value);
            var trimmedLine = Regex.Replace(line, regexPattern, "");
            var cardStr = trimmedLine.Trim().Split(['|']);

            var noGames = sCards[gameNo];

            while (noGames > 0)
            {

                var winningCards = cardStr[0].Trim().Split(" ").Where(s => !string.IsNullOrEmpty(s)).ToHashSet();
                var myCards = cardStr[1].Trim().Split(" ").Where(s => !string.IsNullOrEmpty(s)).ToHashSet();
                var win = myCards.Intersect(winningCards);
                for (var k = 1; k <= win.Count(); k++)
                {
                    sCards[gameNo + k]++;
                }
                noGames--;
            }
        }
        foreach (var kvp in sCards)
        {
            Console.WriteLine("Key : " + kvp.Key.ToString() + ", Value : " + kvp.Value);
            count += kvp.Value;
        }
        Console.WriteLine($"Total: {count}");
    }
}