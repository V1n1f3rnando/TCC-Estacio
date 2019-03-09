using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoOficina.Util
{
    public class Criptogragfia
    {

        public static string EncriptarSenha(string senha)
        {
            //converter a senha em bytes..
            byte[] senhaBytes = Encoding.UTF8.GetBytes(senha);
            //aplicar o algoritmo de criptografia
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] hash = md5.ComputeHash(senhaBytes);
            //retornar o hash gerado como string..
            string result = string.Empty;
            foreach (byte b in hash)
            {
                result += b.ToString("X2"); //X2 -: hexadecimal
            }
            return result;
        }

    }
}
