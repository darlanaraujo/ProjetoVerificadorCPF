using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

/** Classe para validação de CPF
 * 
 * Para validar um CPF, é preciso calcular os 2 dígitos verificadores do CPF
 * e verificar se eles são iguais aos do CPF apresentado.
 * 
 * Um CPF é uma sequência de 9 dígitos, seguidos por 2 dígitos verificadores.
 * Ex: 123.456.789-00 (00 sendo os dígitos verificadores).
 *
 * Ao validar um CPF, nós usamos os 9 primeiros dígitos para encontrar quais são
 * os 2 dígitos verificadores corretos, e verificamos se esses dígitos encontrados
 * são iguais aos 2 últimos dígitos do CPF que temos em mãos.
 *
 * Note que esta forma de validação apenas verifica se o CPF é CONSISTENTE, ou seja,
 * pode ser fornecido para teste de software. Esse método não confirma se o CPF
 * é real e pertence a uma pessoa.
 *
 * Passos para Vaçodar o CPF
 * 
 * 1 - Calcular o primeiro dígito verificador utilizando os 9 primeiros dígitos do CPF.
 * 2 - Calcular o segundo dígito verificador utilizando os 9 primeiros dígitos e o primeiro dígito verificador.
 * 3 - Verificar se os 2 dígitos encontrados são iguais aos 2 últimos dígitos do CPF.
 * 4 - Se os dígitos calculados forem iguais aos dígitos fornecidos, então o CPF é válido.
 * 
 * EXEMPLO DE CALCULO: CPF 016.703.075-22
 * 
 * PRIMEIRO CALCULO
 * 
 * Digitos  0 1 6 . 7 0 3 . 0 7 5
 * Peso:    1 2 3   4 5 6   7 8 9
 *         ------------------------
 * Soma:    0 2 18 28 0 18  0 56 45 = 167
 * Divisâo: 167 / 11 = 15,18181818...
 * Resto:   2 -> esse resto corresponde ao primeiro digito verificador
 * 
 * SEGUNDO CALCULO
 * 
 * Digitos  0 1 6 . 7 0 3 . 0 7 5 - 2
 * Peso:    0 1 2   3 4 5   6 7 8   9
 *         -----------------------------
 * Soma:    0 1 12 21 0 15  0 49 40 18 = 156
 * Divisâo: 156 / 11 = 14,18181818...
 * Resto:   2 -> esse resto corresponde ao segundo digito verificador
 * 
 * CONCLUSÃO
 * 
 * Se os últimos dois digitos do CPF forem iguais aos digitos verificadores, o CPF é VALIDO.
 */

namespace ValidaCPF
{
    class ValidacaoCPF
    {
        public static bool verificarCPF(string cpf)
        {
            // Atributos;
            string CPF1, CPF2;
            int soma = 0, resultado;
            // Criação dos vetores que recebem o valor referente ao peso da soma;
            int[] digVerificador1 = new int[9] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int[] digVerificador2 = new int[10] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            //=====================================================================

            // Tratamento dos dados do parametro;
            cpf = cpf.Trim(); // Metodo para limpar espaços do texto;
            cpf = cpf.Replace(",", "").Replace(".", "").Replace("-", ""); // Metodo para trocar , ou . ou - por nada;

            //=====================================================================

            // 1 Condição: Se foi digitado 11 numeros;
            if(cpf.Length != 11)
            {
                MessageBox.Show("Você precisa digitar os 11 Digitos");
                return false;
            }

            //=====================================================================

            // Calculo para definir o primeiro Digito Verificador;
            CPF1 = cpf.Substring(0, 10); // Ex: 016703075 2
//MessageBox.Show("O valor é: " + CPF1);

            // Laço para determinar a posição dos valores contando apenas 9 posições;
            for (int pos = 0; pos <9; pos++)
            {
                // soma recebe o valor de CPF1 vezes o digVerificador1 (soma essa feita posição por posição);
                soma += int.Parse(CPF1[pos].ToString()) * digVerificador1[pos];
 //MessageBox.Show("O valor é: " + CPF1[pos] + "O cód Verificador é: " + digVerificador1[pos]);
 //MessageBox.Show("A soma é: " + soma);
            }
            resultado = soma % 11; // Resultado recebe o resto da divisão da soma por 11;

            // Condição caso o resto da divisão seja 10;
            if(resultado == 10)
            {
                resultado = 0; // Nesse caso ele vira 0;
            }
//MessageBox.Show("O resultado é: " + resultado);

            //========================================================================

            // Calculo para definir o segundo Digito Verificador;

            // Primeiro eu converto o valor do resultado para string e atribuo o dado no atributo;
            CPF2 = resultado.ToString(); // Ex: 2;

            // Aqui não é feito uma soma, está sendo feito uma concatenação, ja que são strings;
            // Ou seja, estou adicionando ao final do texto o valor que veio do resultado na forma de texto;
            CPF1 = CPF1 + CPF2; // Ex: 0167030752 + 2
//MessageBox.Show("O valor é: " + CPF1);

            soma = 0;
            resultado = 0;

            // Laço para determinar a posição dos valores contando apenas 10 posições;
            for (int pos = 0; pos <10; pos++)
            {
                // soma recebe o valor de CPF1 vezes o digVerificador2 (soma essa feita posição por posição);
                soma += int.Parse(CPF1[pos].ToString()) * digVerificador2[pos];
            }
            resultado = soma % 11; // Resultado recebe o resto da divisão da soma por 11;

            // Condição caso o resto da divisão seja 10;
            if (resultado == 10)
            {
                resultado = 0; // Nesse caso ele vira 0;
            }

            // Aqui não é feito uma soma, está sendo feito uma concatenação, ja que são strings;
            // Ou seja, estou adicionando ao final do texto o valor que veio do resultado na forma de texto;
            CPF2 = CPF2 + resultado.ToString(); // Ex: 22 (que seria o valor do primeiro calculo e agora o do segundo);

            /** Retorno:
             * O retorno estou usando um metodo EndWith que faz uma busca de algo, nesse caso
             * estou verificando se dentro do parametro cpf contem os dois digitos iguais aos
             * encontrados na duas somas do programa Ex: 22;
             */
            return cpf.EndsWith(CPF2);
            
        }
    }
}
