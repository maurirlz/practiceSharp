using System;
using System.Text;

namespace Matrices
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Se solicita que desarrolle una aplicación en C# que utilizando un menú permita a un usuario realizar
            * diferentes operaciones de matrices:
              
             * 1. Carga de dos matriz en forma manual x
             * 2. Carga de una matriz en forma automática con números aleatorios. x
             * 3. Matriz transpuesta. x
             * 4. Traza de una matriz. x
             * 5. Determinar si una matriz es del tipo identidad x 
             * 6. Matriz diagonal x 
             * 7. Multiplicación escalar x
             * 8. Suma de dos matrices x 
             * 9. Resta de matrices x 
             * 10. Determinar la igualdad de dos matrices x 
             */

            bool flag = false;
            int[,] firstMatrix = {{0,0,0}, {0,0,0}};
            int[,] secondMatrix = {{0,0,0}, {0,0,0}};
            int multiplier = 1;
            
            do
            {
                Console.WriteLine(BuildMainMenu());
                ConsoleKeyInfo input = Console.ReadKey();

                switch (input.Key)
                {
                    case ConsoleKey.D1:

                        LoadMatrix(out int[,] first);
                        firstMatrix = first;
                        PrintMatrix(first);
                        
                        LoadMatrix(out int[,] second);
                        secondMatrix = second;
                        PrintMatrix(second);
                        
                        break;
                    case ConsoleKey.D2:

                        LoadMatrix(out int[,] autoMatrix);
                        PrintMatrix(autoMatrix);
                        
                        break;
                    case ConsoleKey.D3:

                        int[,] transposedMatrix = GetTransposedMatrix(firstMatrix);
                        PrintMatrix(transposedMatrix);
                        
                        break;
                    case ConsoleKey.D4:

                        Console.WriteLine($"The trace of the first matrix is: {GetTracesOfGivenMatrix(firstMatrix)}\n" +
                                          $"The trace of the second matrix is: {GetTracesOfGivenMatrix(secondMatrix)}");
                        break;
                    case ConsoleKey.D5:

                        Console.WriteLine("Checking if the first matrix inputted is a identity one: {0}", IsIdentityMatrix(firstMatrix));
                        Console.WriteLine("Checking if the secondf matrix inputted is a identity one: {0}", IsIdentityMatrix(secondMatrix));
                        
                        break;
                    case ConsoleKey.D6:
                        
                        Console.WriteLine("Checking if the first matrix inputted is a diagonal one: {0}", IsDiagonalMatrix(firstMatrix));
                        Console.WriteLine("Checking if the secondf matrix inputted is a diagonal one: {0}", IsDiagonalMatrix(secondMatrix));
                        
                        break;
                    case ConsoleKey.D7:

                        multiplier = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("The multiplication between {0} and the first matrix is: ", multiplier);
                        PrintMatrix(GetScalarMultiplication(firstMatrix, multiplier));
                        
                        Console.WriteLine("The multiplication between {0} and the second matrix is: ", multiplier);
                        PrintMatrix(GetScalarMultiplication(secondMatrix, multiplier));
                        
                        break;
                    case ConsoleKey.D8:

                        Console.WriteLine("The sum between the two matrixes inputted is: ");
                        
                        SumBetweenTwoMatrixes(firstMatrix, secondMatrix, out int[,] resultSum);
                        PrintMatrix(resultSum);
                        
                        break;
                    case ConsoleKey.D9:

                        SubtractionBetweenTwoMatrixes(firstMatrix, secondMatrix, out int[,] resultSubtraction);
                        PrintMatrix(resultSubtraction);

                        break;
                    
                    case ConsoleKey.D0:

                        Console.WriteLine("Equality between the two matrixes inputted: {0}", IgualityCheckBetweenTwoMatrixes(firstMatrix, secondMatrix));

                        break;
                        
                    case ConsoleKey.Q:

                        flag = true;
                        break;
                    default:
                        Console.WriteLine("Invalid pressed key.");
                        break;
                }

                Console.WriteLine("\nPress a key to go back to the main menu: ");
                Console.ReadKey();

            } while (!flag);
        }
        
        private static bool IgualityCheckBetweenTwoMatrixes(int[,] firstMatrix, int[,] secondMatrix)
        {

            if (OrderCheckBetweenTwoMatrixes(firstMatrix, secondMatrix))
            {
                for (int i = 0; i < firstMatrix.GetLength(0); i++)
                {
                    for (int j = 0; j < firstMatrix.GetLength(1); j++)
                    {

                        if (firstMatrix[i, j] != secondMatrix[i, j])
                        {

                            return false;
                        }
                    }
                }

                return true;
            }

            return false;
        }

        private static void SubtractionBetweenTwoMatrixes(int[,] firstMatrix, int[,] secondMatrix, out int[,] result)
        {

            if (OrderCheckBetweenTwoMatrixes(firstMatrix, secondMatrix))
            {
                int rows = firstMatrix.GetLength(0);
                int columns = firstMatrix.GetLength(1);
                
                result = new int[rows,columns];
                
                for (int i = 0; i < firstMatrix.GetLength(0); i++)
                {
                    for (int j = 0; j < firstMatrix.GetLength(1); j++)
                    {

                        result[i, j] = secondMatrix[i, j] - firstMatrix[i, j];
                    }
                }
            }

            Console.WriteLine("Matrixes doesn't have the same order, returning first matrix.");
            result = firstMatrix;
        }

        private static void SumBetweenTwoMatrixes(int[,] firstMatrix, int[,] secondMatrix, out int[,] result)
        {

            if (OrderCheckBetweenTwoMatrixes(firstMatrix, secondMatrix))
            {
                int rows = firstMatrix.GetLength(0);
                int columns = firstMatrix.GetLength(1);
                
                result = new int[rows,columns];
                
                for (int i = 0; i < firstMatrix.GetLength(0); i++)
                {
                    for (int j = 0; j < secondMatrix.GetLength(1); j++)
                    {
                        result[i, j] = firstMatrix[i, j] + secondMatrix[i, j];
                    }
                }
            }

            Console.WriteLine("Matrixes doesn't have the same order, returning first matrix.");
            result = firstMatrix;
        }

        private static int[,] GetScalarMultiplication(int[,] matrix, int numberMultiplying)
        {
            
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; i < matrix.GetLength(1); j++)
                {
                    matrix[i, j] *= numberMultiplying;
                }
            }
            
            return matrix;
        }

        private static bool IsDiagonalMatrix(int[,] matrix)
        {
            if (IsSquaredMatrix(matrix))
            {
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {

                        if (i != j)
                        {

                            if (matrix[i, j] != 0)
                            {
                                return false;
                            }
                        }
                    }
                }

                return true;
            }
            return false;
        }

        private static bool IsIdentityMatrix(int[,] matrix)
        {
            if (IsSquaredMatrix(matrix))
            {
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {

                        // [ 1 0 0 ]
                        // [ 0 1 0 ]
                        // [ 0 0 1 ]

                        if (i == j)
                        {
                            if (matrix[i, j] == 1)
                            {

                                continue;
                            }

                            return false;
                        }

                        if (i != j)
                        {

                            if (matrix[i, j] == 0)
                            {

                                continue;
                            }

                            return false;
                        }
                    }
                }
                
                return true;
            }
            
            return false;
        }

        private static int GetTracesOfGivenMatrix(int[,] matrix)
        {
            int trace = 0;
            
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (i == j)
                    {

                        trace += matrix[i, j];
                    }
                }
            }

            return trace;
        }

        private static int[,] GetTransposedMatrix(int[,] matrix)
        {
            int originalMatrixRows = matrix.GetLength(0); 
            int originalMatrixColumns = matrix.GetLength(1);
            
            int[,] transposedMatrix = new int[originalMatrixColumns, originalMatrixRows];
            
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {

                    transposedMatrix[j, i] = matrix[i, j];
                }
            }

            return transposedMatrix;
        }

        private static void LoadMatrix(out int[,] matrix)
        {
            Console.WriteLine(BuildMatrixLoadMethodMenu());

            ConsoleKeyInfo input = Console.ReadKey();
            
            if (input.Key == ConsoleKey.D1 || input.Key == ConsoleKey.NumPad1)
            {

                AutomaticallyLoadAMatrix(out matrix);
                return;


            } if (input.Key == ConsoleKey.D2 || input.Key == ConsoleKey.NumPad2)
            {
                ManuallyLoadAMatrix(out matrix);
                return;
            }

            matrix = new int[2,2];
        }

        private static void AutomaticallyLoadAMatrix(out int[,] matrix)
        {
            Random random = new Random();
            int firstRandomDimension = random.Next(1, 9);
            int secondRandomDimension = random.Next(1, 9);
                
            matrix = new int[firstRandomDimension,secondRandomDimension];
                
            for (var i = 0; i < matrix.GetLength(0); i++)
            {
                for (var j = 0; j < matrix.GetLength(1); j++)
                {
                    int randomDigit = random.Next(0, 9);
                    matrix[i, j] = randomDigit;
                }
            }
        }

        private static void ManuallyLoadAMatrix(out int[,] matrix)
        {
            int numberOfRows = 0;
            int numberOfColumns = 0;

            do
            {
                Console.WriteLine(BuildDimensionMenu());
                ConsoleKeyInfo input = Console.ReadKey();
                
                switch (input.Key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:

                        numberOfRows = GetDesiredDimension("row", DetermineIfRowIsDesired);
                        Console.WriteLine("Now input the number of columns: ");
                        numberOfColumns = GetDesiredDimension("column", DetermineIfColumnIsDesired);
                        
                        break;

                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:

                        numberOfColumns = GetDesiredDimension("column", DetermineIfColumnIsDesired);
                        Console.WriteLine("Now input the number of rows: ");
                        numberOfRows = GetDesiredDimension("row", DetermineIfRowIsDesired);
                        break;
                }
                
            } while (numberOfColumns <= 0 && numberOfRows <= 0);
            
            matrix = new int[numberOfRows,numberOfColumns];
            
            
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.WriteLine("Enter a number from 0 to 9: ");
                    matrix[i, j] = Convert.ToInt32(Console.ReadLine());
                }
            }
        }

        private static void PrintMatrix(int[,] matrix)
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

        private static bool IsSquaredMatrix(int[,] matrix)
        {

            return matrix.GetLength(0) == matrix.GetLength(1);
        }

        private static bool OrderCheckBetweenTwoMatrixes(int[,] firstMatrix, int[,] secondMatrix)
        {

            bool columnOrderCheck = firstMatrix.GetLength(1) == secondMatrix.GetLength(1);
            bool rowOrderCheck = firstMatrix.GetLength(0) == secondMatrix.GetLength(0);

            return rowOrderCheck && columnOrderCheck;
        }

        private static string BuildMatrixLoadMethodMenu()
        {

            StringBuilder sb = new StringBuilder();

            sb.Append("Select the desired method for the loading process of the required matrix: ")
                .Append("\n\t1. Automatically")
                .Append("\n\t2. Manually");

            return sb.ToString();
        }

        private static string BuildDimensionMenu()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Dimension check menu: ")
                .Append("\n\t1. To input the number of rows of the matrix.")
                .Append("\n\t2. To input the number of columns of the matrix.");

            return sb.ToString();
        }

        private static string BuildMainMenu()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Matrix app: ")
                .Append("\n\t1. Manually load two matrix.")
                .Append("\n\t2. Automatically load a matrix. ")
                .Append("\n\t3. Get the transposed matrix of the loaded matrix.")
                .Append("\n\t4. Get the trace of the given matrix: ")
                .Append("\n\t5. Determine if the given matrix is an identity one.")
                .Append("\n\t6. Get the diagonal matrix: ")
                .Append("\n\t7. Get the scalar multiplication between a number and the given matrix.")
                .Append("\n\t8. Get the sum of two matrix.")
                .Append("\n\t9. Get the subtraction between two matrix.")
                .Append("\n\t0. Determine if two matrixes are equal.")
                .Append("\n Press Q to quit: ");
            
            return sb.ToString();
        }

        private static int GetDesiredDimension(string s, Predicate<string> predicate)
        {
         
            Console.WriteLine($"Enter the desired amount of {s}s for the requested matrix: ");
            
            if (predicate.Invoke(s))
            {
                
                int.TryParse(Console.ReadLine(), out int dimension);
                return dimension;
            }
         
            throw new InvalidCastException("Invalid type of input, couldn't parse to a number.");
        }

        private static bool DetermineIfRowIsDesired(string s)
        {

            return String.Compare("row", s, StringComparison.OrdinalIgnoreCase) == 0;
        }

        private static bool DetermineIfColumnIsDesired(string s)
        {

            return String.Compare("column", s, StringComparison.OrdinalIgnoreCase) == 0;
        }
    }
}