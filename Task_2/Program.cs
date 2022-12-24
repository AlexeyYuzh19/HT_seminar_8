/*
Задача 56: Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.
Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
5 2 6 7
Программа считает сумму элементов в каждой строке и выдаёт номер строки с наименьшей суммой элементов: 1 строка
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
    lines = CheckSize("Введите размер массива : ");

    columns = lines;

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

void MinSummaLines(int[,] array, out int min, out int MinSumLine)
{
    int[] SummLine = new int[array.GetLength(0)];

    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            SummLine[i] += array[i, j];
        }
    }

    min = SummLine[0];
    MinSumLine = 0;

    for (int i = 1; i < SummLine.Length; i++)
    {
        if (SummLine[i] < min)
        {
            min = SummLine[i];
            MinSumLine = i;
        }
    }
}

// Код задачи

EnterArrayParameter(out int lines, out int columns, out int leftRange, out int rightRange);

int[,] Array = MakeArray(lines, columns, leftRange, rightRange);

System.Console.WriteLine("\nИз случайных целых чисел сформирован : ");

PrintArray(Array);

Console.ForegroundColor = ConsoleColor.Green;

MinSummaLines(Array, out int min, out int MinSumLine);

System.Console.WriteLine($"Наименьшая сумма элементов строк равна {min}. Номер строки (отсчет с нулевой строки) : {MinSumLine}.\n");

Console.ResetColor();


