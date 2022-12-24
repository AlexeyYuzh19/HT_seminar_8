/*
Задача 54: Задайте двумерный массив. 
Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.
Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
В итоге получается вот такой массив:
7 4 2 1
9 5 3 2
8 4 4 2
*/

Console.Clear();
Console.ForegroundColor = ConsoleColor.DarkGray;
Console.WriteLine("Hello, World!");

// Методы

int CheckInputNumber(string Text)
{
    Console.ForegroundColor = ConsoleColor.DarkCyan;

    int number;
    string text;

    while (true)
    {
        Console.Write(Text);
        text = Console.ReadLine();

        if (int.TryParse(text, out number)) break;

        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("Заданное значение числа не соответствует критерию, попробуйте еще раз.");
        Console.ResetColor();
    }
    Console.ResetColor();
    return number;
}

int CheckSize(string text)
{
metka:
    int size = CheckInputNumber(text);

    if (size < 0)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Задано отрицательное значение, попробуйте еще раз.");
        goto metka;
    }
    if (size == 0)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Задано нулевое значение, попробуйте еще раз.");
        goto metka;
    }
    Console.ResetColor();
    return size;
}

void EnterArrayParameter(out int lines, out int columns, out int leftRange, out int rightRange)
{
    lines = CheckSize("Введите количество строк массива : ");

    columns = CheckSize("Введите количество столбцов массива : ");

metka:
    leftRange = CheckInputNumber("Введите величину левого значения (края) массива : ");

    rightRange = CheckInputNumber("Введите величину правого значения (края) массива : ");

    if (leftRange == rightRange)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Значения левого и правого края массива равны, попробуйте еще раз.");
        goto metka;
    }
    if (leftRange > rightRange)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Заданное значение левого края массива больше правого, попробуйте еще раз.");
        goto metka;
    }
    Console.ResetColor();
}

int[,] MakeArray(int lines, int columns, int leftRange, int rightRange)
{
    int[,] array = new int[lines, columns];
    Random rand = new Random();

    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            array[i, j] = rand.Next(leftRange, rightRange);
        }
    }
    return array;
}

void PrintArray(int[,] array)
{
    Console.ForegroundColor = ConsoleColor.DarkGreen;
    System.Console.WriteLine($"\nдвумерный массив размером | {array.GetLength(0)} х {array.GetLength(1)} | :\n");

    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            var ar = String.Format("{0,7}", array[i, j]);

            Console.ForegroundColor = ConsoleColor.Green;
            System.Console.Write(ar);
            Console.ForegroundColor = ConsoleColor.DarkGray;

            if (j < array.GetLength(1) - 1) System.Console.Write(" | ");
        }
        System.Console.WriteLine();
    }
    Console.ResetColor();
    System.Console.WriteLine();
}

int[,] DescendSortArray(int[,] Array)
{
    for (int i = 0; i < Array.GetLength(0); i++)
    {
        for (int j = 0; j < Array.GetLength(1); j++)
        {
            for (int k = j + 1; k < Array.GetLength(1); k++)
            {
                int MaxPosition = j;
                if (Array[i, k] > Array[i, MaxPosition])
                {
                    MaxPosition = k;
                    int change = Array[i, j];
                    Array[i, j] = Array[i, MaxPosition];
                    Array[i, MaxPosition] = change;
                }
            }
        }
    }
    return Array;
}

// Код задачи

EnterArrayParameter(out int lines, out int columns, out int leftRange, out int rightRange);

int[,] Array = MakeArray(lines, columns, leftRange, rightRange);

System.Console.WriteLine("\nИз случайных целых чисел сформирован : ");

PrintArray(Array);

Console.ForegroundColor = ConsoleColor.DarkMagenta;
System.Console.WriteLine("Упорядоченный массив по убыванию элементов каждой строки : ");

int[,] DescendingSortArr = DescendSortArray(Array);

PrintArray(DescendingSortArr);
