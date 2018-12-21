using System;

namespace ByteBank
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ContaCorrente conta1 = new ContaCorrente(768, 7687150);
                ContaCorrente conta2 = new ContaCorrente(768, 7687151);
                //conta1.Transferir(10000, conta2);
                conta1.Sacar(10000);
            } catch (OperacaoFinanceiraException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
                Console.WriteLine();

                //Console.WriteLine("Informações da INNER EXCEPTION:");
                //Console.WriteLine(e.InnerException.Message);
                //Console.WriteLine(e.InnerException.StackTrace);
            }

            Console.WriteLine();
            Console.WriteLine("Execução finalizada. Tecle enter p/ sair");
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
