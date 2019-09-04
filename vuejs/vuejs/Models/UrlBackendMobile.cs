using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace vuejs.Models
{
    public class UrlBackendMobile
    {
        public int id { get; set; }
        public string CNPJ { get; set; }
        public string URL { get; set; }
        public int PortaRetaguarda { get; set; }
        public int PortaApp { get; set; }


        public List<UrlBackendMobile> PegarTodos(_Database db)
        {
            var query = "SELECT * FROM dbo.UrlBackendMobile";
            var url = db.Database.SqlQuery<UrlBackendMobile>(query).ToList();
            return url;
        }

        public UrlBackendMobile PegarPorId(_Database db, int id)
        {
            var query = String.Format("SELECT * FROM dbo.UrlBackendMobile WHERE id = {0}", id);
            var url = db.Database.SqlQuery<UrlBackendMobile>(query).FirstOrDefault();
            return url;
        }

        public bool Inserir(_Database db, UrlBackendMobile url)
        {
            try
            {
                var query = String.Format("INSERT INTO dbo.UrlBackendMobile VALUES ('{0}', '{1}', {2}, {3})", url.CNPJ, url.URL, url.PortaRetaguarda, url.PortaApp);
                db.Database.ExecuteSqlCommand(query);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        public bool Atualizar(_Database db, UrlBackendMobile url)
        {
            try
            {
                var query = String.Format("UPDATE dbo.UrlBackendMobile SET CNPJ = '{0}', URL = '{1}', PortaRetaguarda = {2}, PortaApp = {3} WHERE id = {4}"
                , url.CNPJ, url.URL, url.PortaRetaguarda, url.PortaApp, url.id);

                db.Database.ExecuteSqlCommand(query);

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}