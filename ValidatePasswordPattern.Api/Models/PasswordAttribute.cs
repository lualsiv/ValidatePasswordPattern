using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace ValidatePasswordPattern.Api.Models
{
    /*
     *Password attribute
     *
     * Data Annotations to Validate a Password.
     *
     *
     * Call in your Class:
     * [Password(ErrorMessage="Invalid Password.",PasswordMinLength=9,PasswordMaxLength=9,StrongPasswordRequired=true/false,SpecialRequiredCharacter=true/false)]
     *
     * ->PasswordMinLength = integer with the minimum size required for the password (Default = 6)
     * -> PasswordMaxLength = integer with the maximum size required for password (Default = 12)
     * -> StrongPasswordRequired = boolean (true/false) (Default=true) If informed with (true)
     * it is mandatory to type at least one uppercase, one lowercase and a number
     * ->SpecialRequiredCharacter = boolean (true/false) (Default=true) If informed with (true) and StrongPasswordRequired = (true)
     * it is mandatory to type at least one special character ([@#$%^&+=])
     *
     */
    public class PasswordAttribute : ValidationAttribute
    {
        public int PasswordMinLength { get; set; }
        public int PasswordMaxLength { get; set; }

        public Boolean StrongPasswordRequired { get; set; }
        public Boolean SpecialRequiredCharacter { get; set; }

        public PasswordAttribute()
        {
            this.PasswordMinLength = 6;
            this.PasswordMaxLength = 12;
            this.StrongPasswordRequired = true;
            this.SpecialRequiredCharacter = true;
            this.ErrorMessage = "";
        }

        protected override ValidationResult IsValid(
        object value,
        ValidationContext validationContext)
        {
            bool success = true;

            // Carrega mensagem personalizada de erro caso nao tenha sido declarada na chamada do atributo
            if (this.ErrorMessage == "")
            {
                this.ErrorMessage = getMensagemErro();
            }

            // Verifica se o Valor é nulo
            if (value == null)
            {
                value = "";
            }

            string newValue = value.ToString();

            // Verifica se senha não é maior que o tamanho maximo
            if (newValue.Length > this.PasswordMaxLength)
            {
                success = false;
            }

            // Carrega expressao regular para validação da senha
            Regex regexSenha = new Regex(getRegex());

            // Valida a expressao regular 
            Match match = regexSenha.Match(value.ToString());

            // Se valida retorna com sucesso
            if (!match.Success)
            {
                success = false;
            }

            //valida caracteres repetidos
            regexSenha = new Regex(@"(\w)*.*\1");

            match = regexSenha.Match(value.ToString());

            // Se retorna com sucesso possui caractrere repetido
            if (match.Success)
            {
                success = false;
            }

            if(success)
                return ValidationResult.Success;

            // Devolve o erro padrao se a expressao nao for valida.
            return new ValidationResult(this.FormatErrorMessage(validationContext.DisplayName));
        }

        /// <summary>
        /// Retorna expressao regular de acordo com parametros informados no atributo
        /// </summary>
        private string getRegex()
        {
            string regex = "^.*(?=.{" + this.PasswordMinLength.ToString() + "})";


            if (this.StrongPasswordRequired)
            {
                regex += "(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])";
                if (this.SpecialRequiredCharacter)
                {
                    regex += "(?=.*[!@#$%^&*()-+])";
                }
            }
            else
            {
                regex += "(?=.*[a-zA-Z0-9@#$%^&+=])";
            }

            regex += ".*$";

            return regex;
        }

        /// <summary>
        /// Retorna mensagem de erro de acordo com parametros informados no atributo
        /// </summary>
        private string getMensagemErro()
        {
            string mErro = "Password " + this.PasswordMinLength.ToString();

            mErro += " caracteres";

            if (this.StrongPasswordRequired)
            {
                mErro += ", Conter Letras maiusculas, minusculas";

                if (SpecialRequiredCharacter)
                {
                    mErro += ", caracteres especiais";
                }

                mErro += ", números e não pode conter caractere repetido";
            }

            mErro += ".";

            return mErro;
        }
    }
}

