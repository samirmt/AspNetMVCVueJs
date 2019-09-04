using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace vuejs.Models
{
    public class Login
    {
        public string nome { get; set; }
        public string identificacao { get; set; }
        public string senha { get; set; }


        public Login Logar(_Database db, Login acesso)
        {
            var query = string.Format("SELECT NOME, IDENTIFICAO, SENHA FROM dbo.Usuarios WHERE IDENTIFICACAO='{0}' AND SENHA='{1}'", acesso.identificacao, acesso.senha);
            Login result = db.Database.SqlQuery<Login>(query).FirstOrDefault();
            
            return result;
        }


    }
}