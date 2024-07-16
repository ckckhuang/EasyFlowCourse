<%@ Page language="c#" CodeFile="TEST82.aspx.cs" MasterPageFile="~/src/_Common/AppUtil/EFMasterPage/EFBaseMasterPage.master" AutoEventWireup="false" Inherits="tw.com.dsc.easyflowDotNet.forms.TEST82" %>
<%@ Register TagPrefix="cc1" Namespace="tw.com.dsc.dscDotNet.dscWebControls" Assembly="PlatformUtil" %>
<%@ Register TagPrefix="iewc" Namespace="Microsoft.Web.UI.WebControls" Assembly="Microsoft.Web.UI.WebControls" %>
<%@ Register TagPrefix="uc1" TagName="gridUserControl" Src="../../_Common/PlatformUtil/KernelPage/Grid/gridUserControl.ascx" %>

<asp:Content ID="TEST82FormContent" ContentPlaceHolderID="MasterPageContent" runat="server">        		
		<!--單檔架構 -->
		<script src="../../_Common/JS/jquery-Released.js" type="text/javascript"></script>
		<script src="TEST82.js" type="text/javascript"></script>
		<!--2009/03/19:Joseph:<div id="cover" style="OVERFLOW: auto; WIDTH: 100%;">-->
				<div id="cover" style="WIDTH: 100%;">
						<div id="createRecord" style="WIDTH: 100%; HEIGHT: 100%" runat="server">				
								<cc1:DscPanel id="ecPnlMaster" runat="server" Width="98%" IniHTML='&#10;<div style="OVERFLOW: auto; WIDTH: 100%; POSITION: relative; HEIGHT: 100%" ms_positioning="GridLayout"></div>'
										FrmDefineKeys-FrmType="Query" FrmDefineKeys-FrmID="FrmTEST82" FrmDefineKeys-BOID="TEST82"
										BorderStyle="None" BorderColor="Transparent" BorderWidth="0px" Height="294px">
										<!--單頭頁籤-->
										<iewc:tabstrip id="TabStrip1" runat="server" TabDefaultStyle="background-image:url(../../_Common/AppUtil/Themes/images/Menu/Tbtn01.gif);" TabHoverStyle="background-image:url(../../_Common/AppUtil/Themes/images/Menu/Tbtn01.gif);" TabSelectedStyle="background-image:url(../../_Common/AppUtil/Themes/images/Menu/Tbtn02.gif);" CssClass="divToolBar2" >
										<iewc:Tab Text="送單前應用" DefaultStyle="width:100px; height:27px;vertical-align:middle; text-align:center;"
												ID="Tab1"></iewc:Tab>
										</iewc:tabstrip>

										<!--單頭頁籤畫面集合-->
										<!--預設放入一個DIV-->								
										<cc1:Dscpanel id="divheadDefault" style="DISPLAY: block" runat="server" Width="100%" Height="294px" BackColor="Transparent">												
												<div class="TabPage" style="POSITION: relative; HEIGHT: 294px; left: 0px; top: 0px;" >
												<asp:ValidationSummary id="ValidationSummary1" style="Z-INDEX: 100; LEFT: 745px; POSITION: absolute; TOP: 7px" runat="server" ShowSummary="False" ShowMessageBox="True"></asp:ValidationSummary>
												<!--此區間放入各種dsc元件-->
												
												<cc1:DscOpenQuery id="dept1" title="部門" style="Z-INDEX: 700; LEFT: 85px; POSITION: absolute; TOP: 85px" runat="server" TxtInput_TabIndex="102" ReturnVisible="True" ImgSrc="../../_Common/AppUtil/Themes/images/Program/data.gif" Text2Visible="True" RetuenVisible="True" BtnVisible="True" TitleWidth="120px" ShowTitle="True" InputEnabled="True" TitleLocation="_Left" TextMode="SingleLine" Cellpanding="0"><TITLESTYLE Width="100px"></TITLESTYLE><INPUTSTYLE Width="108px" Height="20px" CssClass="Edit20" BackColor="White"></INPUTSTYLE><VALIDATOR ValidatorName="" MsgF0002="" MsgF0001="" ValidatorExpression="" ValidatorMsg=""></VALIDATOR> <FrmFieldKeys FrmID="FrmTEST82" BOID="TEST82" FieldName="dept1"></FrmFieldKeys></cc1:DscOpenQuery>
<cc1:DscOpenQuery id="empl1" title="申請人" style="Z-INDEX: 699; LEFT: 85px; POSITION: absolute; TOP: 44px" runat="server" TxtInput_TabIndex="101" ReturnVisible="True" ImgSrc="../../_Common/AppUtil/Themes/images/Program/imgMan.gif" Text2Visible="True" RetuenVisible="True" BtnVisible="True" TitleWidth="120px" ShowTitle="True" InputEnabled="True" TitleLocation="_Left" TextMode="SingleLine" Cellpanding="0"><TITLESTYLE Width="100px"></TITLESTYLE><INPUTSTYLE Width="110px" Height="20px" CssClass="Edit20" BackColor="White"></INPUTSTYLE><VALIDATOR ValidatorName="" MsgF0002="" MsgF0001="" ValidatorExpression="" ValidatorMsg=""></VALIDATOR> <FrmFieldKeys FrmID="FrmTEST82" BOID="TEST82" FieldName="empl1"></FrmFieldKeys></cc1:DscOpenQuery>
<cc1:DscLabel ID="label1" runat="server" Style="z-index:501; left: 102px; position: absolute;top: 206px" Text="PS:請將表單性質中單號改為手動編碼。" Width="547px" Height="39px"></cc1:DscLabel>
<cc1:DscOpenQuery BtnVisible="True" ImgSrc="../../_Common/AppUtil/Themes/images/Program/pela.gif" id="textarea1" title="備註" style="Z-INDEX:697; LEFT: 85px; POSITION: absolute; TOP: 127px" runat="server" LangText="備註"  Cellpanding="0" TitleWidth="120px" TxtInput_TabIndex="103" border="0" CellNo1CssClass="" CellNo2CssClass="" cellpadding="0" cellspacing="0" Text="" TitleType="TitleLang01" TextMode="MultiLine" TitleLocation="_Left"> <FrmFieldKeys FrmID="FrmTEST82" BOID="TEST82" FieldName="textarea1"></FrmFieldKeys> <TitleStyle Width="100px"></TitleStyle> <InputStyle Width="547px" Height="39px" CssClass="Edit20"></InputStyle> <Validator ValidatorMsg="" ValidatorExpression="" MsgF0001="" MsgF0002="" ValidatorName=""></Validator></cc1:DscOpenQuery>


												</div>
										</cc1:Dscpanel>																																								
										<!--有單身才放-->
										
										<!--單身頁籤起始-->
										
										<!--單身Grid-->
										<!--此區間放入數個單身Grid-->
										
										<cc1:DscPanel id="hdnDisplayInCS" style="DISPLAY: none; Z-INDEX: 116; LEFT: 264px; TOP: 72px"
										runat="server" Width="100%">
										<div style="OVERFLOW: auto; WIDTH: 100%; POSITION: relative; HEIGHT: 100%; BACKGROUND-COLOR: transparent; left: 0px; top: 0px;" ></div>
										</cc1:DscPanel>
										<cc1:DscPanel id="hdnDisplayInHTML" style="DISPLAY: none; Z-INDEX: 116; LEFT: 264px; TOP: 72px"
										runat="server">
										<div style="OVERFLOW: auto; WIDTH: 100%; POSITION: relative; HEIGHT: 100%; BACKGROUND-COLOR: transparent" >
										<cc1:DscTextBox id="test82001" title="DscTextBox:" style="Z-INDEX: 101; LEFT: 245px; POSITION: absolute; TOP: 16px"
														runat="server" Cellpanding="2" TitleWidth="110px" border="0" CellNo1CssClass="" CellNo2CssClass="" cellpadding="2" cellspacing="0" LangText="DscTextBox:" TitleType="TitleLang01" TxtInput_TabIndex="0">
														<INPUTSTYLE Width="120px"></INPUTSTYLE>
														<TITLESTYLE Width="110px"></TITLESTYLE>
														<FRMFIELDKEYS FrmID="FrmTEST82" BOID="TEST82" FieldName="test82001"></FRMFIELDKEYS>
                            								<Validator MsgF0001="" MsgF0002="" ValidatorExpression="" ValidatorMsg="" ValidatorName="" />
										</cc1:DscTextBox>
										<cc1:DscTextBox id="test82002" title="DscTextBox:" style="Z-INDEX: 102; LEFT: 245px; POSITION: absolute; TOP: 49px"
														runat="server" Cellpanding="2" TitleWidth="110px" border="0" CellNo1CssClass="" CellNo2CssClass="" cellpadding="2" cellspacing="0" LangText="DscTextBox:" TitleType="TitleLang01" TxtInput_TabIndex="0">
														<INPUTSTYLE Width="120px"></INPUTSTYLE>
														<TITLESTYLE Width="110px"></TITLESTYLE>
														<FRMFIELDKEYS FrmID="FrmTEST82" BOID="TEST82" FieldName="test82002"></FRMFIELDKEYS>
                            								<Validator MsgF0001="" MsgF0002="" ValidatorExpression="" ValidatorMsg="" ValidatorName="" />
										</cc1:DscTextBox>
										</div>
										</cc1:DscPanel>
								</cc1:DscPanel>
								<!--2010/06/01:3.2.1.13:hiro:S00-20100323002:功能新增：新增人員、日期、部門(含多選開窗)元件↓-->
								<cc1:DscPanel id="hdnDisplayInHTML2" style="DISPLAY: none; Z-INDEX: 116; LEFT: 264px; TOP: 72px"
										runat="server">
										<div style="OVERFLOW: auto; WIDTH: 100%; POSITION: relative; HEIGHT: 100%; BACKGROUND-COLOR: transparent" >
                    <cc1:DscTextBox ID="edReceiver" runat="server" ShowTitle="False" Title="" Width="36px">
                        <InputStyle Width="0px" />
                        <Validator MsgF0001="" MsgF0002="" ValidatorExpression="" ValidatorMsg="" ValidatorName="" />
                        <TitleStyle Width="60px" />
                    </cc1:DscTextBox>
										</div>
								</cc1:DscPanel>
								<!--2010/06/01:3.2.1.13:hiro:S00-20100323002:功能新增：新增人員、日期、部門(含多選開窗)元件↑-->
						</div><!--單檔架構結尾 -->
		</div>
</asp:Content>
