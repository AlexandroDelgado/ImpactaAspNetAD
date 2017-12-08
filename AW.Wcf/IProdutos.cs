using AW.Repositorios.SqlServer.EF.DbFirst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace AW.Wcf
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IProdutos
    {

        [OperationContract]
        Product Selecionar(int value);

        [OperationContract]
        List<Product> SelecionarPorNome(string nome);

        // TODO: Add your service operations here
    }
}
