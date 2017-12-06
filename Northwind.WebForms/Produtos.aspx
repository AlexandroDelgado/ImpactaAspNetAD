<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Produtos.aspx.cs" Inherits="Northwind.WebForms.Produtos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Produtos</h2>
    <div class="row">
        <div class="col-lg-12">
            <asp:RadioButtonList
                ID="criterioRadioButtonList"
                runat="server"
                RepeatDirection="Horizontal"
                RepeatLayout="Flow"
                OnSelectedIndexChanged="criterioRadioButtonList_SelectedIndexChanged"
                AutoPostBack="true">
                <asp:ListItem Text="Categoria" Value="0" Selected="True" />
                <asp:ListItem Text="Fornecedor" Value="1" />
            </asp:RadioButtonList>
            <asp:MultiView ID="criterioMultiview" ActiveViewIndex="0" runat="server">
                <asp:View ID="categoriaView" runat="server">
                    <asp:DropDownList
                        ID="categoriaDrop"
                        runat="server"
                        DataTextField="CategoryName"
                        DataValueField="CategoryID"
                        DataSourceID="categoriaDataSource"
                        AppendDataBoundItems="true"
                        AutoPostBack="true">
                        <asp:ListItem Text="Selecione uma categoria"
                            Value="0" />
                    </asp:DropDownList>
                    <asp:ObjectDataSource
                        ID="categoriaDataSource"
                        runat="server"
                        TypeName="Northwind.Repositorios.SqlServer.Ado.CategoriaRepositorio"
                        SelectMethod="Selecionar" />
                </asp:View>
                <asp:View ID="fornecedorView" runat="server">
                    <asp:DropDownList
                        ID="fornecedorDrop"
                        runat="server"
                        DataTextField="CompanyName"
                        DataValueField="SupplierID"
                        DataSourceID="fornecedorDataSource"
                        AppendDataBoundItems="true"
                        AutoPostBack="true">
                        <asp:ListItem Text="Selecione um Fornecedor"
                            Value="0" />
                    </asp:DropDownList>
                    <asp:ObjectDataSource
                        ID="fornecedorDataSource"
                        runat="server"
                        TypeName="Northwind.Repositorios.SqlServer.Ado.FornecedorRepositorio"
                        SelectMethod="Selecionar" />
                </asp:View>
            </asp:MultiView>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-12">
            <asp:GridView
                ID="produtosGrid"
                runat="server"
                Width="100%"
                DataSourceID="produtosPorCategoriaDataSource"
                AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField HeaderText="Produto" DataField="ProductName" />
                    <asp:BoundField HeaderText="Preço" DataFormatString="{0:C}" DataField="UnitPrice" />
                    <asp:BoundField HeaderText="Estoque" DataField="UnitsInStock" />
                </Columns>
            </asp:GridView>
            <asp:ObjectDataSource
                ID="produtosPorCategoriaDataSource"
                runat="server"
                TypeName="Northwind.Repositorios.SqlServer.Ado.ProdutoRepositorio"
                SelectMethod="SelecionarPorCategoria" >
                <SelectParameters>
                    <asp:ControlParameter 
                        ControlID="categoriaDrop" 
                        PropertyName="SelectedValue" 
                        Name="categoriaId"
                        Type="Int32"/>
                </SelectParameters>
            </asp:ObjectDataSource>
            <asp:ObjectDataSource
                ID="produtosPorFornecedorDataSource"
                runat="server"
                TypeName="Northwind.Repositorios.SqlServer.Ado.ProdutoRepositorio"
                SelectMethod="SelecionarPorFornecedor" >
                <SelectParameters>
                    <asp:ControlParameter 
                        ControlID="fornecedorDrop" 
                        PropertyName="SelectedValue" 
                        Name="fornecedorId"
                        Type="Int32"/>
                </SelectParameters>
            </asp:ObjectDataSource>
        </div>
    </div>
</asp:Content>
