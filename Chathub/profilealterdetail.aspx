<%@ Page Title="" Language="C#" MasterPageFile="~/Mstar.Master" AutoEventWireup="true" CodeBehind="profilealterdetail.aspx.cs" Inherits="Chathub.profilealterdetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="row-fluid">
        <div class="span12">
            <h3 class="page-title"></h3>

            <ul class="breadcrumb">
                <li>
                    <i class="icon-eye-open"></i>
                     Profile Management Detail
                </li>

            </ul>

        </div>
    </div>


    Privacy: <asp:DropDownList ID="ddlAudi" CssClass="dropdown" runat="server" DataTextField="AudienceName" DataValueField="id" DataSourceID="obsGetAudienceLock"></asp:DropDownList>
                  
     <asp:ObjectDataSource ID="obsGetAudienceLock" runat="server" SelectMethod="GetAudienceLock" TypeName="Chathub.Methodsall"></asp:ObjectDataSource>

      <asp:Panel ID="PngGender" Visible="false" runat="server">
          Gender:
          <asp:RadioButton ID="rbmale" Checked="true" GroupName="g" Text="Male" runat="server" />
          <asp:RadioButton ID="rbfemale" GroupName="g" Text="Female" runat="server" /><br />
           <asp:Button ID="btnGenderSubmit" OnClick="btnGenderSubmit_Click" Text="Submit" runat="server"  CssClass="btn" />
                   
      </asp:Panel>

      <asp:Panel ID="pnlDOB" Visible="false" runat="server">
          Date Of Birth:
           <asp:DropDownList ID="ddlmonth" CssClass="dropdown" runat="server">
                        <asp:ListItem Value="0">--Month--</asp:ListItem>
                        <asp:ListItem Value="01">Jan</asp:ListItem>
                        <asp:ListItem Value="02">Feb</asp:ListItem>
                        <asp:ListItem Value="03">March</asp:ListItem>
                        <asp:ListItem Value="04">Apr</asp:ListItem>
                        <asp:ListItem Value="05">May</asp:ListItem>
                        <asp:ListItem Value="06">June</asp:ListItem>
                        <asp:ListItem Value="07">July</asp:ListItem>
                        <asp:ListItem Value="08">Aug</asp:ListItem>
                        <asp:ListItem Value="09">Sep</asp:ListItem>
                        <asp:ListItem Value="10">Oct</asp:ListItem>
                        <asp:ListItem Value="11">Nov</asp:ListItem>
                        <asp:ListItem Value="12">Desc</asp:ListItem>
                    </asp:DropDownList>
                    <asp:DropDownList ID="ddlday" CssClass="dropdown" runat="server">
                        <asp:ListItem Value="0">--Day--</asp:ListItem>
                        <asp:ListItem Value="01">1</asp:ListItem>
                        <asp:ListItem Value="02">2</asp:ListItem>
                        <asp:ListItem Value="03">3</asp:ListItem>
                        <asp:ListItem Value="04">4</asp:ListItem>
                        <asp:ListItem Value="05">5</asp:ListItem>
                        <asp:ListItem Value="06">6</asp:ListItem>
                        <asp:ListItem Value="07">7</asp:ListItem>
                        <asp:ListItem Value="08">8</asp:ListItem>
                        <asp:ListItem Value="09">9</asp:ListItem>
                        <asp:ListItem Value="10">10</asp:ListItem>
                        <asp:ListItem Value="11">11</asp:ListItem>
                        <asp:ListItem Value="12">12</asp:ListItem>
                        <asp:ListItem Value="13">13</asp:ListItem>
                        <asp:ListItem Value="14">14</asp:ListItem>
                        <asp:ListItem Value="15">15</asp:ListItem>
                        <asp:ListItem Value="16">16</asp:ListItem>
                        <asp:ListItem Value="17">17</asp:ListItem>
                        <asp:ListItem Value="18">18</asp:ListItem>
                        <asp:ListItem Value="19">19</asp:ListItem>
                        <asp:ListItem Value="20">20</asp:ListItem>
                        <asp:ListItem Value="21">21</asp:ListItem>
                        <asp:ListItem Value="22">22</asp:ListItem>
                        <asp:ListItem Value="23">23</asp:ListItem>
                        <asp:ListItem Value="24">24</asp:ListItem>
                        <asp:ListItem Value="25">25</asp:ListItem>
                        <asp:ListItem Value="26">26</asp:ListItem>
                        <asp:ListItem Value="27">27</asp:ListItem>
                        <asp:ListItem Value="28">28</asp:ListItem>
                        <asp:ListItem Value="29">29</asp:ListItem>
                        <asp:ListItem Value="30">30</asp:ListItem>
                        <asp:ListItem Value="31">31</asp:ListItem>
                    </asp:DropDownList>
                    <asp:DropDownList ID="ddlyear" CssClass="dropdown" runat="server">
                        <asp:ListItem Value="0">--Year--</asp:ListItem>
                        <asp:ListItem Value="2012">2012</asp:ListItem>
                        <asp:ListItem Value="2011">2011</asp:ListItem>
                        <asp:ListItem Value="2010">2010</asp:ListItem>
                        <asp:ListItem Value="2009">2009</asp:ListItem>
                        <asp:ListItem Value="2008">2008</asp:ListItem>
                        <asp:ListItem Value="2007">2007</asp:ListItem>
                        <asp:ListItem Value="2006">2006</asp:ListItem>
                        <asp:ListItem Value="2005">2005</asp:ListItem>
                        <asp:ListItem Value="2004">2004</asp:ListItem>
                        <asp:ListItem Value="2003">2003</asp:ListItem>
                        <asp:ListItem Value="2002">2002</asp:ListItem>
                        <asp:ListItem Value="2001">2001</asp:ListItem>
                        <asp:ListItem Value="2000">2000</asp:ListItem>
                        <asp:ListItem Value="1999">1999</asp:ListItem>
                        <asp:ListItem Value="1998">1998</asp:ListItem>
                        <asp:ListItem Value="1997">1997</asp:ListItem>
                        <asp:ListItem Value="1996">1996</asp:ListItem>
                        <asp:ListItem Value="1995">1995</asp:ListItem>
                        <asp:ListItem Value="1994">1994</asp:ListItem>
                        <asp:ListItem Value="1993">1993</asp:ListItem>
                        <asp:ListItem Value="1992">1992</asp:ListItem>
                        <asp:ListItem Value="1991">1991</asp:ListItem>
                        <asp:ListItem Value="1990">1990</asp:ListItem>
                        <asp:ListItem Value="1989">1989</asp:ListItem>
                        <asp:ListItem Value="1988">1988</asp:ListItem>
                        <asp:ListItem Value="1987">1987</asp:ListItem>
                        <asp:ListItem Value="1986">1986</asp:ListItem>
                        <asp:ListItem Value="1985">1985</asp:ListItem>
                        <asp:ListItem Value="1984">1984</asp:ListItem>
                        <asp:ListItem Value="1983">1983</asp:ListItem>
                        <asp:ListItem Value="1982">1982</asp:ListItem>
                        <asp:ListItem Value="1981">1981</asp:ListItem>
                        <asp:ListItem Value="1980">1980</asp:ListItem>
                        <asp:ListItem Value="1979">1979</asp:ListItem>
                        <asp:ListItem Value="1978">1978</asp:ListItem>
                        <asp:ListItem Value="1977">1977</asp:ListItem>
                        <asp:ListItem Value="1976">1976</asp:ListItem>
                        <asp:ListItem Value="1975">1975</asp:ListItem>
                        <asp:ListItem Value="1974">1974</asp:ListItem>
                        <asp:ListItem Value="1973">1973</asp:ListItem>
                        <asp:ListItem Value="1972">1972</asp:ListItem>
                        <asp:ListItem Value="1971">1971</asp:ListItem>
                        <asp:ListItem Value="1970">1970</asp:ListItem>
                        <asp:ListItem Value="1969">1969</asp:ListItem>
                        <asp:ListItem Value="1968">1968</asp:ListItem>
                        <asp:ListItem Value="1967">1967</asp:ListItem>
                        <asp:ListItem Value="1966">1966</asp:ListItem>
                        <asp:ListItem Value="1965">1965</asp:ListItem>
                        <asp:ListItem Value="1964">1964</asp:ListItem>
                        <asp:ListItem Value="1963">1963</asp:ListItem>
                        <asp:ListItem Value="1962">1962</asp:ListItem>
                        <asp:ListItem Value="1961">1961</asp:ListItem>
                        <asp:ListItem Value="1960">1960</asp:ListItem>
                        <asp:ListItem Value="1959">1959</asp:ListItem>
                        <asp:ListItem Value="1958">1958</asp:ListItem>
                        <asp:ListItem Value="1957">1957</asp:ListItem>
                        <asp:ListItem Value="1956">1956</asp:ListItem>
                        <asp:ListItem Value="1955">1955</asp:ListItem>
                        <asp:ListItem Value="1954">1954</asp:ListItem>
                        <asp:ListItem Value="1953">1953</asp:ListItem>
                        <asp:ListItem Value="1952">1952</asp:ListItem>
                        <asp:ListItem Value="1951">1951</asp:ListItem>
                        <asp:ListItem Value="1950">1950</asp:ListItem>
                        <asp:ListItem Value="1949">1949</asp:ListItem>
                        <asp:ListItem Value="1948">1948</asp:ListItem>
                        <asp:ListItem Value="1947">1947</asp:ListItem>
                        <asp:ListItem Value="1946">1946</asp:ListItem>
                        <asp:ListItem Value="1945">1945</asp:ListItem>
                        <asp:ListItem Value="1944">1944</asp:ListItem>
                        <asp:ListItem Value="1943">1943</asp:ListItem>
                        <asp:ListItem Value="1942">1942</asp:ListItem>
                        <asp:ListItem Value="1941">1941</asp:ListItem>
                        <asp:ListItem Value="1940">1940</asp:ListItem>
                        <asp:ListItem Value="1939">1939</asp:ListItem>
                        <asp:ListItem Value="1938">1938</asp:ListItem>
                        <asp:ListItem Value="1937">1937</asp:ListItem>
                        <asp:ListItem Value="1936">1936</asp:ListItem>
                        <asp:ListItem Value="1935">1935</asp:ListItem>
                        <asp:ListItem Value="1934">1934</asp:ListItem>
                        <asp:ListItem Value="1933">1933</asp:ListItem>
                        <asp:ListItem Value="1932">1932</asp:ListItem>
                        <asp:ListItem Value="1931">1931</asp:ListItem>
                        <asp:ListItem Value="1930">1930</asp:ListItem>
                        <asp:ListItem Value="1929">1929</asp:ListItem>
                        <asp:ListItem Value="1928">1928</asp:ListItem>
                        <asp:ListItem Value="1927">1927</asp:ListItem>
                        <asp:ListItem Value="1926">1926</asp:ListItem>
                        <asp:ListItem Value="1925">1925</asp:ListItem>
                        <asp:ListItem Value="1924">1924</asp:ListItem>
                        <asp:ListItem Value="1923">1923</asp:ListItem>
                        <asp:ListItem Value="1922">1922</asp:ListItem>
                        <asp:ListItem Value="1921">1921</asp:ListItem>
                        <asp:ListItem Value="1920">1920</asp:ListItem>
                        <asp:ListItem Value="1919">1919</asp:ListItem>
                        <asp:ListItem Value="1918">1918</asp:ListItem>
                        <asp:ListItem Value="1917">1917</asp:ListItem>
                        <asp:ListItem Value="1916">1916</asp:ListItem>
                        <asp:ListItem Value="1915">1915</asp:ListItem>
                        <asp:ListItem Value="1914">1914</asp:ListItem>
                        <asp:ListItem Value="1913">1913</asp:ListItem>
                        <asp:ListItem Value="1912">1912</asp:ListItem>
                        <asp:ListItem Value="1911">1911</asp:ListItem>
                        <asp:ListItem Value="1910">1910</asp:ListItem>
                        <asp:ListItem Value="1909">1909</asp:ListItem>
                        <asp:ListItem Value="1908">1908</asp:ListItem>
                        <asp:ListItem Value="1907">1907</asp:ListItem>
                        <asp:ListItem Value="1906">1906</asp:ListItem>
                        <asp:ListItem Value="1905">1905</asp:ListItem>
                    </asp:DropDownList>
          <br />
           <asp:Button ID="btnDOB" OnClick="btnDOB_Click" Text="Submit" runat="server"  CssClass="btn" />
            
      </asp:Panel>


    <asp:Panel ID="PnlRelationShip" Visible="false" runat="server">
        RelationShip:
          <asp:DropDownList ID="ddlRelationShip" CssClass="dropdown" runat="server">
                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                        <asp:ListItem Value="01">Single</asp:ListItem>
                        <asp:ListItem Value="02">In a relationship</asp:ListItem>
                        <asp:ListItem Value="03">Engaged</asp:ListItem>
                        <asp:ListItem Value="04">Married</asp:ListItem>
                        <asp:ListItem Value="05">It's complicated</asp:ListItem>
                        <asp:ListItem Value="06">In an open relationship</asp:ListItem>
                        <asp:ListItem Value="07">Separated</asp:ListItem>
                        <asp:ListItem Value="08">Widowed</asp:ListItem>
                        <asp:ListItem Value="09">Divorced</asp:ListItem>
                        
        </asp:DropDownList>

        <br />
        <asp:Button ID="btnRelationship" OnClick="btnRelationship_Click" Text="Submit" runat="server"  CssClass="btn" />
      </asp:Panel>



    <asp:Panel ID="pnlInterestedIn" Visible="false" runat="server">
        Interested In:<br />
        <asp:CheckBox ID="chkMen" runat="server" Text="Men" style="float:left; margin-right:20px;" />
        <asp:CheckBox ID="chkWomen" Text="Women" style="float:left; margin-right:10px;" runat="server" />
        <br />
        <asp:Button ID="btnInterestedIn" OnClick="btnInterestedIn_Click" Text="Submit" runat="server"  CssClass="btn" />
      </asp:Panel>



    <asp:Panel ID="pnlLanguages" Visible="false" runat="server">
        <br /> Languages:       

        <asp:TextBox ID="txtLanguages" runat="server" CssClass="tbox"></asp:TextBox>
        <br />
        <asp:Button ID="btnLanguages" OnClick="btnLanguages_Click" Text="Submit" runat="server"  CssClass="btn" />
      </asp:Panel>


    <asp:Panel ID="pnlPolitical" Visible="false" runat="server">
        <br /> Political Views
        <asp:TextBox ID="txtPolitical" runat="server" CssClass="tbox"></asp:TextBox>
        <br />
        <asp:Button ID="btnPolitical" OnClick="btnPolitical_Click" Text="Submit" runat="server"  CssClass="btn" />
      </asp:Panel>




    <asp:Panel ID="pnlReligion" Visible="false" runat="server">
       <br />  Religion:       
         <asp:TextBox ID="txtReligion" runat="server" CssClass="tbox"></asp:TextBox>
        <br />
        <asp:Button ID="btnReligion" OnClick="btnReligion_Click" Text="Submit" runat="server"  CssClass="btn" />
      </asp:Panel>


    <asp:Panel ID="pnlCompany" Visible="false" runat="server">
        <br />Company:       
         <asp:TextBox ID="txtCompany" runat="server" CssClass="tbox"></asp:TextBox>
        <br />
        <asp:Button ID="btnCompany" OnClick="btnCompany_Click" Text="Submit" runat="server"  CssClass="btn" />
      </asp:Panel>



    <asp:Panel ID="pnlPosition" Visible="false" runat="server">
         <br />Position :       
         <asp:TextBox ID="txtPosition" runat="server" CssClass="tbox"></asp:TextBox>
        <br />
        <asp:Button ID="btnPosition" OnClick="btnPosition_Click" Text="Submit" runat="server"  CssClass="btn" />
      </asp:Panel>

    
    <asp:Panel ID="pnlGradSchool" Visible="false" runat="server">
        <br />Grad School:

        <asp:TextBox ID="txtGrad" runat="server" CssClass="tbox"></asp:TextBox>
        <br />
        <asp:Button ID="btnGrad" OnClick="btnGrad_Click" Text="Submit" runat="server"  CssClass="btn" />
      </asp:Panel>


     <asp:Panel ID="pnlCollege" Visible="false" runat="server">
         <br />College:
         <asp:TextBox ID="txtCollege" runat="server" CssClass="tbox"></asp:TextBox>
        <br />
        <asp:Button ID="btnCollege" OnClick="btnCollege_Click" Text="Submit" runat="server"  CssClass="btn" />
      </asp:Panel>

    <asp:Panel ID="pnlHighSchool" Visible="false" runat="server">
         <br /> High School:
         <asp:TextBox ID="txtHighSchool" runat="server" CssClass="tbox"></asp:TextBox>
        <br />
        <asp:Button ID="btnHighSchool" OnClick="btnHighSchool_Click" Text="Submit" runat="server"  CssClass="btn" />
      </asp:Panel>


    <asp:Panel ID="pnlCurrentcity" Visible="false" runat="server">
         <br />Current City: 
         <asp:TextBox ID="txtCurrentcity" runat="server" CssClass="tbox"></asp:TextBox>
        <br />
        <asp:Button ID="btnCurrentcity" OnClick="btnCurrentcity_Click" Text="Submit" runat="server"  CssClass="btn" />
      </asp:Panel>


    <asp:Panel ID="pnlHometown" Visible="false" runat="server">
         <br />Hometown:       
         <asp:TextBox ID="txtHometown" runat="server" CssClass="tbox"></asp:TextBox>
        <br />
        <asp:Button ID="btnHometown" OnClick="btnHometown_Click" Text="Submit" runat="server"  CssClass="btn" />
      </asp:Panel>


    <asp:Panel ID="pnlProfile" Visible="false" runat="server">
         <br /> Profile :
         <asp:TextBox ID="txtProfile" runat="server" CssClass="tbox"></asp:TextBox>
        <br />
        <asp:Button ID="btnProfile" OnClick="btnProfile_Click" Text="Submit" runat="server"  CssClass="btn" />
      </asp:Panel>



     <asp:Panel ID="pnlEmail" Visible="false" runat="server">
         <br />  Email:       
         <asp:TextBox ID="txtEmail" runat="server" CssClass="tbox"></asp:TextBox>
        <br />
        <asp:Button ID="btnEmail" OnClick="btnEmail_Click" Text="Submit" runat="server"  CssClass="btn" />
      </asp:Panel>


     <asp:Panel ID="pnlAIM" Visible="false" runat="server">
         <br />  AIM:       
         <asp:TextBox ID="txtAIM" runat="server" CssClass="tbox"></asp:TextBox>
        <br />
        <asp:Button ID="btnAIM" OnClick="btnAIM_Click" Text="Submit" runat="server"  CssClass="btn" />
      </asp:Panel>



     <asp:Panel ID="pnlPhones" Visible="false" runat="server">
         <br />  Phones:       
         <asp:TextBox ID="txtPhones" runat="server" CssClass="tbox"></asp:TextBox>
        <br />
        <asp:Button ID="btnPhones" OnClick="btnPhones_Click" Text="Submit" runat="server"  CssClass="btn" />
      </asp:Panel>


     <asp:Panel ID="pnlWebsite" Visible="false" runat="server">
         <br />  Website:       
         <asp:TextBox ID="txtWebsite" runat="server" CssClass="tbox"></asp:TextBox>
        <br />
        <asp:Button ID="btnWebsite" OnClick="btnWebsite_Click" Text="Submit" runat="server"  CssClass="btn" />
      </asp:Panel>

     <asp:Panel ID="pnlAddress" Visible="false" runat="server">
         <br />  Address:       
         <asp:TextBox ID="txtAddress" runat="server" CssClass="tbox"></asp:TextBox>
        <br />
        <asp:Button ID="btnAddress" OnClick="btnAddress_Click" Text="Submit" runat="server"  CssClass="btn" />
      </asp:Panel>


     <asp:Panel ID="pnlNeighborhood" Visible="false" runat="server">
         <br />  Neighborhood:
         <asp:TextBox ID="txtNeighborhood" runat="server" CssClass="tbox"></asp:TextBox>
        <br />
        <asp:Button ID="btnNeighborhood" OnClick="btnNeighborhood_Click" Text="Submit" runat="server"  CssClass="btn" />
      </asp:Panel>

     <asp:Panel ID="pnlQuotes" Visible="false" runat="server">
         <br />  Quotes:       
         <asp:TextBox ID="txtQuotes" runat="server" CssClass="tbox"></asp:TextBox>
        <br />
        <asp:Button ID="btnQuotes" OnClick="btnQuotes_Click" Text="Submit" runat="server"  CssClass="btn" />
      </asp:Panel>


     <asp:Panel ID="pnlBio" Visible="false" runat="server">
         <br />  Bio:
         <asp:TextBox ID="txtBio" runat="server" CssClass="tbox"></asp:TextBox>
        <br />
        <asp:Button ID="btnBio" OnClick="btnBio_Click" Text="Submit" runat="server"  CssClass="btn" />
      </asp:Panel>

     <asp:Panel ID="pnlBrother" Visible="false" runat="server">
         <br />  Brother:
         <asp:TextBox ID="txtBrother" runat="server" CssClass="tbox"></asp:TextBox>
        <br />
        <asp:Button ID="btnBrother" OnClick="btnBrother_Click" Text="Submit" runat="server"  CssClass="btn" />
      </asp:Panel>


      <asp:Panel ID="pnlSister" Visible="false" runat="server">
         <br />  Sister:       
         <asp:TextBox ID="txtSister" runat="server" CssClass="tbox"></asp:TextBox>
        <br />
        <asp:Button ID="btnSister" OnClick="btnSister_Click" Text="Submit" runat="server"  CssClass="btn" />
      </asp:Panel>


      <asp:Panel ID="pnlFather" Visible="false" runat="server">
         <br />  Father:       
         <asp:TextBox ID="txtFather" runat="server" CssClass="tbox"></asp:TextBox>
        <br />
        <asp:Button ID="btnFather" OnClick="btnFather_Click" Text="Submit" runat="server"  CssClass="btn" />
      </asp:Panel>

      <asp:Panel ID="pnlMother" Visible="false" runat="server">
         <br />  Mother:       
         <asp:TextBox ID="txtMother" runat="server" CssClass="tbox"></asp:TextBox>
        <br />
        <asp:Button ID="btnMother" OnClick="btnMother_Click" Text="Submit" runat="server"  CssClass="btn" />
      </asp:Panel>


      <asp:Panel ID="Panel3" Visible="false" runat="server">
         <br />  :
         <asp:TextBox ID="TextBox3" runat="server" CssClass="tbox"></asp:TextBox>
        <br />
        <asp:Button ID="Button3" Text="Submit" runat="server"  CssClass="btn" />
      </asp:Panel>



    


      <asp:Panel ID="pnlQuotations" Visible="false" runat="server">
         <br />  Quotations: 
         <asp:TextBox ID="txtQuotations" runat="server" CssClass="tbox"></asp:TextBox>
        <br />
        <asp:Button ID="btnQuotations" OnClick="btnQuotations_Click" Text="Submit" runat="server"  CssClass="btn" />
      </asp:Panel>

      <asp:Panel ID="Panel7" Visible="false" runat="server">
         <br />  :
         <asp:TextBox ID="TextBox7" runat="server" CssClass="tbox"></asp:TextBox>
        <br />
        <asp:Button ID="Button7" Text="Submit" runat="server"  CssClass="btn" />
      </asp:Panel>



    <asp:Label ID="lblMsg" ForeColor="Green" runat="server" ></asp:Label>

    <asp:HiddenField ID="hideurl" runat="server" />
</asp:Content>
