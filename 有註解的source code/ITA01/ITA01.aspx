<%@ Page language="c#" CodeFile="ITA01.aspx.cs" MasterPageFile="~/src/_Common/AppUtil/EFMasterPage/EFBaseMasterPage.master" AutoEventWireup="false" enableEventValidation="false" Inherits="tw.com.dsc.easyflowDotNet.forms.ITA01" %>
<%@ Register TagPrefix="uc1" TagName="gridUserControl" Src="../../_Common/PlatformUtil/KernelPage/Grid/gridUserControl.ascx" %>
<%@ Register TagPrefix="iewc" Namespace="Microsoft.Web.UI.WebControls" Assembly="Microsoft.Web.UI.WebControls" %>
<%@ Register TagPrefix="cc1" Namespace="tw.com.dsc.dscDotNet.dscWebControls" Assembly="PlatformUtil" %>

<asp:Content ID="ITA01FormContent" ContentPlaceHolderID="MasterPageContent" runat="server">
	<!--單檔架構 -->
	<!--2009/03/19:Joseph:<div id="cover" style="OVERFLOW: auto; WIDTH: 100%;">-->
		<div id="cover" style="WIDTH: 100%;">
			<div id="createRecord" style="WIDTH: 100%; HEIGHT: 100%" runat="server">
				<cc1:DscPanel id="ecPnlMaster" runat="server" Width="98%" IniHTML='&#10;<div style="OVERFLOW: auto; WIDTH: 100%; POSITION: relative; HEIGHT: 100%" ms_positioning="GridLayout"></div>'
					FrmDefineKeys-FrmType="Query" FrmDefineKeys-FrmID="FrmITA01" FrmDefineKeys-BOID="ITA01"
					BorderStyle="None" BorderColor="Transparent" BorderWidth="0px" Height="830px">
					<!--單頭頁籤-->
					<iewc:TabStrip id="TabStrip1" runat="server" 
						TabDefaultStyle="background-image:url(../../_Common/AppUtil/Themes/images/Menu/Tbtn01.gif);" 
						TabHoverStyle="background-image:url(../../_Common/AppUtil/Themes/images/Menu/Tbtn01.gif);" 
						TabSelectedStyle="background-image:url(../../_Common/AppUtil/Themes/images/Menu/Tbtn02.gif);" 
						CssClass="divToolBar2" >
						<iewc:Tab ID='headDefault' Text='單頭頁籤1' DefaultStyle='width:100px; height:27px;vertical-align:middle; text-align:center;'></iewc:Tab>
						<%--手動新增單頭頁籤--%>
						<%--<iewc:Tab ID='headDefault2' Text='單頭頁籤2' DefaultStyle='width:100px; height:27px;vertical-align:middle; text-align:center;'></iewc:Tab>--%>
					</iewc:TabStrip>
					<!--單頭頁籤畫面集合-->

					<!--單頭頁籤 一-->
					<cc1:Dscpanel id='divheadDefault' style='DISPLAY: block' runat='server' Width='100%' Height='830px' BackColor='Transparent'>
						<div class='TabPage' style='POSITION: relative; HEIGHT: 830px; left: 0px; top: 0px;' >
							<asp:ValidationSummary id='ValidationSummaryHead01' style='Z-INDEX: 100; POSITION: absolute; LEFT: 745px; TOP: 7px;' runat='server' ShowSummary='False' ShowMessageBox='True'></asp:ValidationSummary>
							<!--此區間放入單頭頁籤 一 的各個dsc元件-->

<cc1:DscTextBox id='misbri001001' runat='server' title='表單代號'
	style='display: none; Z-INDEX: 101; POSITION: absolute; LEFT: 245px; TOP: 16px;'
	TxtInput_TabIndex='0'>
	<INPUTSTYLE Width='120px'></INPUTSTYLE>
	<TITLESTYLE Width='110px'></TITLESTYLE>
	<FRMFIELDKEYS FrmID='FrmITA01' BOID='ITA01' FieldName='misbri001001'></FRMFIELDKEYS>
</cc1:DscTextBox>
<cc1:DscTextBox id='misbri001002' runat='server' title='表單單號'
	style='display: none; Z-INDEX: 102; POSITION: absolute; LEFT: 245px; TOP: 49px;'
	TxtInput_TabIndex='0'>
	<INPUTSTYLE Width='120px'></INPUTSTYLE>
	<TITLESTYLE Width='110px'></TITLESTYLE>
	<FRMFIELDKEYS FrmID='FrmITA01' BOID='ITA01' FieldName='misbri001002'></FRMFIELDKEYS>
</cc1:DscTextBox>
							<%--//^_^ 20230914 edit by yating ↓--%> 
							<%--Table排版--%>
							<%--<table>
								<tr>
									<td>
                                        <cc1:DscOpenQuery ID='dept1' runat='server' Title='dept1' ShowTitle='False'
                                            TxtInput_TabIndex='101' TextMode='SingleLine'
                                            BtnVisible='True' ImgSrc='../../_Common/AppUtil/Themes/images/Program/data.gif'
                                            ReturnVisible='True'>
                                            <InputStyle Width='80px' Height='22px' CssClass='Edit20'></InputStyle>
                                            <FrmFieldKeys FrmID='FrmITA01' BOID='ITA01' FieldName='dept1'></FrmFieldKeys>
                                        </cc1:DscOpenQuery>
									</td>
									<td></td>
								</tr>
							</table>--%>
							<%--//^_^ 20230914 edit by yating ↑--%> 

							<%--//^_^ 20230914 edit by yating ↓--%> 
							<%--控制項用多語系方式綁定欄位標題--%>
							<%--<cc1:DscLabel  ID="lbldept1" runat='server' Text="申請部門" style="Z-INDEX: 698; POSITION: absolute; LEFT: 81px; TOP: 149px;">
								<Comment F0001="FD" F0002="ITA01" F0003="dept1"></Comment>
							</cc1:DscLabel>--%>
							<%--//^_^ 20230914 edit by yating ↑--%> 

<cc1:DscOpenQuery id='dept1' runat='server' title='dept1' ShowTitle='False'
	style="Z-INDEX: 698; POSITION: absolute; LEFT: 78px; TOP: 164px;"
	TxtInput_TabIndex='101' TextMode='SingleLine'
	BtnVisible='True' ImgSrc='../../_Common/AppUtil/Themes/images/Program/data.gif'
	ReturnVisible='True' >
	<InputStyle Width='80px' Height='22px' CssClass='Edit20'></InputStyle>
	<FrmFieldKeys FrmID='FrmITA01' BOID='ITA01' FieldName='dept1'></FrmFieldKeys>
</cc1:DscOpenQuery>
<cc1:DscOpenQuery id='empl1' runat='server' title='empl1' ShowTitle='False'
	style="Z-INDEX: 696; POSITION: absolute; LEFT: 301px; TOP: 160px;"
	TxtInput_TabIndex='102' TextMode='SingleLine'
	BtnVisible='True' ImgSrc='../../_Common/AppUtil/Themes/images/Program/imgMan.gif'
	ReturnVisible='True'>
	<InputStyle Width='80px' Height='26px' CssClass='Edit20'></InputStyle>
	<FrmFieldKeys FrmID='FrmITA01' BOID='ITA01' FieldName='empl1'></FrmFieldKeys>
</cc1:DscOpenQuery>
<cc1:DscDateAssistant2 ID='datetime1' runat='server' Title='datetime1' ShowTitle='False'
	style="POSITION: absolute; left: 558px; top: 154px; z-index: 693;" 
	TxtInput_TabIndex='103' 
	DisplayMode='yyyyMMdd' DateSaveFormat='String' DateLan='ChristianEra' datePagePath='../../_Common/PlatformUtil/Resource/ASP/' 
	BtnVisible='True' ImgSrc='../../_Common/AppUtil/Themes/images/Program/calender.gif'>
	<InputStyle Width='111px' Height='22px' CssClass='Edit20' />
	<FrmFieldKeys FrmID='FrmITA01' BOID='ITA01' FieldName='datetime1'></FrmFieldKeys>
</cc1:DscDateAssistant2>
<cc1:DscDateAssistant2 ID='datetime2' runat='server' Title='datetime2' ShowTitle='False'
	style="POSITION: absolute; left: 558px; top: 182px; z-index: 692;" 
	TxtInput_TabIndex='104' 
	DisplayMode='yyyyMMdd' DateSaveFormat='String' DateLan='ChristianEra' datePagePath='../../_Common/PlatformUtil/Resource/ASP/' 
	BtnVisible='True' ImgSrc='../../_Common/AppUtil/Themes/images/Program/calender.gif'>
	<InputStyle Width='110px' Height='22px' CssClass='Edit20' />
	<FrmFieldKeys FrmID='FrmITA01' BOID='ITA01' FieldName='datetime2'></FrmFieldKeys>
</cc1:DscDateAssistant2>
<cc1:DscTextBox id='textarea1' runat='server' title='textarea1' ShowTitle='False'
	style="Z-INDEX:697; POSITION: absolute; LEFT: 91px; TOP: 214px;"
	TxtInput_TabIndex='105' TextMode='MultiLine'>
	<FrmFieldKeys FrmID='FrmITA01' BOID='ITA01' FieldName='textarea1'></FrmFieldKeys>
	<TitleStyle Width='100px'></TitleStyle>
	<InputStyle Width='572px' Height='173px' CssClass='Edit20'></InputStyle>
</cc1:DscTextBox>
<cc1:DscOpenQuery id='empl2' runat='server' title='empl2' ShowTitle='False'
	style="Z-INDEX: 699; POSITION: absolute; LEFT: 75px; TOP: 454px;"
	TxtInput_TabIndex='106' TextMode='SingleLine'
	BtnVisible='True' ImgSrc='../../_Common/AppUtil/Themes/images/Program/imgMan.gif'
	ReturnVisible='True'>
	<InputStyle Width='114px' Height='27px' CssClass='Edit20'></InputStyle>
	<FrmFieldKeys FrmID='FrmITA01' BOID='ITA01' FieldName='empl2'></FrmFieldKeys>
</cc1:DscOpenQuery>
<cc1:DscDateAssistant2 ID='datetime3' runat='server' Title='datetime3' ShowTitle='False'
	style="POSITION: absolute; left: 322px; top: 454px; z-index: 695;" 
	TxtInput_TabIndex='107' 
	DisplayMode='yyyyMMdd' DateSaveFormat='String' DateLan='ChristianEra' datePagePath='../../_Common/PlatformUtil/Resource/ASP/' 
	BtnVisible='True' ImgSrc='../../_Common/AppUtil/Themes/images/Program/calender.gif'>
	<InputStyle Width='97px' Height='28px' CssClass='Edit20' />
	<FrmFieldKeys FrmID='FrmITA01' BOID='ITA01' FieldName='datetime3'></FrmFieldKeys>
</cc1:DscDateAssistant2>
<cc1:DscTextBox id='text1' runat='server' title='text1' ShowTitle='False'
	style="Z-INDEX:694; POSITION: absolute; LEFT: 549px; TOP: 454px;"
	TxtInput_TabIndex='108'>
	<FrmFieldKeys FrmID='FrmITA01' BOID='ITA01' FieldName='text1'></FrmFieldKeys>
	<TitleStyle Width='100px'></TitleStyle>
	<InputStyle Width='113px' Height='26px' CssClass='Edit20'></InputStyle>
</cc1:DscTextBox>
<cc1:DscTextBox id='textarea2' runat='server' title='textarea2' ShowTitle='False'
	style="Z-INDEX:700; POSITION: absolute; LEFT: 33px; TOP: 518px;"
	TxtInput_TabIndex='109' TextMode='MultiLine'>
	<FrmFieldKeys FrmID='FrmITA01' BOID='ITA01' FieldName='textarea2'></FrmFieldKeys>
	<TitleStyle Width='100px'></TitleStyle>
	<InputStyle Width='656px' Height='235px' CssClass='Edit20'></InputStyle>
</cc1:DscTextBox>

<div style="position:absolute; left:2px; top:5px; z-index:10; ">
	<img src="IT_FORM.JPG" id="Head01_file_1" runat="server" width="706" height="795" />
</div>

						</div>
					</cc1:Dscpanel>
					<%--//^_^ 20230914 edit by yating ↓--%> 
					<%--手動新增單頭頁籤--%>
					<%--單頭頁籤 二--%>
					<%--<cc1:Dscpanel id='divheadDefault2' style='DISPLAY: block' runat='server' Width='100%' Height='830px' BackColor='Transparent'>
						<div class='TabPage' style='POSITION: relative; HEIGHT: 830px; left: 0px; top: 0px;' >
							<asp:ValidationSummary id='ValidationSummary1' style='Z-INDEX: 100; POSITION: absolute; LEFT: 745px; TOP: 7px;' runat='server' ShowSummary='False' ShowMessageBox='True'></asp:ValidationSummary>
							
						</div>
					</cc1:Dscpanel>--%>
					<%--//^_^ 20230914 edit by yating ↑--%> 

					<!--單身Grid畫面-->
					
					<cc1:DscPanel id="hdnDisplayInCS" style="DISPLAY: none; Z-INDEX: 116; LEFT: 264px; TOP: 72px" runat="server" Width="100%">
						<div style="OVERFLOW: auto; WIDTH: 100%; POSITION: relative; HEIGHT: 100%; BACKGROUND-COLOR: transparent; left: 0px; top: 0px;" >
						</div>
					</cc1:DscPanel>
					<cc1:DscPanel id="hdnDisplayInHTML" style="DISPLAY: none; Z-INDEX: 116; LEFT: 264px; TOP: 72px" runat="server">
						<div style="OVERFLOW: auto; WIDTH: 100%; POSITION: relative; HEIGHT: 100%; BACKGROUND-COLOR: transparent" >
							<%--//^_^ 20230914 edit by yating ↓--%> 
							<%--//隱藏欄位時，要將欄位拉到此區塊作隱藏，不要使用後端的Visible，否則會影響前端js取得控制像做處理的事件。--%>
							  <%--<cc1:DscTextBox ID='textarea1' runat='server' Title='textarea1' ShowTitle='False'
                                Style="z-index: 697; position: absolute; left: 91px; top: 214px;"
                                TxtInput_TabIndex='105' TextMode='MultiLine'>
                                <FrmFieldKeys FrmID='FrmITA01' BOID='ITA01' FieldName='textarea1'></FrmFieldKeys>
                                <TitleStyle Width='100px'></TitleStyle>
                                <InputStyle Width='572px' Height='173px' CssClass='Edit20'></InputStyle>
                            </cc1:DscTextBox>--%>
							<%--//^_^ 20230914 edit by yating ↑--%> 
						</div>
					</cc1:DscPanel>
				</cc1:DscPanel>
				<!--2012/12/25:3.5.1.38:hiro:S00-20121031003:3.修正多選開窗onChange事件。↓-->
				<asp:HiddenField ID='hdnOpenQueryPreSetValue' runat='server' Value='' />
				<!--2012/12/25:3.5.1.38:hiro:S00-20121031003:3.修正多選開窗onChange事件。↑-->
				<!--2010/06/01:3.2.1.13:hiro:S00-20100323002:功能新增：新增人員、日期、部門(含多選開窗)元件↓-->
				<cc1:DscPanel id="hdnDisplayInHTML2" style="DISPLAY: none; Z-INDEX: 116; LEFT: 264px; TOP: 72px" runat="server">
					<div style="OVERFLOW: auto; WIDTH: 100%; POSITION: relative; HEIGHT: 100%; BACKGROUND-COLOR: transparent">
						<cc1:DscTextBox ID="edReceiver" runat="server" ShowTitle="False" Title="" Width="36px">
							<InputStyle Width="0px" />
							<Validator MsgF0001="" MsgF0002="" ValidatorExpression="" ValidatorMsg="" ValidatorName="" />
							<TitleStyle Width="60px" />
						</cc1:DscTextBox>
					</div>
				</cc1:DscPanel>
				<!--2010/06/01:3.2.1.13:hiro:S00-20100323002:功能新增：新增人員、日期、部門(含多選開窗)元件↑-->
			</div>
		</div>

<!--引用JavaScript-->
<script src="ITA01.js?NoCache=20230914001" type="text/javascript"></script>
</asp:Content>
