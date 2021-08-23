using System;

namespace holamundo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Como te llamas?: ");
            String nombre = Console.ReadLine();
            Console.WriteLine("Hola " + nombre);
        }
    }
}
