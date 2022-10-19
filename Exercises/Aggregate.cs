using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercises
{
    public static class Aggregate
    {
        //Coding Exercise 1
        /*
        Imagine you are working on an activity tracker app. On the main screen, 
        we want to show the user the total activity time for the current day.

        Using the Aggregate method, implement the TotalActivityDuration method, 
        which given a collection of integers representing activities durations 
        in seconds will return a TimeSpan object representing the total time of activity.

        For example, for durations {10, 50, 121} the result shall be a TimeSpan 
        object with a total duration of 3 minutes and 1 second.
         */
        public static TimeSpan TotalActivityDuration(
            IEnumerable<int> activityTimesInSeconds)
        {
            return activityTimesInSeconds.Aggregate(
                new TimeSpan(), (totalTimeSpan, activitySeconds) =>
                totalTimeSpan.Add(TimeSpan.FromSeconds(activitySeconds)));
        }

        //Coding Exercise 2
        /*
         Using LINQ's Aggregate method implement the PrintAlphabet method which given 
        a count (assume it's from 1 to 26) will return a string with this count 
        of letters starting with 'a'.

        For example:
            *For count 5 it will return "a,b,c,d,e"
            *For count 3 it will return "a,b,c"
            *For count 1 it will return "a"
        
        For count less than 1 or more than 26 it will throw ArgumentException
         */
        public static string PrintAlphabet(int count)
        {
            if (count < 1 || count > 26)
            {
                throw new ArgumentException($"'{nameof(count)}' must be beetween 1 and 26");
            }

            return Enumerable.Range(1, count - 1).Aggregate(
                "a",
                (accumulated, index) =>
                $"{accumulated},{(char)('a' + index)}");
        }

        //Refactoring challenge
        //TODO implement this method
        public static IEnumerable<int> Fibonacci_Refactored(int n)
        {
            if (n < 1)
            {
                throw new ArgumentException(
                    $"Can't generate Fibonacci sequence " +
                    $"for {n} elements. N must be a " +
                    $"positive number");
            }

            if (n == 1)
            {
                return new[] { 0 };
            }
            return Enumerable.Range(1, n - 2)
                .Aggregate(
                new List<int> { 0, 1 } as IEnumerable<int>,
                (sequence, nextIndex) => sequence.Append(
                    sequence.ElementAt(nextIndex - 1) +
                    sequence.ElementAt(nextIndex)));
        }

        //do not modify this method
        public static IEnumerable<int> Fibonacci(int n)
        {
            if (n < 1)
            {
                throw new ArgumentException(
                    $"Can't generate Fibonacci sequence " +
                    $"for {n} elements. N must be a " +
                    $"positive number");
            }

            if (n == 1)
            {
                return new[] { 0 };
            }
            var result = new List<int> { 0, 1 };
            for (int i = 1; i < n - 1; ++i)
            {
                result.Add(result[i - 1] + result[i]);
            }
            return result;
        }
    }
}
