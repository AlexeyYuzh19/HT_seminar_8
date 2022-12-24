/*
Задача 60. ...Сформируйте трёхмерный массив из двузначных чисел. 
Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.
Массив размером 2 x 2 x 2  
66(0,0,0) 25(0,1,0)  
34(1,0,0) 41(1,1,0)  
27(0,0,1) 90(0,1,1)  
26(1,0,1) 55(1,1,1) 

трёхмерный массив – кубразмером i x j x k
первая цифра элемента массива – номер плоского слоя, вторая – номер строки в слое, третья – номер элемента столбца в слое
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

void EnterArrayParameter(out int layers, out int lines, out int columns, out int leftRange, out int rightRange)
{
    layers = CheckSize("Введите количество плоских слоев массива : ");

    lines = CheckSize("Введите количество строк в слое массива : ");

    columns = CheckSize("Введите количество столбцов в слое массива : ");

metka:
    leftRange = CheckInputNumber("Введите величину левого значения (края) слоя массива : ");

    rightRange = CheckInputNumber("Введите величину правого значения (края) слоя массива : ");

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

int[,,] MakeArray(int layers, int lines, int columns, int leftRange, int rightRange)
{
    int[,,] array = new int[layers, lines, columns];
    Random rand = new Random();

    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            for (int k = 0; k < array.GetLength(2); k++)
            {
                array[i, j, k] = rand.Next(leftRange, rightRange);
            }
        }
    }
    return array;
}

void PrintArray(int[,,] array)
{
    Console.ForegroundColor = ConsoleColor.DarkGreen;
    System.Console.WriteLine($"\nтрехмерный массив куборазмером | {array.GetLength(0)} х {array.GetLength(1)} х {array.GetLength(2)} | :\n");

    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            for (int k = 0; k < array.GetLength(2); k++)
            {
                var ar = String.Format("{0,10}", array[i, j, k]);

                Console.ForegroundColor = ConsoleColor.Green;
                System.Console.Write(ar + $" ( {i}, {j}, {k})");
                Console.ForegroundColor = ConsoleColor.DarkGray;

                if (k < array.GetLength(2) - 1) System.Console.Write(" | ");
            }
            System.Console.WriteLine();
        }
    }
    Console.ResetColor();
    System.Console.WriteLine();
}

// Код задачи

EnterArrayParameter(out int layers, out int lines, out int columns, out int leftRange, out int rightRange);

int[,,] Array = MakeArray(layers, lines, columns, leftRange, rightRange);

System.Console.WriteLine("\nИз случайных целых чисел сформирован : ");

PrintArray(Array);


