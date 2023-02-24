/* Задача 54: Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки 
двумерного массива.
Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
В итоге получается вот такой массив:
7 4 2 1
9 5 3 2
8 4 4 2
*/
int[,] GenerateArray2DInt (int rows, int cols, int min, int max)
{
    int[,] array = new int[rows, cols];
    for(int i = 0; i < rows; i++)
        for(int j = 0; j < cols; j++)
            array[i, j] = new Random().Next(min, max + 1);
    return array;
}

void PrintArray2DInt (int[,] array)
{
    for(int i = 0; i < array.GetLength(0); i++)
    {
        for(int j = 0; j < array.GetLength(1); j++)
            Console.Write((array[i, j] < 0 ? "": " ") + array[i, j] + "\t");
        Console.Write("\n");
    }
}

void SortRow (int[,] array, int rowIndex)
{
    for(int i = 0; i < array.GetLength(1); i++)
        for(int j = i; j < array.GetLength(1); j++)
            if(array[rowIndex, j] > array[rowIndex, i])
                {
                    int temp = array[rowIndex, j];
                    array [rowIndex, j] = array[rowIndex, i];
                    array[rowIndex, i] = temp;
                }
}

Console.Write("Enter row count: ");
int rows = Convert.ToInt32(Console.ReadLine());
Console.Write("Enter column count: ");
int cols = Convert.ToInt32(Console.ReadLine());
Console.Write("Enter min number: ");
int min = Convert.ToInt32(Console.ReadLine());
Console.Write("Enter max number: ");
int max = Convert.ToInt32(Console.ReadLine());

int[,] myArray = GenerateArray2DInt(rows, cols, min, max);
Console.WriteLine("Initial array:");
PrintArray2DInt(myArray);

for(int i = 0; i < myArray.GetLength(0); i++)
    SortRow(myArray, i);

Console.WriteLine("\nSorted rows array:");
PrintArray2DInt(myArray);

