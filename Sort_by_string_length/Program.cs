using System;

class Program
{
    static string[] SortByStringLength(string[] array)
    {
        for (int i = 1; i < array.Length; i++)
        {
            string swap = array[i];

            int prevIndex = i - 1;
            while (prevIndex >= 0 && swap.Length < array[prevIndex].Length)
            {
                array[prevIndex + 1] = array[prevIndex];
                prevIndex--;
            }
            array[prevIndex + 1] = swap;
        }

        return array;
    }

    static void Main(string[] args)
    {
        string[] arrayOfStrings = { "12345678", "12345678910", "1234", "1234567891011", "0123456789101112", "123456789", "12345678910111213141516", "123456789", "123456789101112", "12" };

        SortByStringLength(arrayOfStrings);

        // Array.Sort(arrayOfStrings, (a, b) => a.Length - b.Length);

        foreach (string str in arrayOfStrings)
        {
            Console.Write(str + "\t");
        }

        Console.WriteLine();

    }
}

/*
Description
You are given an array of strings. Write a method that sorts the array by the length of its elements (the number of characters composing them).
*/