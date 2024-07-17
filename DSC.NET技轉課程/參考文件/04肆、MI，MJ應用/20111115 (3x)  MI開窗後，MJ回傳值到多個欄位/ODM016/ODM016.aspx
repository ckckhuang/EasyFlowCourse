<%@ Page Language="c#" CodeFile="ODM016.aspx.cs" MasterPageFile="~/src/_Common/AppUtil/EFMasterPage/EFBaseMasterPage.master"
    AutoEventWireup="false" Inherits="tw.com.dsc.easyflowDotNet.forms.ODM016" %>

<%@ Register TagPrefix="cc1" Namespace="tw.com.dsc.dscDotNet.dscWebControls" Assembly="PlatformUtil" %>
<%@ Register TagPrefix="iewc" Namespace="Microsoft.Web.UI.WebControls" Assembly="Microsoft.Web.UI.WebControls" %>
<%@ Register TagPrefix="uc1" TagName="gridUserControl" Src="../../_Common/PlatformUtil/KernelPage/Grid/gridUserControl.ascx" %>
<asp:Content ID="ODM016FormContent" ContentPlaceHolderID="MasterPageContent" runat="server">
    <!--單檔架構 -->

    <script src="../../_Common/JS/jquery-Released.js" type="text/javascript"></script>

    <script src="ODM016.js" type="text/javascript"></script>

    <!--2009/03/19:Joseph:<div id="cover" style="OVERFLOW: auto; WIDTH: 100%;">-->
    <div id="cover" style="width: 100%;">
        <div id="createRecord" style="width: 100%; height: 100%" runat="server">
            <cc1:DscPanel ID="ecPnlMaster" runat="server" Width="98%" IniHTML='&#10;<div style="OVERFLOW: auto; WIDTH: 100%; POSITION: relative; HEIGHT: 100%" ms_positioning="GridLayout"></div>'
                FrmDefineKeys-FrmType="Query" FrmDefineKeys-FrmID="FrmODM016" FrmDefineKeys-BOID="ODM016"
                BorderStyle="None" BorderColor="Transparent" BorderWidth="0px" Height="195px">
                <!--單頭頁籤-->
                <iewc:TabStrip ID="TabStrip1" runat="server" TabDefaultStyle="background-image:url(../../_Common/AppUtil/Themes/images/Menu/Tbtn01.gif);"
                    TabHoverStyle="background-image:url(../../_Common/AppUtil/Themes/images/Menu/Tbtn01.gif);"
                    TabSelectedStyle="background-image:url(../../_Common/AppUtil/Themes/images/Menu/Tbtn02.gif);"
                    CssClass="divToolBar2">
                    <iewc:Tab Text="*MJ回傳多個值" DefaultStyle="width:100px; height:27px;vertical-align:middle; text-align:center;"
                        ID="Tab1"></iewc:Tab>
                </iewc:TabStrip>
                <!--單頭頁籤畫面集合-->
                <!--預設放入一個DIV-->
                <cc1:DscPanel ID="divheadDefault" Style="display: block" runat="server" Width="100%"
                    Height="195px" BackColor="Transparent">
                    <div class="TabPage" style="position: relative; height: 195px; left: 0px; top: 0px;">
                        <asp:ValidationSummary ID="ValidationSummary1" Style="z-index: 100; left: 745px;
                            position: absolute; top: 7px" runat="server" ShowSummary="False" ShowMessageBox="True">
                        </asp:ValidationSummary>
                        <!--此區間放入各種dsc元件-->
                        <cc1:DscOpenQuery ID="odm016003" Title="員工" Style="z-index: 700; left: 106px; position: absolute;
                            top: 24px" runat="server" TxtInput_TabIndex="101" ReturnVisible="True" ImgSrc="../../_Common/AppUtil/Themes/images/Program/imgMan.gif"
                            Text2Visible="True" RetuenVisible="True" BtnVisible="True" TitleWidth="120px"
                            ShowTitle="True" InputEnabled="True" TitleLocation="_Left" TextMode="SingleLine"
                            Cellpanding="0">
                            <TitleStyle Width="100px"></TitleStyle>
                            <InputStyle Width="120px" Height="25px" CssClass="Edit20" BackColor="White"></InputStyle>
                            <Validator ValidatorName="" MsgF0002="" MsgF0001="" ValidatorExpression="" ValidatorMsg="">
                            </Validator>
                            <FrmFieldKeys FrmID="FrmODM016" BOID="ODM016" FieldName="odm016003"></FrmFieldKeys>
                        </cc1:DscOpenQuery>
                        <cc1:DscOpenQuery ID="odm016004" Title="直屬主管" Style="z-index: 699; left: 106px; position: absolute;
                            top: 83px" runat="server" TxtInput_TabIndex="102" ReturnVisible="True" ImgSrc="../../_Common/AppUtil/Themes/images/Program/imgMan.gif"
                            Text2Visible="True" RetuenVisible="True" BtnVisible="True" TitleWidth="120px"
                            ShowTitle="True" InputEnabled="True" TitleLocation="_Left" TextMode="SingleLine"
                            Cellpanding="0">
                            <TitleStyle Width="100px"></TitleStyle>
                            <InputStyle Width="120px" Height="25px" CssClass="Edit20" BackColor="White"></InputStyle>
                            <Validator ValidatorName="" MsgF0002="" MsgF0001="" ValidatorExpression="" ValidatorMsg="">
                            </Validator>
                            <FrmFieldKeys FrmID="FrmODM016" BOID="ODM016" FieldName="odm016004"></FrmFieldKeys>
                        </cc1:DscOpenQuery>
                        <cc1:DscOpenQuery ID="odm016005" Title="主要部門" Style="z-index: 698; left: 106px; position: absolute;
                            top: 120px" runat="server" TxtInput_TabIndex="103" ReturnVisible="True" ImgSrc="../../_Common/AppUtil/Themes/images/Program/data.gif"
                            Text2Visible="True" RetuenVisible="True" BtnVisible="True" TitleWidth="120px"
                            ShowTitle="True" InputEnabled="True" TitleLocation="_Left" TextMode="SingleLine"
                            Cellpanding="0">
                            <TitleStyle Width="100px"></TitleStyle>
                            <InputStyle Width="120px" Height="25px" CssClass="Edit20" BackColor="White"></InputStyle>
                            <Validator ValidatorName="" MsgF0002="" MsgF0001="" ValidatorExpression="" ValidatorMsg="">
                            </Validator>
                            <FrmFieldKeys FrmID="FrmODM016" BOID="ODM016" FieldName="odm016005"></FrmFieldKeys>
                        </cc1:DscOpenQuery>
                        <cc1:DscTextBox ID="odm016006" Title="職務" Style="z-index: 697; left: 379px; position: absolute;
                            top: 83px" runat="server" LangText="職務" Cellpanding="0" TitleWidth="120px" TxtInput_TabIndex="104"
                            border="0" CellNo1CssClass="" CellNo2CssClass="" cellpadding="0" cellspacing="0"
                            Text="" TitleType="TitleLang01">
                            <FrmFieldKeys FrmID="FrmODM016" BOID="ODM016" FieldName="odm016006"></FrmFieldKeys>
                            <TitleStyle Width="100px"></TitleStyle>
                            <InputStyle Width="120px" Height="25px" CssClass="Edit20"></InputStyle>
                            <Validator ValidatorMsg="" ValidatorExpression="" MsgF0001="" MsgF0002="" ValidatorName="">
                            </Validator>
                        </cc1:DscTextBox>
                        <cc1:DscTextBox ID="odm016007" Title="職稱" Style="z-index: 696; left: 379px; position: absolute;
                            top: 120px" runat="server" LangText="職稱" Cellpanding="0" TitleWidth="120px" TxtInput_TabIndex="105"
                            border="0" CellNo1CssClass="" CellNo2CssClass="" cellpadding="0" cellspacing="0"
                            Text="" TitleType="TitleLang01">
                            <FrmFieldKeys FrmID="FrmODM016" BOID="ODM016" FieldName="odm016007"></FrmFieldKeys>
                            <TitleStyle Width="100px"></TitleStyle>
                            <InputStyle Width="120px" Height="25px" CssClass="Edit20"></InputStyle>
                            <Validator ValidatorMsg="" ValidatorExpression="" MsgF0001="" MsgF0002="" ValidatorName="">
                            </Validator>
                        </cc1:DscTextBox>
                    </div>
                </cc1:DscPanel>
                <!--有單身才放-->
                <!--單身頁籤起始-->
                <!--單身Grid-->
                <!--此區間放入數個單身Grid-->
                <cc1:DscPanel ID="hdnDisplayInCS" Style="display: none; z-index: 116; left: 264px;
                    top: 72px" runat="server" Width="100%">
                    <div style="overflow: auto; width: 100%; position: relative; height: 100%; background-color: transparent;
                        left: 0px; top: 0px;">
                    </div>
                </cc1:DscPanel>
                <cc1:DscPanel ID="hdnDisplayInHTML" Style="display: none; z-index: 116; left: 264px;
                    top: 72px" runat="server">
                    <div style="overflow: auto; width: 100%; position: relative; height: 100%; background-color: transparent">
                        <cc1:DscTextBox ID="odm016001" Title="DscTextBox:" Style="z-index: 101; left: 245px;
                            position: absolute; top: 16px" runat="server" Cellpanding="2" TitleWidth="110px"
                            border="0" CellNo1CssClass="" CellNo2CssClass="" cellpadding="2" cellspacing="0"
                            LangText="DscTextBox:" TitleType="TitleLang01" TxtInput_TabIndex="0">
                            <InputStyle Width="120px"></InputStyle>
                            <TitleStyle Width="110px"></TitleStyle>
                            <FrmFieldKeys FrmID="FrmODM016" BOID="ODM016" FieldName="odm016001"></FrmFieldKeys>
                            <Validator MsgF0001="" MsgF0002="" ValidatorExpression="" ValidatorMsg="" ValidatorName="" />
                        </cc1:DscTextBox>
                        <cc1:DscTextBox ID="odm016002" Title="DscTextBox:" Style="z-index: 102; left: 245px;
                            position: absolute; top: 49px" runat="server" Cellpanding="2" TitleWidth="110px"
                            border="0" CellNo1CssClass="" CellNo2CssClass="" cellpadding="2" cellspacing="0"
                            LangText="DscTextBox:" TitleType="TitleLang01" TxtInput_TabIndex="0">
                            <InputStyle Width="120px"></InputStyle>
                            <TitleStyle Width="110px"></TitleStyle>
                            <FrmFieldKeys FrmID="FrmODM016" BOID="ODM016" FieldName="odm016002"></FrmFieldKeys>
                            <Validator MsgF0001="" MsgF0002="" ValidatorExpression="" ValidatorMsg="" ValidatorName="" />
                        </cc1:DscTextBox>
                    </div>
                </cc1:DscPanel>
            </cc1:DscPanel>
            <!--2010/06/01:3.2.1.13:hiro:S00-20100323002:功能新增：新增人員、日期、部門(含多選開窗)元件↓-->
            <cc1:DscPanel ID="hdnDisplayInHTML2" Style="display: none; z-index: 116; left: 264px;
                top: 72px" runat="server">
                <div style="overflow: auto; width: 100%; position: relative; height: 100%; background-color: transparent">
                    <cc1:DscTextBox ID="edReceiver" runat="server" ShowTitle="False" Title="" Width="36px">
                        <InputStyle Width="0px" />
                        <Validator MsgF0001="" MsgF0002="" ValidatorExpression="" ValidatorMsg="" ValidatorName="" />
                        <TitleStyle Width="60px" />
                    </cc1:DscTextBox>
                </div>
            </cc1:DscPanel>
            <!--2010/06/01:3.2.1.13:hiro:S00-20100323002:功能新增：新增人員、日期、部門(含多選開窗)元件↑-->
        </div>
        <!--單檔架構結尾 -->
    </div>
</asp:Content>
