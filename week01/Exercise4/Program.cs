using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<int> numbers = new List<int>();
        int input;

        
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        do
        {
            Console.Write("Enter number: ");
            input = int.Parse(Console.ReadLine());
            
            if (input != 0)
                numbers.Add(input);

        } while (input != 0);

        
        int sum = 0;
        foreach (int num in numbers)
        {
            sum += num;
        }
        
        double average = (double)sum / numbers.Count;
        int largest = int.MinValue;
        foreach (int num in numbers)
        {
            if (num > largest)
                largest = num;
        }

        
        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {largest}");

        
        int smallestPositive = int.MaxValue;
        foreach (int num in numbers)
        {
            if (num > 0 && num < smallestPositive)
                smallestPositive = num;
        }

        numbers.Sort();

        
        Console.WriteLine($"The smallest positive number is: {smallestPositive}");
        Console.WriteLine("The sorted list is:");
        foreach (int num in numbers)
        {
            Console.WriteLine(num);
        }
    }
}
