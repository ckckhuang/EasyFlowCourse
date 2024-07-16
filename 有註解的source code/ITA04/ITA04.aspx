<%@ Page language="c#" CodeFile="ITA04.aspx.cs" ValidateRequest="false" MasterPageFile="~/src/_Common/AppUtil/EFMasterPage/EFBaseMasterPage.master" AutoEventWireup="false" enableEventValidation="false" Inherits="tw.com.dsc.easyflowDotNet.forms.ITA04" %>
<%@ Register TagPrefix="uc1" TagName="gridUserControl" Src="../../_Common/PlatformUtil/KernelPage/Grid/gridUserControl.ascx" %>
<%@ Register TagPrefix="iewc" Namespace="Microsoft.Web.UI.WebControls" Assembly="Microsoft.Web.UI.WebControls" %>
<%@ Register TagPrefix="cc1" Namespace="tw.com.dsc.dscDotNet.dscWebControls" Assembly="PlatformUtil" %>

<%@ Register Assembly='System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35' Namespace='System.Web.UI' TagPrefix='asp' %>
<asp:Content ID="ITA04FormContent" ContentPlaceHolderID="MasterPageContent" runat="server">
	<!--單檔架構 -->
	<!--2009/03/19:Joseph:<div id="cover" style="OVERFLOW: auto; WIDTH: 100%;">-->
		<div id="cover" style="WIDTH: 100%;">
			<div id="createRecord" style="WIDTH: 100%; HEIGHT: 100%" runat="server">
				<cc1:DscPanel id="ecPnlMaster" runat="server" Width="98%" IniHTML='&#10;<div style="OVERFLOW: auto; WIDTH: 100%; POSITION: relative; HEIGHT: 100%" ms_positioning="GridLayout"></div>'
					FrmDefineKeys-FrmType="Query" FrmDefineKeys-FrmID="FrmITA04" FrmDefineKeys-BOID="ITA04"
					BorderStyle="None" BorderColor="Transparent" BorderWidth="0px" Height="246px">
					<!--單頭頁籤-->
					<iewc:TabStrip id="TabStrip1" runat="server" 
						TabDefaultStyle="background-image:url(../../_Common/AppUtil/Themes/images/Menu/Tbtn01.gif);" 
						TabHoverStyle="background-image:url(../../_Common/AppUtil/Themes/images/Menu/Tbtn01.gif);" 
						TabSelectedStyle="background-image:url(../../_Common/AppUtil/Themes/images/Menu/Tbtn02.gif);" 
						CssClass="divToolBar2" >
						<iewc:Tab ID='headDefault' Text='單頭頁籤1' DefaultStyle='width:100px; height:27px;vertical-align:middle; text-align:center;'></iewc:Tab>
					</iewc:TabStrip>
					<!--單頭頁籤畫面集合-->

					<!--單頭頁籤 一-->
					<cc1:Dscpanel id='divheadDefault' style='DISPLAY: block' runat='server' Width='100%' Height='246px' BackColor='Transparent'>
						<div class='TabPage' style='POSITION: relative; HEIGHT: 246px; left: 0px; top: 0px;' >
							<asp:ValidationSummary id='ValidationSummaryHead01' style='Z-INDEX: 100; POSITION: absolute; LEFT: 745px; TOP: 7px;' runat='server' ShowSummary='False' ShowMessageBox='True'></asp:ValidationSummary>
							<!--此區間放入單頭頁籤 一 的各個dsc元件-->
<!-- ^_^ CK edit 20230920 -->
<table>
	<tr>
		<td>
			<cc1:DscTextBox id='ita04a001' runat='server' title='表單代號'
				style='display: none;'
				TxtInput_TabIndex='0'>
				<INPUTSTYLE Width='120px'></INPUTSTYLE>
				<TITLESTYLE Width='110px'></TITLESTYLE>
				<FRMFIELDKEYS FrmID='FrmITA04' BOID='ITA04' FieldName='ita04a001'></FRMFIELDKEYS>
			</cc1:DscTextBox>
		</td>
		<td>
			<cc1:DscTextBox id='ita04a002' runat='server' title='表單單號'
				style='display: none;'
				TxtInput_TabIndex='0'>
				<INPUTSTYLE Width='120px'></INPUTSTYLE>
				<TITLESTYLE Width='110px'></TITLESTYLE>
				<FRMFIELDKEYS FrmID='FrmITA04' BOID='ITA04' FieldName='ita04a002'></FRMFIELDKEYS>
			</cc1:DscTextBox>
		</td>
	</tr>
    <tr>
		<td>
			<cc1:DscOpenQuery id='ita04a003' runat='server' title='填單人' ShowTitle='True'
				TxtInput_TabIndex='101' TextMode='SingleLine'
				BtnVisible='True' ImgSrc='../../_Common/AppUtil/Themes/images/Program/imgMan.gif'
				ReturnVisible='True'>
				<TitleStyle Width='100px'></TitleStyle>
				<InputStyle Width='116px' Height='32px' CssClass='Edit20'></InputStyle>
				<FrmFieldKeys FrmID='FrmITA04' BOID='ITA04' FieldName='ita04a003'></FrmFieldKeys>
			</cc1:DscOpenQuery>
		</td>
		<td>
			<cc1:DscDateAssistant2 ID='ita04a004' runat='server' Title='申請日期'
				TxtInput_TabIndex='102'
				DisplayMode='yyyyMMdd' DateSaveFormat='String' DateLan='ChristianEra' datePagePath='../../_Common/PlatformUtil/Resource/ASP/' 
				BtnVisible='True' ImgSrc='../../_Common/AppUtil/Themes/images/Program/calender.gif'>
				<TitleStyle Width='100px' />
				<InputStyle Width='116px' Height='32px' CssClass='Edit20' />
				<FrmFieldKeys FrmID='FrmITA04' BOID='ITA04' FieldName='ita04a004'></FrmFieldKeys>
			</cc1:DscDateAssistant2>
		</td>

	</tr>
	<tr>
		<td>
			<cc1:DscOpenQuery id='ita04a005' runat='server' title='申請部門' ShowTitle='True'
				TxtInput_TabIndex='103' TextMode='SingleLine'
				BtnVisible='True' ImgSrc='../../_Common/AppUtil/Themes/images/Program/data.gif'
				ReturnVisible='True'>
				<TitleStyle Width='100px'></TitleStyle>
				<InputStyle Width='116px' Height='32px' CssClass='Edit20'></InputStyle>
				<FrmFieldKeys FrmID='FrmITA04' BOID='ITA04' FieldName='ita04a005'></FrmFieldKeys>
			</cc1:DscOpenQuery>
		</td>
		<td>
			<cc1:DscOpenQuery id='ita04a006' runat='server' title='申請人' ShowTitle='True'
				TxtInput_TabIndex='104' TextMode='SingleLine'
				BtnVisible='True' ImgSrc='../../_Common/AppUtil/Themes/images/Program/imgMan.gif'
				ReturnVisible='True'>
				<TitleStyle Width='100px'></TitleStyle>
				<InputStyle Width='116px' Height='32px' CssClass='Edit20'></InputStyle>
				<FrmFieldKeys FrmID='FrmITA04' BOID='ITA04' FieldName='ita04a006'></FrmFieldKeys>
			</cc1:DscOpenQuery>
		</td>
	</tr>
	<tr>
		<td>
			<cc1:DscTextBox id='ita04a007' runat='server' title='總金額'
				TxtInput_TabIndex='105'>
				<FrmFieldKeys FrmID='FrmITA04' BOID='ITA04' FieldName='ita04a007'></FrmFieldKeys>
				<TitleStyle Width='100px'></TitleStyle>
				<InputStyle Width='116px' Height='32px' CssClass='Edit20'></InputStyle>
			</cc1:DscTextBox>
		</td>
	</tr>
	<tr>
		<td>
			<cc1:DscTextBox id='ita04a008' runat='server' title='TEST'
				TxtInput_TabIndex='105'>
				<FrmFieldKeys FrmID='FrmITA04' BOID='ITA04' FieldName='ita04a008'></FrmFieldKeys>
				<TitleStyle Width='100px'></TitleStyle>
				<InputStyle Width='116px' Height='32px' CssClass='Edit20'></InputStyle>
			</cc1:DscTextBox>
		</td>
	</tr>
</table>
<!-- ^_^ CK edit 20230920 -->
						</div>
					</cc1:Dscpanel>


					<table><tr><td height='5'></td></tr></table>
					<!--單身頁籤-->
					<iewc:TabStrip id='TabStrip2' runat='server' CssClass='divToolBar2'
						TabDefaultStyle='background-image:url(../../_Common/AppUtil/Themes/images/Menu/Tbtn01.gif);'
						TabHoverStyle='background-image:url(../../_Common/AppUtil/Themes/images/Menu/Tbtn01.gif);'
						TabSelectedStyle='background-image:url(../../_Common/AppUtil/Themes/images/Menu/Tbtn02.gif);'>
						<iewc:Tab ID="bodyDefault" Text="單身頁籤1" DefaultStyle="width:100px;height:27px;vertical-align:middle;text-align:center;"></iewc:Tab>
					</iewc:TabStrip>

					<!--單身Grid畫面-->
					
					<!--單身Grid 一 的各個dsc元件-->
					<div id='divbodyDefault' runat='server' class='TabPage' style='DISPLAY: block; OVERFLOW: hidden; WIDTH: 100%; BACKGROUND-REPEAT: repeat;'>
						<cc1:DscPanel ID='ecPnlDetail1' runat='server' FrmDefineKeys-BOID='ITA04_d01' FrmDefineKeys-FrmID='FrmITA04_d01' FrmDefineKeys-FrmType='Query'
							BorderStyle='None' BorderColor='Transparent' BorderWidth='0px'
							IniHTML="<div style='OVERFLOW: auto; WIDTH: 100%; POSITION: relative; HEIGHT: 100%;' ms_positioning='GridLayout'></div>"
							Width='100%' Height='0px'>
							<cc1:DscPanel ID='divDetail1Default' runat='server' FrmDefineKeys-BOID='ITA04_d01' FrmDefineKeys-FrmID='FrmITA04_d01' FrmDefineKeys-FrmType='Query'
								BorderStyle='None' BorderColor='Transparent' BorderWidth='0px'
								IniHTML="<div style='OVERFLOW: auto; WIDTH: 98%; POSITION: relative; HEIGHT: 100%;' ms_positioning='GridLayout'></div>"
								Width='916px' Height='200px' style='position:relative;'>
<!-- ^_^ CK edit 20230920 -->
<table>
	<tr>
		<td>
			<cc1:DscTextBox id='ita04b001' runat='server' title='表單代號'
				style='display: none;'
				TxtInput_TabIndex='0'>
				<INPUTSTYLE Width='120px'></INPUTSTYLE>
				<TITLESTYLE Width='110px'></TITLESTYLE>
				<FRMFIELDKEYS FrmID='FrmITA04_d01' BOID='ITA04_d01' FieldName='ita04b001'></FRMFIELDKEYS>
			</cc1:DscTextBox>
		</td>
		<td>
			<cc1:DscTextBox id='ita04b002' runat='server' title='表單單號'
				style='display: none;'
				TxtInput_TabIndex='0'>
				<INPUTSTYLE Width='120px'></INPUTSTYLE>
				<TITLESTYLE Width='110px'></TITLESTYLE>
				<FRMFIELDKEYS FrmID='FrmITA04_d01' BOID='ITA04_d01' FieldName='ita04b002'></FRMFIELDKEYS>
			</cc1:DscTextBox>
		</td>
		<td>
			<cc1:DscTextBox id='ita04b003' runat='server' title='序號'
				style='display: none;'
				TxtInput_TabIndex='0'>
				<INPUTSTYLE Width='120px' CssClass='Edit20'></INPUTSTYLE>
				<TITLESTYLE Width='100px'></TITLESTYLE>
				<FRMFIELDKEYS FrmID='FrmITA04_d01' BOID='ITA04_d01' FieldName='ita04b003'></FRMFIELDKEYS>
			</cc1:DscTextBox>
		</td>
	</tr>
	<tr>
		<td>
			<cc1:DscOpenQuery id='ita04b004' runat='server' title='品項' ShowTitle='True'
				TxtInput_TabIndex='106' TextMode='SingleLine'
				BtnVisible='True' ImgSrc='../../_Common/AppUtil/Themes/images/Program/data.gif'
				ReturnVisible='True'>
				<TitleStyle Width='100px'></TitleStyle>
				<InputStyle Width='154px' Height='26px' CssClass='Edit20'></InputStyle>
				<FrmFieldKeys FrmID='FrmITA04_d01' BOID='ITA04_d01' FieldName='ita04b004'></FrmFieldKeys>
			</cc1:DscOpenQuery>
		</td>
		<td colspan="2">
			<cc1:DscDateAssistant2 ID='ita04b005' runat='server' Title='需求日期'
				TxtInput_TabIndex='107'
				DisplayMode='yyyyMMdd' DateSaveFormat='String' DateLan='ChristianEra' datePagePath='../../_Common/PlatformUtil/Resource/ASP/' 
				BtnVisible='True' ImgSrc='../../_Common/AppUtil/Themes/images/Program/calender.gif'>
				<TitleStyle Width='100px' />
				<InputStyle Width='134px' Height='30px' CssClass='Edit20' />
				<FrmFieldKeys FrmID='FrmITA04_d01' BOID='ITA04_d01' FieldName='ita04b005'></FrmFieldKeys>
			</cc1:DscDateAssistant2>
		</td>
	</tr>
	<tr>
		<td>
			<cc1:DscTextBox id='ita04b006' runat='server' title='單價'
				TxtInput_TabIndex='108'>
				<FrmFieldKeys FrmID='FrmITA04_d01' BOID='ITA04_d01' FieldName='ita04b006'></FrmFieldKeys>
				<TitleStyle Width='100px'></TitleStyle>
				<InputStyle Width='134px' Height='30px' CssClass='Edit20'></InputStyle>
			</cc1:DscTextBox>
		</td>
		<td>
			<cc1:DscTextBox id='ita04b007' runat='server' title='數量'
				TxtInput_TabIndex='109'>
				<FrmFieldKeys FrmID='FrmITA04_d01' BOID='ITA04_d01' FieldName='ita04b007'></FrmFieldKeys>
				<TitleStyle Width='100px'></TitleStyle>
				<InputStyle Width='134px' Height='30px' CssClass='Edit20'></InputStyle>
			</cc1:DscTextBox>
		</td>
		<td>
			<cc1:DscTextBox id='ita04b008' runat='server' title='小計'
				TxtInput_TabIndex='110'>
				<FrmFieldKeys FrmID='FrmITA04_d01' BOID='ITA04_d01' FieldName='ita04b008'></FrmFieldKeys>
				<TitleStyle Width='100px'></TitleStyle>
				<InputStyle Width='134px' Height='30px' CssClass='Edit20'></InputStyle>
			</cc1:DscTextBox>
		</td>
	</tr>
</table>
<!-- ^_^ CK edit 20230920 -->
							</cc1:DscPanel>
							<uc1:gridusercontrol id='GridUserControl1' runat='server'></uc1:gridusercontrol>
						</cc1:DscPanel>
					</div>


					<cc1:DscPanel id="hdnDisplayInCS" style="DISPLAY: none; Z-INDEX: 116; LEFT: 264px; TOP: 72px" runat="server" Width="100%">
						<div style="OVERFLOW: auto; WIDTH: 100%; POSITION: relative; HEIGHT: 100%; BACKGROUND-COLOR: transparent; left: 0px; top: 0px;" ></div>
					</cc1:DscPanel>
					<cc1:DscPanel id="hdnDisplayInHTML" style="DISPLAY: none; Z-INDEX: 116; LEFT: 264px; TOP: 72px" runat="server">
						<div style="OVERFLOW: auto; WIDTH: 100%; POSITION: relative; HEIGHT: 100%; BACKGROUND-COLOR: transparent" >
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

	<asp:UpdatePanel ID='DetailUpdatePanel' UpdateMode='Conditional' runat='server'>
		<ContentTemplate>
		</ContentTemplate>
		<Triggers>
			<asp:AsyncPostBackTrigger ControlID='BtnDetailSave' EventName='Click' />
			<asp:AsyncPostBackTrigger ControlID='BtnDetailAdd' EventName='Click' />
			<asp:AsyncPostBackTrigger ControlID='BtnDetailDel' EventName='Click' />
			<asp:AsyncPostBackTrigger ControlID='BtnDetailExit' EventName='Click' />
		</Triggers>
	</asp:UpdatePanel>
<!--引用JavaScript-->
<script src="ITA04.js?NoCache=20230921005" type="text/javascript"></script>
</asp:Content>
