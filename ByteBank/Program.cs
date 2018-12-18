using System;

namespace ByteBank
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //Metodo();
                new ContaCorrente(10, 0);
            }
            catch (DivideByZeroException erro)
            {
                Console.WriteLine("Não é possível dividir por zero");
                Console.WriteLine(erro.StackTrace);
            }
            catch (ArgumentException erro)
            {
                Console.WriteLine("Ocorreu uma exceção do tipo ArgumentException");
                Console.WriteLine(erro.Message);
            }
            catch (Exception erro)
            {
                Console.WriteLine(erro.Message);
                Console.WriteLine(erro.StackTrace);
            }

            Console.ReadLine();
        }

        private static void Metodo()
        {
            TestaDivisao(2);
            TestaDivisao(0);
        }

        private static void TestaDivisao(int divisor)
        {
            int resultado = Dividir(10, divisor);
            Console.WriteLine("Resultado da divisão de 10 por "
                + divisor + " é " + resultado);
        }

        private static int Dividir(int numero, int divisor)
        {
            try
            {
                return numero / divisor;
            }
            catch (Exception)
            {
                Console.WriteLine("Exceção com numero=" + numero + " e divisor=" + divisor);
                throw;
            }
        }
    }
}
