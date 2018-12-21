using System;
using System.Collections.Generic;
using System.Text;

namespace ByteBank
{
    public class OperacaoFinanceiraException: Exception
    {
        public OperacaoFinanceiraException()
        {
        }

        public OperacaoFinanceiraException(string mensagem)
            : base(mensagem)
        {
        }

        public OperacaoFinanceiraException(string mensagem, Exception excessaoInterna)
            : base(mensagem, excessaoInterna)
        {
        }
    }
}
