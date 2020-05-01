using System;

namespace Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] tab = new int[5];

            tab = Pedir5Numeros(tab);
            SumarParesYRestarInpares(tab, out int pares, out int inpares);
            int promedio = HallarPromedioEnArreglo(tab);
            
            int op = 0;
            
            Console.WriteLine("Lo suma o lo resta");
            Console.WriteLine("1: suma los numeros del arreglo");
            Console.WriteLine("2: resta los numeros del arreglo");
            
            op = int.Parse(Console.ReadLine());
            
            switch (op)
            {
                case 1: {
                    
                    int c = 0;
                    
                    for (int i = 0; i < 7; i++)
                    {
                        
                        c += tab[i];
                    };
                    
                    Console.WriteLine("{0}", c);
                    
                }
                    break;
                case 2:
                {
                    int c = 0;
                    
                    for (int i = 0; i < 7; i++)
                    {
                        
                        c -= tab[i];
                        
                    };
                    Console.WriteLine("{0}", c);
                }
                    break;
            }
            
            Console.ReadKey();
        }

        private static int[] Pedir5Numeros(int[] arrayVacio)
        {
            
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Ingrese un numero: ");
                arrayVacio[i] = int.Parse(Console.ReadLine());
            }

            return arrayVacio;
        }

        private static void MostrarArreglo(int[] arreglo)
        {
            Console.WriteLine("<<<<<<<<<<<<<<<<<MOSTRANDO EL ARREGLO>>>>>>>>>>>>>>>>>>");
            
            for (int i = 0; i < arreglo.Length; i++)
            {
                Console.WriteLine("{0}", arreglo[i]);
            }
        }

        private static int SumarPosicionesPares(int[] arreglo)
        {

            int acum = 0;
            
            for (var i = 0; i < arreglo.Length; i++)
            {
                if (i % 2 == 0)
                {
                    acum += arreglo[i];
                }
            }

            return acum;
        }

        private static int RestarInpares(int[] arreglo)
        {

            int acum = 0;

            for (int i = 0; i < arreglo.Length; i++)
            {

                if (i % 2 != 0)
                {
                    acum -= arreglo[i];
                }
            }

            return acum - arreglo[1];
        }

        private static void SumarParesYRestarInpares(int[] arreglo, out int pares, out int inpares)
        {

            pares = SumarPosicionesPares(arreglo);
            inpares = RestarInpares(arreglo);
        }

        private static int HallarMaximoEnArreglo(int[] arreglo)
        {
            Array.Sort(arreglo);
            int max = 0;
            
            foreach (var i in arreglo)
            {
                if (i > max)
                {

                    max = i;
                }
                
            }

            return max;
        }

        private static int HallarPromedioEnArreglo(int[] arreglo)
        {
            int promedio = 0;

            for (var i = 0; i < arreglo.Length; i++)
            {

                promedio += arreglo[i];
            }

            return promedio / arreglo.Length;
        }
    }
}