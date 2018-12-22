﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ByteBank
{
    public class LeitorDeArquivo : IDisposable
    {
        public string Arquivo { get; }

        public LeitorDeArquivo(string arquivo)
        {
            Arquivo = arquivo;

            //throw new FileNotFoundException();

            Console.WriteLine("Abrindo arquivo...");
        }

        public string LerProximaLinha()
        {
            Console.WriteLine("Lendo linha...");

            //throw new IOException();

            return "Linha do arquivo";
        }

        public void Fechar()
        {
            Console.WriteLine("Fechando arquivo...");
        }

        public void Dispose()
        {
            Fechar();
        }
    }
}
