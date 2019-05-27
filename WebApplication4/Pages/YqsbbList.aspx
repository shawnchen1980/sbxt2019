<%@ Page Title="" Language="C#" MasterPageFile="~/SiteIn.Master" AutoEventWireup="true" CodeBehind="YqsbbList.aspx.cs" Inherits="WebApplication4.WebForm1" %>
<%@ MasterType VirtualPath="~/SiteIn.Master" %> 
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="TopbarSearch" runat="server">
    <form class="d-none d-sm-inline-block form-inline mr-auto ml-md-3 my-2 my-md-0 mw-100 navbar-search">
            <div class="input-group">
<asp:TextBox id="searchParam" runat="server" class="form-control bg-light border-0 small" placeholder="输入要查询的设备编号，不输入则查询所有设备" aria-label="Search" aria-describedby="basic-addon2"></asp:TextBox>
              <%--<input type="text" id="searchParam" runat="server" class="form-control bg-light border-0 small" placeholder="Search for..." aria-label="Search" aria-describedby="basic-addon2">--%>
              <div class="input-group-append">

<asp:LinkButton ID="btnSearch" runat="server" class="btn btn-primary" Text="Button" OnClick="btnSearch_Click" ><i class="fas fa-search fa-sm"></i></asp:LinkButton>
                <%--<button ID="btnSearch" runat="server" class="btn btn-primary" >
                  <i class="fas fa-search fa-sm"></i>
                </button>--%>
              </div>
            </div>
          </form>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="d-sm-flex align-items-center justify-content-between mb-4">
    <h1 class="h3 mb-2 text-gray-800" style="flex:1 0 auto;margin-right:1rem;">设备浏览</h1>
        <div class="input-group">
  <div class="custom-file">
    <input type="file" class="custom-file-input" id="myFile" name="myFile" lang="cn">
    <label class="custom-file-label" for="myFile" data-browse="浏览">选取文件</label>
  </div>
            <script>
                $('#myFile').on('change',function(){
                //get the file name
                var fileName = $(this).val();
                //replace the "Choose a file" label
                $(this).next('.custom-file-label').html(fileName);
            })
        </script>
  <div class="input-group-append">
   
      <asp:LinkButton ID="btnUpload" CssClass="d-none d-sm-inline-block btn btn-sm btn-primary shadow-sm" runat="server" OnClick="btnUploadClick"><i class="fas fa-upload fa-sm text-white-50"></i> 列表上传</asp:LinkButton>

      <asp:LinkButton ID="LinkButton1" CssClass="d-none d-sm-inline-block btn btn-sm btn-primary shadow-sm" runat="server" OnClick="LinkButton1_Click"><i class="fas fa-download fa-sm text-white-50"></i> 列表导出</asp:LinkButton>
  </div>
</div>
        
    </div>
    <p class="mb-4">在本页面可进行设备浏览与删除操作 </p>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetYqsbbs" TypeName="WebApplication4.BLL.YqsbBL" OnSelecting="ObjectDataSource1_Selecting">
        <SelectParameters>
            <asp:ControlParameter ControlID="TopbarSearch$searchParam" ConvertEmptyStringToNull="False" DefaultValue="&quot;&quot;" Name="id" PropertyName="Text" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1" CssClass="table table-bordered dataTable" AllowPaging="True" DataKeyNames="yqbh" OnPageIndexChanging="PaginateTheData" OnRowDataBound="ReSelectSelectedRecords" PageSize="5">
        <Columns>
            <asp:TemplateField HeaderText="Select"> 
                    <ItemTemplate> 
                        <asp:CheckBox ID="chkSelect" runat="server" /> 
                    </ItemTemplate> 
                </asp:TemplateField> 
            <asp:BoundField DataField="yqbh" HeaderText="yqbh" SortExpression="yqbh" />
            <asp:BoundField DataField="yqmc" HeaderText="yqmc" SortExpression="yqmc" />
            
            <asp:BoundField DataField="dj" HeaderText="dj" SortExpression="dj" />
            <asp:BoundField DataField="dwbh" HeaderText="dwbh" SortExpression="dwbh" />
            <asp:BoundField DataField="dwmc" HeaderText="dwmc" SortExpression="dwmc" />
            <asp:HyperLinkField Text="编辑" DataNavigateUrlFormatString="~/Pages/YqsbbUpsert.aspx?id={0}&op=edit"
    DataNavigateUrlFields="yqbh" HeaderText="选择" />
        </Columns>
        
    </asp:GridView>
<asp:LinkButton ID="btnDelete" CssClass="d-none d-sm-inline-block btn btn-sm btn-primary shadow-sm" runat="server" OnClick="btnDelete_Click"><i class="fas fa-trash-alt fa-sm text-white-50"></i> 删除选中项</asp:LinkButton>

   
</asp:Content>
