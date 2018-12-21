using System;

namespace ByteBank
{
    public class ContaCorrente
    {
        public Cliente Titular { get; set; }

        public static int TotalDeContasCriadas { get; private set; }
        public static int TaxaOperacao;

        public int ContadorSaquesNaoPermitido { get; private set; }
        public int ContadorTransferenciasNaoPermitidas { get; private set; }

        //quando não colocamos o set;
        //na prop ele gera esse atributo
        //abaixo \/
        //private readonly int _agencia;
        public int Agencia { get; }
        public int Numero { get; }

        private double _saldo = 100;
        public double Saldo
        {
            get
            {
                return _saldo;
            }
            set
            {
                if (value < 0)
                {
                    return;
                }

                _saldo = value;
            }
        }

        public ContaCorrente(int agencia, int numero)
        {
            if(agencia <= 0)
            {
                throw new ArgumentException("O argumento agência deve ser maior que 0.", nameof(agencia));
            }

            if(numero <= 0)
            {
                throw new ArgumentException("O argumento número deve ser maior que 0.", nameof(numero));
            }

            Agencia = agencia;
            Numero = numero;

            TotalDeContasCriadas++;
            TaxaOperacao = 30 / TotalDeContasCriadas;
        }

        public void Sacar(double valor)
        {
            if (valor < 0)
            {
                throw new ArgumentException("Valor inválido para o saque", nameof(valor));
            }

            if (_saldo < valor)
            {
                ContadorSaquesNaoPermitido++;
                throw new SaldoInsuficienteException(_saldo, valor);
            }

            _saldo -= valor;
        }

        public void Depositar(double valor)
        {
            _saldo += valor;
        }

        public void Transferir(double valor, ContaCorrente contaDestino)
        {
            if(valor < 0)
            {
                throw new ArgumentException("Valor inválido para a transferência", nameof(valor));
            }

            try
            {
                Sacar(valor);
            } catch (SaldoInsuficienteException e)
            {
                ContadorTransferenciasNaoPermitidas++;
                throw new OperacaoFinanceiraException("Operação não realizada", e);
            }
            
            contaDestino.Depositar(valor);
        }
    }
}
