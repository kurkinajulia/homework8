// Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.
//Например, задан массив:
//1 4 7 2
//5 9 2 3
//8 4 2 4
//В итоге получается вот такой массив:
//7 4 2 1
//9 5 3 2
//8 4 4 2

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

void PrintArray(int[,] matr) // Печать матрицы.
{
    for (int i = 0; i < matr.GetLength(0); i++)
    {
        for (int j = 0; j < matr.GetLength(1); j++)
        {
            Console.Write($"{matr[i, j]} ");
        }
        Console.WriteLine();
    }
}

void FillArray(int[,] matr) // Заполнение матрицы числами.
{
    for (int i = 0; i < matr.GetLength(0); i++)
    {
        for (int j = 0; j < matr.GetLength(1); j++)
        {
            matr[i, j] = new Random().Next(1, 10);
        }
    }
}

void SortToLowerArray(int[,] matr) // Сортировка чисел от большего к меньшему.
{
    for (int i = 0; i < matr.GetLength(0); i++)
    {
        for (int j = 0; j < matr.GetLength(1); j++)
        {
            for (int k = 0; k < matr.GetLength(1) - 1; k++)
            {
                if (matr[i, k] < matr[i, k + 1])
                {
                    int temp = matr[i, k + 1];
                    matr[i, k + 1] = matr[i, k];
                    matr[i, k] = temp;
                }
            }
        }
    }
}

int i = GetDataFromUser("Введите количество строк массива: ");
int j = GetDataFromUser("Введите количество столбцов массива: ");
int[,] matrix = new int[i, j];

FillArray(matrix);
PrintArray(matrix);

Console.WriteLine("Отсортированный массив: ");
SortToLowerArray(matrix);
PrintArray(matrix);