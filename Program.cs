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

Console.WriteLine("\n****  Task 54  ****\n");

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

Console.WriteLine("\n****  Task 56  ****\n");

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
Console.WriteLine("Row with minimal sum of elements is: " + (minSumRow + 1)); // в тестах строки нумеруются с 1, поэтому +1

/* Задача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
Например, даны 2 матрицы:
2 4 | 3 4
3 2 | 3 3
Результирующая матрица будет:
18 20
15 18
*/

Console.WriteLine("\n****  Task 58  ****\n");

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

Console.WriteLine("Matrix 1:");
PrintArray2DInt(myMatrix1);
Console.WriteLine("Matrix 2:");
PrintArray2DInt(myMatrix2);
Console.WriteLine("\nMultiplication is:");

if(myMatrix1.GetLength(1) != myMatrix2.GetLength(0))
    Console.WriteLine("Matrixes cannot by multiplied!");
else
{
    int[,] multipliedMatrix = MatrixMultiply(myMatrix1, myMatrix2);
    PrintArray2DInt(multipliedMatrix);
}

/* Задача 60. ...Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. 
Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.
Массив размером 2 x 2 x 2
66(0,0,0) 25(0,1,0)
34(1,0,0) 41(1,1,0)
27(0,0,1) 90(0,1,1)
26(1,0,1) 55(1,1,1) */
Console.WriteLine("\n****  Task 60  ****\n");

int[,,] GenerateUniqueArray(int rows, int cols, int depth)
{
    int[,,] array = new int[rows, cols, depth];
    int[] tempArr = new int[90];
    if(rows * cols * depth > 90)
    {
        Console.WriteLine("Cannot generate an array with unique two-digit numbers!!!");
        return array;
    }
    for(int i = 10; i <= 99; i++)
        tempArr[i - 10] = i;
    for(int i = 0 ; i < rows; i++)
        for(int j = 0; j < cols; j++)
            for(int k = 0; k < depth; k++)
                do{
                    int temp = new Random().Next(90);
                    if(tempArr[temp] != 0)
                    {   
                        array[i, j, k] = tempArr[temp];
                        tempArr[temp] = 0;
                    }
                } while (array[i, j, k] == 0);
    return array;
}

void PrintArray3DInt(int[,,] array)
{
    for(int i = 0 ; i < array.GetLength(0); i++)
    {
        Console.WriteLine($"Layer {i}:");
        for(int j = 0; j < array.GetLength(1); j++)
        {
            for(int k = 0; k < array.GetLength(2); k++)
                Console.Write(array[i, j, k] + $"[{i}, {j}, {k}]\t");
            Console.Write("\n");
        }
    }
}

Console.Write("Enter rows dimention: ");
rows = Convert.ToInt32(Console.ReadLine());
Console.Write("Enter cols dimention: ");
cols = Convert.ToInt32(Console.ReadLine());
Console.Write("Enter depth dimention: ");
int depth = Convert.ToInt32(Console.ReadLine());
int[,,] myArray60 = GenerateUniqueArray(rows, cols, depth);

PrintArray3DInt(myArray60);


/*
Задача 62. Напишите программу, которая заполнит спирально массив 4 на 4. 
Например, на выходе получается вот такой массив:
01 02 03 04
12 13 14 05
11 16 15 06
10 09 08 07
*/
Console.WriteLine("\n****  Task 62  ****\n");
int[,] GenerateSpiralArray(int rows, int cols)
{
    int[,] array = new int[rows, cols];
    int number = 1, minRow = 0, maxRow = rows - 1, minCol = 0, maxCol = cols - 1;
    while(number <= rows * cols)
    {
        for(int i = minCol; i <= maxCol; i++)
            array[minRow, i] = number++;
        minRow++;
        if(number > rows * cols) break;
        for(int i = minRow; i <= maxRow; i++)
            array[i, maxCol] = number++;
        maxCol--;
        if(number > rows * cols) break;
        for(int i = maxCol; i >= minCol; i--)
            array[maxRow, i] = number++;
        maxRow--;
        if(number > rows * cols) break;
        for(int i = maxRow; i >= minRow; i--)
            array[i, minCol] = number++;
        minCol++;
    }   
    return array;
}

Console.Write("Enter rows: ");
rows = Convert.ToInt32(Console.ReadLine());
Console.Write("Enter columns: ");
cols = Convert.ToInt32(Console.ReadLine());

int[,] myArray62 = GenerateSpiralArray(rows, cols);
PrintArray2DInt(myArray62);
