/*
Задача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
Например, даны 2 матрицы:  
2 4 | 3 4  
3 2 | 3 3  
Результирующая матрица будет:  
18 20
15 18

Необходима проверка: две матрицы можно перемножить между собой тогда и только тогда, 
когда количество столбцов первой матрицы равно количеству строк второй матрицы.

Произведением двух матриц есть матрица, у которой столько строк, сколько их у левого сомножителя, 
и столько столбцов, сколько их у правого сомножителя.
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

void EnterArrayParameter(string text, out int lines, out int columns, out int leftRange, out int rightRange)
{
    lines = CheckSize($"Введите количество строк {text} матрицы : ");

    columns = CheckSize($"Введите количество столбцов {text} матрицы : ");

metka:
    leftRange = CheckInputNumber("Введите величину левого значения (края) матрицы : ");

    rightRange = CheckInputNumber("Введите величину правого значения (края) матрицы : ");

    if (leftRange == rightRange)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Значения левого и правого края матриц равны, попробуйте еще раз.");
        goto metka;
    }
    if (leftRange > rightRange)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Заданное значение левого края матриц больше правого, попробуйте еще раз.");
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

int[,] ArrayMultiplication(int[,] ArrayFerst, int[,] ArraySecond)
{
    int[,] ArrMultiplication = new int[ArrayFerst.GetLength(0), ArraySecond.GetLength(1)];

    for (int i = 0; i < ArrayFerst.GetLength(0); i++)
    {
        for (int j = 0; j < ArraySecond.GetLength(1); j++)
        {
            int multi = 0;
            for (int k = 0; k < ArrayFerst.GetLength(1); k++)
            {
                multi += ArrayFerst[i, k] * ArraySecond[k, j];
            }
            ArrMultiplication[i, j] = multi;
        }
    }
    return ArrMultiplication;
}

// Код задачи

EnterArrayParameter("первой", out int linesFerst, out int columnsFerst, out int leftRangeFerst, out int rightRangeFerst);

metkaM:

EnterArrayParameter("второй", out int linesSecond, out int columnsSecond, out int leftRangeSecond, out int rightRangeSecond);

if (columnsFerst != linesSecond)
{
    System.Console.WriteLine($"Количество столбцов первой матрицы {columnsFerst} не равно количеству строк второй  {linesSecond} - повторите ввод параметров для второй матрицы.");
    goto metkaM;
}

int[,] ArrayFerst = MakeArray(linesFerst, columnsFerst, leftRangeFerst, rightRangeFerst);

System.Console.WriteLine("\nИз случайных целых чисел сформирована первая матрица : ");

PrintArray(ArrayFerst);

int[,] ArraySecond = MakeArray(linesSecond, columnsSecond, leftRangeSecond, rightRangeSecond);

System.Console.WriteLine("Из случайных целых чисел сформирована вторая матрица : ");

PrintArray(ArraySecond);

System.Console.WriteLine("Результат умножения матриц : ");

PrintArray(ArrayMultiplication(ArrayFerst, ArraySecond));

