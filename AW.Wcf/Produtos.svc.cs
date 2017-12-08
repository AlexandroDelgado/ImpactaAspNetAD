using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using AW.Repositorios.SqlServer.EF.DbFirst;

namespace AW.Wcf
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Produtos : IProdutos
    {
        public Product Selecionar(int id)
        {
            using (var db = new AdventureWorks2012Entities())
            {
                return db.Products.Find(id);
            }
        }

        public List<Product> SelecionarPorNome(string nome)
        {
            using(var db = new AdventureWorks2012Entities())
            {
                return db.Products.Where(p => p.Name.Contains(nome)).ToList();
            }
        }
    }
}
