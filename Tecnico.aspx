<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Tecnico.aspx.cs" Inherits="WebApplicationTicketSupport.Tecnico" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
   <div class="container mt-5">
    <h2>Mis Tickets Asignados</h2>
    <asp:GridView ID="gvTicketsAsignados" runat="server" AutoGenerateColumns="False" CssClass="table table-striped"
        DataKeyNames="id_ticket" AutoGenerateEditButton="true" OnRowEditing="gvTicketsAsignados_RowEditing"
        OnRowCancelingEdit="gvTicketsAsignados_RowCancelingEdit" OnRowUpdating="gvTicketsAsignados_RowUpdating"
        OnRowDeleting="gvTicketsAsignados_RowDeleting">
        <Columns>
            <asp:BoundField DataField="id_ticket" HeaderText="ID" ReadOnly="True" />
            <asp:TemplateField HeaderText="Asunto">
                <ItemTemplate>
                    <asp:Label ID="lblAsunto" runat="server" Text='<%# Bind("asunto") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtAsunto" runat="server" Text='<%# Bind("asunto") %>'></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Descripción">
                <ItemTemplate>
                    <asp:Label ID="lblDescripcion" runat="server" Text='<%# Bind("descripcion") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtDescripcion" runat="server" Text='<%# Bind("descripcion") %>'></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Prioridad">
                <ItemTemplate>
                    <asp:Label ID="lblPrioridad" runat="server" Text='<%# Bind("prioridad") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:DropDownList ID="ddlPrioridad" runat="server" SelectedValue='<%# Bind("prioridad") %>'>
                        <asp:ListItem Value="baja">Baja</asp:ListItem>
                        <asp:ListItem Value="media">Media</asp:ListItem>
                        <asp:ListItem Value="alta">Alta</asp:ListItem>
                        <asp:ListItem Value="critica">Critica</asp:ListItem>
                    </asp:DropDownList>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Categoría">
                <ItemTemplate>
                    <asp:Label ID="lblCategoria" runat="server" Text='<%# Bind("categoria") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtCategoria" runat="server" Text='<%# Bind("categoria") %>'></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Estado">
                <ItemTemplate>
                    <asp:Label ID="lblEstado" runat="server" Text='<%# Bind("estado") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:DropDownList ID="ddlEstado" runat="server" SelectedValue='<%# Bind("estado") %>'>
                        <asp:ListItem Value="abierto">Abierto</asp:ListItem>
                        <asp:ListItem Value="en progreso">En Progreso</asp:ListItem>
                        <asp:ListItem Value="resuelto">Resuelto</asp:ListItem>
                        <asp:ListItem Value="cerrado">Cerrado</asp:ListItem>
                    </asp:DropDownList>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="fecha_creacion" HeaderText="Fecha Creación" DataFormatString="{0:g}" ReadOnly="true" />
            <asp:BoundField DataField="fecha_cierre" HeaderText="Fecha Cierre" DataFormatString="{0:g}" ReadOnly="true" />
            <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
        </Columns>
    </asp:GridView>
    <asp:Label ID="lblMensaje" runat="server" ForeColor="Red" />
</div>
</asp:Content>
