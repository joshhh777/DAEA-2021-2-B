using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjLab01_1
{
    class Program
    {
        static int Suma(int a, int b)
        {
            return a + b;
        }
        static int Resta(int a, int b)
        {
            return a - b;
        }
        static int Multiplicacion(int a, int b)
        {
            return a * b;
        }
        static int Division(int a, int b)
        {
            return a / b;
        }
        static void Primos()
        {
            int numero = 2;
            int divisibles = 0;
            while(numero<=30)
            {
                for(int i = 1; i <= numero; i++)
                {
                    if(numero % i == 0 )
                    {
                        divisibles++;
                    }
                    if(divisibles>2)
                    {
                        break;
                    }
                }
                if(divisibles==2)
                {
                    Console.WriteLine("El numero {0} es primo", numero);
                }
                divisibles = 0;
                numero++;
            }
        }
        static void Raiz()
        {
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine("La raiz cuadrada de {0} es: {1}", i, Math.Sqrt(i));
            }
        }
        static void Temperatura()
        {
            string tipo;
            Console.WriteLine("[1] Convertir grados Celsius a Fahrenheit");
            Console.WriteLine("[2] Convertir grados Fahrenheit a Celsius");
            Console.WriteLine("Ingrese una opcion y presione ENTER");
            tipo = Console.ReadLine();
            switch (tipo)
            {
                case "1":
                    Console.WriteLine("Ingrese el numero de grado en Celsius");
                    int c = Convert.ToInt32(Console.ReadLine());
                    float resultado = ((9 * c) / 5) + 32;
                    Console.WriteLine("{0} grados Celsius convertido a Fahrenheit es: {1}",c ,resultado);
                    break;
                case "2":
                    Console.WriteLine("Ingrese el numero de grado en Fahrenheit");
                    int f = Convert.ToInt32(Console.ReadLine());
                    float resultado2 = (5 * (f - 32)) / 9;
                    Console.WriteLine("{0} grados Fahrenheit convertido a Celsius es: {1}", f, resultado2);
                    break;
            }
        }
        static void Main(string[] args)
        {
            Console.Title = "Procedimientos y Funciones";
            string opcion;
            do
            {
                Console.Clear();
                Console.WriteLine("[1] Suma de dos numeros");
                Console.WriteLine("[2] Resta de dos numeros");
                Console.WriteLine("[3] Multiplicacion de dos numeros");
                Console.WriteLine("[4] Division de dos numeros");
                Console.WriteLine("[5] Imprimir los 10 primeros numeros primos");
                Console.WriteLine("[6] Imprimir raiz cuadrada de los 10 primeros numeros enteros");
                Console.WriteLine("[7] Convertidor de Temperatura");
                Console.WriteLine("[0] Salir");
                Console.WriteLine("Ingrese una opcion y presione ENTER");
                opcion = Console.ReadLine();
                switch (opcion)
                {
                    case "1":
                        Console.WriteLine("Ingrese el primer numero");
                        int a = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Ingrese el segundo numero");
                        int b = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("La Suma de {0} y {1} es {2}", a, b, Suma(a, b));
                        Console.ReadKey();
                        break;
                    case "2":
                        Console.WriteLine("Ingrese el primer numero");
                        int c = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Ingrese el segundo numero");
                        int d = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("La Resta de {0} y {1} es {2}", c, d, Resta(c, d));
                        Console.ReadKey();
                        break;
                    case "3":
                        Console.WriteLine("Ingrese el primer numero");
                        int e = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Ingrese el segundo numero");
                        int f = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("La Multiplicacion de {0} y {1} es {2}", e, f, Multiplicacion(e, f));
                        Console.ReadKey();
                        break;
                    case "4":
                        Console.WriteLine("Ingrese el primer numero");
                        int g = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Ingrese el segundo numero");
                        int h = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("La Division entre {0} y {1} es {2}", g, h, Division(g, h));
                        Console.ReadKey();
                        break;
                    case "5":
                        Console.WriteLine("Calculando...");
                        Primos();
                        Console.ReadKey();
                        break;
                    case "6":
                        Console.WriteLine("Calculando...");
                        Raiz();
                        Console.ReadKey();
                        break;
                    case "7":
                        Console.WriteLine("###################### Calculando Temperatura ##########################");
                        Temperatura();
                        Console.ReadKey();
                        break;
                }
            } while (!opcion.Equals("0"));
        }
    }
}
