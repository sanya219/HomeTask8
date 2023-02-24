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

int[,] myArray54 = GenerateArray2DInt(rows, cols, min, max);
Console.WriteLine("Initial array:");
PrintArray2DInt(myArray54);

for(int i = 0; i < myArray54.GetLength(0); i++)
    SortRow(myArray54, i);

Console.WriteLine("\nSorted rows array:");
PrintArray2DInt(myArray54);

/* Задача 56: Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку 
с наименьшей суммой элементов.
Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
5 2 6 7
Программа считает сумму элементов в каждой строке и выдаёт номер строки с наименьшей суммой элементов: 1 строка
*/

int RowSum(int[,] array, int rowIndex)
{
    int result = 0;
    for(int i = 0; i < array.GetLength(1); i++)
        result += array[rowIndex, i];
    return result;
}

Console.Write("Enter row count: ");
rows = Convert.ToInt32(Console.ReadLine());
Console.Write("Enter column count: ");
cols = Convert.ToInt32(Console.ReadLine());
Console.Write("Enter min number: ");
min = Convert.ToInt32(Console.ReadLine());
Console.Write("Enter max number: ");
max = Convert.ToInt32(Console.ReadLine());

int[,] myArray56 = GenerateArray2DInt(rows, cols, min, max);
Console.WriteLine("Initial array:");
PrintArray2DInt(myArray56);

int minSumRow = 0;
for(int i = 0; i < myArray56.GetLength(0); i++)
    if(RowSum(myArray56, minSumRow) > RowSum(myArray56, i))
        minSumRow = i;
Console.WriteLine("Row with minimal sum of elements is: " + minSumRow + 1); // в тестах строки нумеруются с 1, поэтому +1

/* Задача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
Например, даны 2 матрицы:
2 4 | 3 4
3 2 | 3 3
Результирующая матрица будет:
18 20
15 18
*/

int[,] MatrixMultiply(int[,] matrix1, int[,] matrix2)
{
    int[,] resultMatrix = new int[matrix1.GetLength(0), matrix2.GetLength(1)];
    for(int i = 0; i <  resultMatrix.GetLength(0); i++)
        for(int j = 0; j < resultMatrix.GetLength(1); j++)
            for(int k = 0; k < matrix1.GetLength(1); k++)
                resultMatrix[i, j] += matrix1[i, k] * matrix2[k, j];
    return resultMatrix;
}

Console.Write("Enter row count matrix 1: ");
rows = Convert.ToInt32(Console.ReadLine());
Console.Write("Enter column count matrix 1: ");
cols = Convert.ToInt32(Console.ReadLine());
Console.Write("Enter min number: ");
min = Convert.ToInt32(Console.ReadLine());
Console.Write("Enter max number: ");
max = Convert.ToInt32(Console.ReadLine());
int[,] myMatrix1 = GenerateArray2DInt(rows, cols, min, max);

Console.Write("Enter row count matrix 2: ");
rows = Convert.ToInt32(Console.ReadLine());
Console.Write("Enter column count matrix 2: ");
cols = Convert.ToInt32(Console.ReadLine());
Console.Write("Enter min number: ");
min = Convert.ToInt32(Console.ReadLine());
Console.Write("Enter max number: ");
max = Convert.ToInt32(Console.ReadLine());
int[,] myMatrix2 = GenerateArray2DInt(rows, cols, min, max);

if(myMatrix1.GetLength(1) != myMatrix2.GetLength(0))
    Console.WriteLine("Matrixes cannot by multiplied!");
else
{
    int[,] multipliedMatrix = MatrixMultiply(myMatrix1, myMatrix2);
    PrintArray2DInt(multipliedMatrix);
}