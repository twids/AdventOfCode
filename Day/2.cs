using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic;

namespace AdventOfCode;
public class App2()
{
    public static void Run1()
    {

        var lines = File.ReadAllLines("/home/twids/dev/AdventOfCode/input/2.1");
        var c = new Dictionary<string,int> {
            {"red", 12},
            {"green", 13},
            {"blue", 14}
        };
        var count=0;
        var gameNo=1;
        foreach (var line in lines)
        {
            string regexPattern = @"Game \d{1,3}: ";
            var trimmedLine = Regex.Replace(line, regexPattern, "");
            var cubeStr = trimmedLine.Split([';',',']);

            bool a = cubeStr.Select(o => {
                var m = Regex.Match(o, "(\\d{1,2}) ([a-z]*)");
                return c[$"{m.Groups[2]}"] >= int.Parse(m.Groups[1].Value);
            }).All(b => b is true);
            Console.WriteLine($"{gameNo}: {a}");
            
            count+=(a ? gameNo : 0);
            gameNo++;
        }
        Console.WriteLine($"{count}");
    }
    public static void Run2()
    {
        var lines = File.ReadAllLines("/home/twids/dev/AdventOfCode/input/2.1");
        var count=0;
        var gameNo=1;
        foreach (var line in lines)
        {
            string regexPattern = @"Game \d{1,3}: ";
            var trimmedLine = Regex.Replace(line, regexPattern, "");
            var cubeStr = trimmedLine.Split([';',',']);
            var c = new Dictionary<string,int> {
                        {"red", 0},
                        {"green", 0},
                        {"blue", 0}
                    };
                    
            foreach (var o in cubeStr) {
                var m = Regex.Match(o, "(?<count>\\d{1,2}) (?<color>[a-z]*)");
                var color = m.Groups["color"].Value;
                var amount = int.Parse(m.Groups["count"].Value);
                c[color] = c[color] < amount ? amount : c[color];
            }

            Console.WriteLine($"{gameNo}: {c.ToOutput()}");
            
            count+=c["red"]*c["green"]*c["blue"];
            gameNo++;
        }
        Console.WriteLine($"{count}");
    }
}