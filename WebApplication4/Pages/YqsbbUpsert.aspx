<%@ Page Title="" Language="C#" MasterPageFile="~/SiteIn.Master" AutoEventWireup="true" CodeBehind="YqsbbUpsert.aspx.cs" Inherits="WebApplication4.Pages.YqsbbUpsert" %>
<%@ MasterType VirtualPath="~/SiteIn.Master" %> 
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1 class="h3 mb-2 text-gray-800">设备新增与编辑</h1>
    <p class="mb-4">在本页面可新增或修改设备记录  </p>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DataObjectTypeName="WebApplication4.Models.Yqsbb" InsertMethod="InsertYqsbb" SelectMethod="GetYqsbbs" TypeName="WebApplication4.BLL.YqsbBL" ConflictDetection="CompareAllValues" OldValuesParameterFormatString="orig{0}" UpdateMethod="UpdateYqsbb" OnUpdated="ObjectDataSource1_Updated" OnInserted="ObjectDataSource1_Inserted">
            <SelectParameters>
                <asp:QueryStringParameter Name="id" QueryStringField="id" Type="String" />
            </SelectParameters>
            <UpdateParameters>
                <asp:Parameter Name="yqsbb" Type="Object" />
                <asp:Parameter Name="origYqsbb" Type="Object" />
            </UpdateParameters>
        </asp:ObjectDataSource>
    <asp:ValidationSummary id="valSum" 
                          DisplayMode="BulletList"
                          EnableClientScript="true"
                          HeaderText="请注意下列问题：:"
                          runat="server"/>
        <asp:FormView ID="FormView1" runat="server" DataSourceID="ObjectDataSource1" DefaultMode="Insert">
            <EditItemTemplate>
                sxdm:
                <asp:TextBox ID="sxdmTextBox" runat="server" Text='<%# Bind("sxdm") %>' />
                <br />
                yqbh:
                <asp:TextBox ID="yqbhTextBox" runat="server" Text='<%# Bind("yqbh") %>' />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="yqbhTextBox" ErrorMessage="仪器编号不得为空">*</asp:RequiredFieldValidator>
                <br />
                flh:
                <asp:TextBox ID="flhTextBox" runat="server" Text='<%# Bind("flh") %>' />
                <br />
                yqmc:
                <asp:TextBox ID="yqmcTextBox" runat="server" Text='<%# Bind("yqmc") %>' />
                <br />
                xh:
                <asp:TextBox ID="xhTextBox" runat="server" Text='<%# Bind("xh") %>' />
                <br />
                gg:
                <asp:TextBox ID="ggTextBox" runat="server" Text='<%# Bind("gg") %>' />
                <br />
                yqly:
                <asp:TextBox ID="yqlyTextBox" runat="server" Text='<%# Bind("yqly") %>' />
                <br />
                gbm:
                <asp:TextBox ID="gbmTextBox" runat="server" Text='<%# Bind("gbm") %>' />
                <br />
                dj:
                <asp:TextBox ID="djTextBox" runat="server" Text='<%# Bind("dj") %>' />
                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="djTextBox" ErrorMessage="单价必须填写数字" Operator="DataTypeCheck" Type="Integer">*</asp:CompareValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="djTextBox" ErrorMessage="单价不得为空">*</asp:RequiredFieldValidator>
                <br />
                gzrq:
                <asp:TextBox ID="gzrqTextBox" runat="server" Text='<%# Bind("gzrq") %>' />
                <br />
                xzm:
                <asp:TextBox ID="xzmTextBox" runat="server" Text='<%# Bind("xzm") %>' />
                <br />
                xyfx:
                <asp:TextBox ID="xyfxTextBox" runat="server" Text='<%# Bind("xyfx") %>' />
                <br />
                dwbh:
                <asp:TextBox ID="dwbhTextBox" runat="server" Text='<%# Bind("dwbh") %>' />
                <br />
                dwmc:
                <asp:TextBox ID="dwmcTextBox" runat="server" Text='<%# Bind("dwmc") %>' />
                <br />
                <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="更新" />
                &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="取消" />
            </EditItemTemplate>
            <InsertItemTemplate>
                sxdm:
                <asp:TextBox ID="sxdmTextBox" runat="server" Text='<%# Bind("sxdm") %>' />
                
                <br />
                yqbh:
                <asp:TextBox ID="yqbhTextBox" runat="server" Text='<%# Bind("yqbh") %>' />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="yqbhTextBox" ErrorMessage="仪器编号不得为空">*</asp:RequiredFieldValidator>
                <br />
                flh:
                <asp:TextBox ID="flhTextBox" runat="server" Text='<%# Bind("flh") %>' />
                <br />
                yqmc:
                <asp:TextBox ID="yqmcTextBox" runat="server" Text='<%# Bind("yqmc") %>' />
                <br />
                xh:
                <asp:TextBox ID="xhTextBox" runat="server" Text='<%# Bind("xh") %>' />
                <br />
                gg:
                <asp:TextBox ID="ggTextBox" runat="server" Text='<%# Bind("gg") %>' />
                <br />
                yqly:
                <asp:TextBox ID="yqlyTextBox" runat="server" Text='<%# Bind("yqly") %>' />
                <br />
                gbm:
                <asp:TextBox ID="gbmTextBox" runat="server" Text='<%# Bind("gbm") %>' />
                <br />
                dj:
                <asp:TextBox ID="djTextBox" runat="server" Text='<%# Bind("dj") %>' />
                <asp:CompareValidator ID="CompareValidator2" runat="server" ErrorMessage="单价必须输入整数" Operator="DataTypeCheck" Type="Integer" ControlToValidate="djTextBox">*</asp:CompareValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="djTextBox" ErrorMessage="单价不得为空">*</asp:RequiredFieldValidator>
                <br />
                gzrq:
                <asp:TextBox ID="gzrqTextBox" runat="server" Text='<%# Bind("gzrq") %>' />
                <br />
                xzm:
                <asp:TextBox ID="xzmTextBox" runat="server" Text='<%# Bind("xzm") %>' />
                <br />
                xyfx:
                <asp:TextBox ID="xyfxTextBox" runat="server" Text='<%# Bind("xyfx") %>' />
                <br />
                dwbh:
                <asp:TextBox ID="dwbhTextBox" runat="server" Text='<%# Bind("dwbh") %>' />
                <br />
                dwmc:
                <asp:TextBox ID="dwmcTextBox" runat="server" Text='<%# Bind("dwmc") %>' />
                <br />
                <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="插入" />
                &nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="取消" />
            </InsertItemTemplate>
            <ItemTemplate>
                sxdm:
                <asp:Label ID="sxdmLabel" runat="server" Text='<%# Bind("sxdm") %>' />
                <br />
                yqbh:
                <asp:Label ID="yqbhLabel" runat="server" Text='<%# Bind("yqbh") %>' />
                <br />
                flh:
                <asp:Label ID="flhLabel" runat="server" Text='<%# Bind("flh") %>' />
                <br />
                yqmc:
                <asp:Label ID="yqmcLabel" runat="server" Text='<%# Bind("yqmc") %>' />
                <br />
                xh:
                <asp:Label ID="xhLabel" runat="server" Text='<%# Bind("xh") %>' />
                <br />
                gg:
                <asp:Label ID="ggLabel" runat="server" Text='<%# Bind("gg") %>' />
                <br />
                yqly:
                <asp:Label ID="yqlyLabel" runat="server" Text='<%# Bind("yqly") %>' />
                <br />
                gbm:
                <asp:Label ID="gbmLabel" runat="server" Text='<%# Bind("gbm") %>' />
                <br />
                dj:
                <asp:Label ID="djLabel" runat="server" Text='<%# Bind("dj") %>' />
                <br />
                gzrq:
                <asp:Label ID="gzrqLabel" runat="server" Text='<%# Bind("gzrq") %>' />
                <br />
                xzm:
                <asp:Label ID="xzmLabel" runat="server" Text='<%# Bind("xzm") %>' />
                <br />
                xyfx:
                <asp:Label ID="xyfxLabel" runat="server" Text='<%# Bind("xyfx") %>' />
                <br />
                dwbh:
                <asp:Label ID="dwbhLabel" runat="server" Text='<%# Bind("dwbh") %>' />
                <br />
                dwmc:
                <asp:Label ID="dwmcLabel" runat="server" Text='<%# Bind("dwmc") %>' />
                <br />
                <asp:LinkButton ID="EditButton" runat="server" CausesValidation="False" CommandName="Edit" Text="编辑" />
                &nbsp;<asp:LinkButton ID="NewButton" runat="server" CausesValidation="False" CommandName="New" Text="新建" />
            </ItemTemplate>
        </asp:FormView>

  
    
    

</asp:Content>
