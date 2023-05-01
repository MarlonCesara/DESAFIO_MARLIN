using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.RegularExpressions;

namespace Entidades.Notificacoes
{
    public class Notifica
    {

        public Notifica()
        {
            Notificacoes = new List<Notifica>();
        }

        [NotMapped]
        public string NomePropriedade { get; set; }

        [NotMapped]
        public string Mensagem { get; set; }

        [NotMapped]
        public List<Notifica> Notificacoes;

        public void AdicionarNotificacao(string mensagem)
        {
                Notificacoes.Add(new Notifica
                {
                    Mensagem = mensagem,
                    NomePropriedade = "Erro de cadastro"
                });
        }

        public bool ValidarPropriedadeString(string valor, string nomePropriedade)
        {

            if (string.IsNullOrWhiteSpace(valor) || string.IsNullOrWhiteSpace(nomePropriedade))
            {
                Notificacoes.Add(new Notifica
                {
                    Mensagem = "Campo Obrigatório",
                    NomePropriedade = nomePropriedade
                });

                return false;

            }
            return true;
        }


        public bool ValidarPropriedadeDecimal(decimal valor, string nomePropriedade)
        {

            if (valor < 1 || string.IsNullOrWhiteSpace(nomePropriedade))
            {
                Notificacoes.Add(new Notifica
                {
                    Mensagem = "Valor deve ser maior que 0",
                    NomePropriedade = nomePropriedade
                });

                return false;
            }

            return true;

        }

        public bool ValidarEmail(string email, string nomePropriedade)
        {

            if (!ValidadorEmail(email))
            {
                Notificacoes.Add(new Notifica
                {
                    Mensagem = "Email inválido",
                    NomePropriedade = nomePropriedade
                });

                return false;
            }

            return true;
        }

        public bool ValidadorEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        public bool ValidarCPF(string valor, string nomePropriedade)
        {
          
            if(!ValidadorCPF(valor))
            {
                Notificacoes.Add(new Notifica
                {
                    Mensagem = "CPF inválido",
                    NomePropriedade = nomePropriedade
                });

                return false;
            }
        
            return true;
        }

        private bool ValidadorCPF(string cpf)
        {
            // Removendo caracteres não numéricos
            cpf = Regex.Replace(cpf, "[^0-9]", "");

            // Verificando se o CPF tem 11 dígitos
            if (cpf.Length != 11)
            {
                return false;
            }

            // Verificando se todos os dígitos são iguais
            if (cpf.Distinct().Count() == 1)
            {
                return false;
            }

            // Calculando o primeiro dígito verificador
            int soma = 0;
            for (int i = 0; i < 9; i++)
            {
                soma += int.Parse(cpf[i].ToString()) * (10 - i);
            }
            int resto = soma % 11;
            int digitoVerificador1 = resto < 2 ? 0 : 11 - resto;

            // Calculando o segundo dígito verificador
            soma = 0;
            for (int i = 0; i < 10; i++)
            {
                soma += int.Parse(cpf[i].ToString()) * (11 - i);
            }
            resto = soma % 11;
            int digitoVerificador2 = resto < 2 ? 0 : 11 - resto;

            // Verificando se os dígitos verificadores são válidos
            if (int.Parse(cpf[9].ToString()) != digitoVerificador1 || int.Parse(cpf[10].ToString()) != digitoVerificador2)
            {
                return false;
            }

            // CPF válido
            return true;
        }


    }
}
