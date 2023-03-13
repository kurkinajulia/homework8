//Задайте прямоугольный двумерный массив. 
//Напишите программу, которая будет находить строку с наименьшей суммой элементов.

//Например, задан массив:
//1 4 7 2
//5 9 2 3
//8 4 2 4
//5 2 6 7

//Программа считает сумму элементов в каждой строке и выдаёт номер строки 
//с наименьшей суммой элементов: 0 строка

int GetDataFromUser(string messageForUser) // Запрос диапозона матрицы.
{
    int value = 0;
    bool flag = false;

    while (!flag)

    {
        Console.Write(messageForUser);
        flag = int.TryParse(Console.ReadLine(), out value);
        if (flag == false)
        {
            Console.WriteLine("Введённое значение не валидно, используйте целые положительные числа.");
        }
    }

    return value;
}

void FillRandomMatrix(int[,] matrix) // Заполнение матрицы рандомом.
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            matrix[i, j] = new Random().Next(1, 10);
        }
    }
}

void PrintMatrix(int[,] matrix) // Печать матрицы.
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            Console.Write($"{matrix[i, j]} ");
        }
        Console.WriteLine();
    }
}

int GetIndexOfLineWithMinSum(int[,] matrix) // Нахождение индекса строки с наименьшей суммой элементов.
{
    int[] arrayWithSums = new int[matrix.GetLength(0)];
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        int lineSum = 0;
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            lineSum += matrix[i, j];
        }
        arrayWithSums[i] = lineSum;
        Console.WriteLine($"Сумма строки с индексом {i}: {lineSum}");
    }
    int minSumIndex = 0;
    for (int i = 0; i < arrayWithSums.Length; i++)
    {
        if (arrayWithSums[i] < arrayWithSums[minSumIndex]) minSumIndex = i;
    }
    return minSumIndex;
}

int i = GetDataFromUser("Введите количество строк массива: ");
int j = GetDataFromUser("Введите количество столбцов массива: ");
int[,] matrix = new int[i, j];

FillRandomMatrix(matrix);
PrintMatrix(matrix);
Console.WriteLine($"Индекс строки с наименьшей суммой элементов: {GetIndexOfLineWithMinSum(matrix)}");