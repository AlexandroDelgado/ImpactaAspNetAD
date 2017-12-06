using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Northwind.WebForms
{
    public partial class Produtos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void criterioRadioButtonList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //var rbl = (RadioButtonList)sender;
            //criterioMultiview.ActiveViewIndex = criterioRadioButtonList.SelectedItem.Value;
            //criterioMultiview.ActiveViewIndex = criterioRadioButtonList.SelectedValue;
            criterioMultiview.ActiveViewIndex = criterioRadioButtonList.SelectedIndex;

            produtosGrid.DataSourceID = $"produtosPor{criterioRadioButtonList.SelectedItem.Text}DataSource";
        }
    }
}