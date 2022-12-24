/*
Задача 62. Напишите программу, которая заполнит спирально массив 4 на 4.
Например, на выходе получается вот такой массив:  
01 02 03 04  
12 13 14 05  
11 16 15 06  
10 09 08 07  
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

void PrintArray(int[,] array)
{
    Console.ForegroundColor = ConsoleColor.DarkGreen;
    System.Console.WriteLine($"\nДвумерный массив размером | {array.GetLength(0)} х {array.GetLength(1)} | :\n");

    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            var ar = String.Format("{0,7}", array[i, j].ToString().PadLeft(2, '0'));

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

int[,] PrimitivCodeSnakeArray()
{
    int[] source = { 01, 02, 03, 04, 12, 13, 14, 05, 11, 16, 15, 06, 10, 09, 08, 07 };

    int[,] snake = new int[4, 4];

    int count = 0;

    for (int i = 0; i < snake.GetLength(0); i++)
    {
        for (int j = 0; j < snake.GetLength(1); j++)
        {
            snake[i, j] = source[count];
            count++;
        }
    }
    return snake;
}

int[,] MakeSnakeArrayCode()
{
    int lines, columns;

    lines = CheckSize("Введите количество строк массива : ");

    columns = CheckSize("Введите количество столбцов массива : ");

    int[,] SnakeArray = new int[lines, columns];

    int LinesStart = 0, LinesEnd = 0, ColumnsStart = 0, ColumnsEnd = 0;

    int ArrayNumber = 1;
    int i = 0;
    int j = 0;

    while (ArrayNumber <= lines * columns)
    {
        SnakeArray[i, j] = ArrayNumber;

        if (i == LinesStart && j < columns - LinesEnd - 1) ++j;

        else if (j == columns - ColumnsEnd - 1 && i < lines - LinesEnd - 1) ++i;

        else if (i == lines - LinesEnd - 1 && j > ColumnsStart) --j;

        else --i;

        if ((i == LinesStart + 1) && (j == ColumnsStart) && (ColumnsStart != columns - ColumnsEnd - 1))
        {
            ++LinesStart;
            ++LinesEnd;
            ++ColumnsStart;
            ++ColumnsEnd;
        }
        ++ArrayNumber;
    }
    return SnakeArray;
}

// Вариант 1 кода - примитивный и буквально по смыслу текста задачи.

Console.ForegroundColor = ConsoleColor.DarkMagenta;
System.Console.WriteLine("\nВариант заполнения массива спиралью - примитивный и буквально по смыслу текста задачи.");

int[,] SnakeArr = PrimitivCodeSnakeArray();

PrintArray(SnakeArr);

// Вариант 2 кода - формирование змейкой массива заданного размера.

Console.ForegroundColor = ConsoleColor.DarkMagenta;
System.Console.WriteLine("Вариант заполнения спиралью массива заданного размера.\n");

int[,] AwesomeSnakeArray = MakeSnakeArrayCode();

PrintArray(AwesomeSnakeArray);

Console.ResetColor();