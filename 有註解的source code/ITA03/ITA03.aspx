<%@ Page language="c#" CodeFile="ITA03.aspx.cs" ValidateRequest="false" MasterPageFile="~/src/_Common/AppUtil/EFMasterPage/EFBaseMasterPage.master" AutoEventWireup="false" enableEventValidation="false" Inherits="tw.com.dsc.easyflowDotNet.forms.ITA03" %>
<%@ Register TagPrefix="uc1" TagName="gridUserControl" Src="../../_Common/PlatformUtil/KernelPage/Grid/gridUserControl.ascx" %>
<%@ Register TagPrefix="iewc" Namespace="Microsoft.Web.UI.WebControls" Assembly="Microsoft.Web.UI.WebControls" %>
<%@ Register TagPrefix="cc1" Namespace="tw.com.dsc.dscDotNet.dscWebControls" Assembly="PlatformUtil" %>

<%@ Register Assembly='System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35' Namespace='System.Web.UI' TagPrefix='asp' %>
<asp:Content ID="ITA03FormContent" ContentPlaceHolderID="MasterPageContent" runat="server">
	<!--單檔架構 -->
	<!--2009/03/19:Joseph:<div id="cover" style="OVERFLOW: auto; WIDTH: 100%;">-->
		<div id="cover" style="WIDTH: 100%;">
			<div id="createRecord" style="WIDTH: 100%; HEIGHT: 100%" runat="server">
				<cc1:DscPanel id="ecPnlMaster" runat="server" Width="98%" IniHTML='&#10;<div style="OVERFLOW: auto; WIDTH: 100%; POSITION: relative; HEIGHT: 100%" ms_positioning="GridLayout"></div>'
					FrmDefineKeys-FrmType="Query" FrmDefineKeys-FrmID="FrmITA03" FrmDefineKeys-BOID="ITA03"
					BorderStyle="None" BorderColor="Transparent" BorderWidth="0px" Height="405px">
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
					<cc1:Dscpanel id='divheadDefault' style='DISPLAY: block' runat='server' Width='100%' Height='405px' BackColor='Transparent'>
						<div class='TabPage' style='POSITION: relative; HEIGHT: 405px; left: 0px; top: 0px;' >
							<asp:ValidationSummary id='ValidationSummaryHead01' style='Z-INDEX: 100; POSITION: absolute; LEFT: 745px; TOP: 7px;' runat='server' ShowSummary='False' ShowMessageBox='True'></asp:ValidationSummary>
							<!--此區間放入單頭頁籤 一 的各個dsc元件-->

<cc1:DscTextBox id='ita03a001' runat='server' title='表單代號'
	style='display: none; Z-INDEX: 101; POSITION: absolute; LEFT: 245px; TOP: 16px;'
	TxtInput_TabIndex='0'>
	<INPUTSTYLE Width='120px'></INPUTSTYLE>
	<TITLESTYLE Width='110px'></TITLESTYLE>
	<FRMFIELDKEYS FrmID='FrmITA03' BOID='ITA03' FieldName='ita03a001'></FRMFIELDKEYS>
</cc1:DscTextBox>
<cc1:DscTextBox id='ita03a002' runat='server' title='表單單號'
	style='display: none; Z-INDEX: 102; POSITION: absolute; LEFT: 245px; TOP: 49px;'
	TxtInput_TabIndex='0'>
	<INPUTSTYLE Width='120px'></INPUTSTYLE>
	<TITLESTYLE Width='110px'></TITLESTYLE>
	<FRMFIELDKEYS FrmID='FrmITA03' BOID='ITA03' FieldName='ita03a002'></FRMFIELDKEYS>
</cc1:DscTextBox>

<cc1:DscOpenQuery id='ita03a003' runat='server' title='申請單位' ShowTitle='True'
	style="Z-INDEX: 700; POSITION: absolute; LEFT: 6px; TOP: 66px;"
	TxtInput_TabIndex='101' TextMode='SingleLine'
	BtnVisible='True' ImgSrc='../../_Common/AppUtil/Themes/images/Program/data.gif'
	ReturnVisible='True'>
	<TitleStyle Width='100px'></TitleStyle>
	<InputStyle Width='130px' Height='30px' CssClass='Edit20'></InputStyle>
	<FrmFieldKeys FrmID='FrmITA03' BOID='ITA03' FieldName='ita03a003'></FrmFieldKeys>
</cc1:DscOpenQuery>
<cc1:DscDateAssistant2 ID='ita03a004' runat='server' Title='申請日期'
	style="POSITION: absolute; left: 286px; top: 66px; z-index: 688;" 
	TxtInput_TabIndex='102'
	DisplayMode='yyyyMMdd' DateSaveFormat='String' DateLan='ChristianEra' datePagePath='../../_Common/PlatformUtil/Resource/ASP/' 
	BtnVisible='True' ImgSrc='../../_Common/AppUtil/Themes/images/Program/calender.gif'>
	<TitleStyle Width='100px' />
	<InputStyle Width='130px' Height='30px' CssClass='Edit20' />
	<FrmFieldKeys FrmID='FrmITA03' BOID='ITA03' FieldName='ita03a004'></FrmFieldKeys>
</cc1:DscDateAssistant2>
<cc1:DscDateAssistant2 ID='ita03a005' runat='server' Title='需求日期'
	style="POSITION: absolute; left: 566px; top: 66px; z-index: 680;" 
	TxtInput_TabIndex='103'
	DisplayMode='yyyyMMdd' DateSaveFormat='String' DateLan='ChristianEra' datePagePath='../../_Common/PlatformUtil/Resource/ASP/' 
	BtnVisible='True' ImgSrc='../../_Common/AppUtil/Themes/images/Program/calender.gif'>
	<TitleStyle Width='100px' />
	<InputStyle Width='130px' Height='30px' CssClass='Edit20' />
	<FrmFieldKeys FrmID='FrmITA03' BOID='ITA03' FieldName='ita03a005'></FrmFieldKeys>
</cc1:DscDateAssistant2>
<cc1:DscOpenQuery id='ita03a006' runat='server' title='申請人' ShowTitle='True'
	style="Z-INDEX: 699; POSITION: absolute; LEFT: 6px; TOP: 117px;"
	TxtInput_TabIndex='104' TextMode='SingleLine'
	BtnVisible='True' ImgSrc='../../_Common/AppUtil/Themes/images/Program/imgMan.gif'
	ReturnVisible='True'>
	<TitleStyle Width='100px'></TitleStyle>
	<InputStyle Width='130px' Height='30px' CssClass='Edit20'></InputStyle>
	<FrmFieldKeys FrmID='FrmITA03' BOID='ITA03' FieldName='ita03a006'></FrmFieldKeys>
</cc1:DscOpenQuery>
<cc1:DscTextBox id='ita03a007' runat='server' title='帳號名稱'
	style="Z-INDEX:689; POSITION: absolute; LEFT: 286px; TOP: 114px;"
	TxtInput_TabIndex='105'>
	<FrmFieldKeys FrmID='FrmITA03' BOID='ITA03' FieldName='ita03a007'></FrmFieldKeys>
	<TitleStyle Width='100px'></TitleStyle>
	<InputStyle Width='130px' Height='30px' CssClass='Edit20'></InputStyle>
</cc1:DscTextBox>
<cc1:DscOpenQuery id='ita03a008' runat='server' title='部門主管' ShowTitle='True'
	style="Z-INDEX: 679; POSITION: absolute; LEFT: 566px; TOP: 117px;"
	TxtInput_TabIndex='106' TextMode='SingleLine'
	BtnVisible='True' ImgSrc='../../_Common/AppUtil/Themes/images/Program/imgMan.gif'
	ReturnVisible='True'>
	<TitleStyle Width='100px'></TitleStyle>
	<InputStyle Width='130px' Height='30px' CssClass='Edit20'></InputStyle>
	<FrmFieldKeys FrmID='FrmITA03' BOID='ITA03' FieldName='ita03a008'></FrmFieldKeys>
</cc1:DscOpenQuery>
<cc1:DscTextBox id='textarea1' runat='server' title='原因說明'
	style="Z-INDEX:698; POSITION: absolute; LEFT: 6px; TOP: 255px;"
	TxtInput_TabIndex='108' TextMode='MultiLine'>
	<FrmFieldKeys FrmID='FrmITA03' BOID='ITA03' FieldName='textarea1'></FrmFieldKeys>
	<TitleStyle Width='100px'></TitleStyle>
	<InputStyle Width='691px' Height='100px' CssClass='Edit20'></InputStyle>
</cc1:DscTextBox>
<cc1:DscTextBox id='ita03a010' runat='server' title='職務:'
	style="Z-INDEX:692; POSITION: absolute; LEFT: 158px; TOP: 164px;"
	TxtInput_TabIndex='109'>
	<FrmFieldKeys FrmID='FrmITA03' BOID='ITA03' FieldName='ita03a010'></FrmFieldKeys>
	<TitleStyle Width='100px'></TitleStyle>
	<InputStyle Width='127px' Height='30px' CssClass='Edit20'></InputStyle>
</cc1:DscTextBox>
<cc1:DscTextBox id='ita03a011' runat='server' title='原職務:'
	style="Z-INDEX:691; POSITION: absolute; LEFT: 158px; TOP: 207px;"
	TxtInput_TabIndex='110'>
	<FrmFieldKeys FrmID='FrmITA03' BOID='ITA03' FieldName='ita03a011'></FrmFieldKeys>
	<TitleStyle Width='100px'></TitleStyle>
	<InputStyle Width='127px' Height='30px' CssClass='Edit20'></InputStyle>
</cc1:DscTextBox>
<cc1:DscTextBox id='ita03a012' runat='server' title='新職務:'
	style="Z-INDEX:687; POSITION: absolute; LEFT: 344px; TOP: 208px;"
	TxtInput_TabIndex='111'>
	<FrmFieldKeys FrmID='FrmITA03' BOID='ITA03' FieldName='ita03a012'></FrmFieldKeys>
	<TitleStyle Width='100px'></TitleStyle>
	<InputStyle Width='127px' Height='30px' CssClass='Edit20'></InputStyle>
</cc1:DscTextBox>
<cc1:DscTextBox id='ita03a009' runat='server' title='新進人員' ShowTitle='False'
	style="display:none;Z-INDEX:675; POSITION: absolute; LEFT: 105px; TOP: 169px;">
	<FrmFieldKeys FrmID='FrmITA03' BOID='ITA03' FieldName='ita03a009'></FrmFieldKeys>
</cc1:DscTextBox>
<asp:RadioButton ID='ita03a009_ctrolRadio0' runat='server' GroupName='ita03a009' Text='新進人員' Value='0' TabIndex='107' style='position:absolute;top:169px;left:105px;z-index:675;'/>
<asp:RadioButton ID='ita03a009_ctrolRadio1' runat='server' GroupName='ita03a009' Text='職務異動' Value='1' style='position:absolute;top:211px;left:105px;z-index:675;'/>

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
						<cc1:DscPanel ID='ecPnlDetail1' runat='server' FrmDefineKeys-BOID='ITA03_d01' FrmDefineKeys-FrmID='FrmITA03_d01' FrmDefineKeys-FrmType='Query'
							BorderStyle='None' BorderColor='Transparent' BorderWidth='0px'
							IniHTML="<div style='OVERFLOW: auto; WIDTH: 100%; POSITION: relative; HEIGHT: 100%;' ms_positioning='GridLayout'></div>"
							Width='100%' Height='0px'>
							<cc1:DscPanel ID='divDetail1Default' runat='server' FrmDefineKeys-BOID='ITA03_d01' FrmDefineKeys-FrmID='FrmITA03_d01' FrmDefineKeys-FrmType='Query'
								BorderStyle='None' BorderColor='Transparent' BorderWidth='0px'
								IniHTML="<div style='OVERFLOW: auto; WIDTH: 98%; POSITION: relative; HEIGHT: 100%;' ms_positioning='GridLayout'></div>"
								Width='744px' Height='206px' style='position:relative;'>
<cc1:DscTextBox id='ita03b001' runat='server' title='表單代號'
	style='display: none; Z-INDEX: 101; POSITION: absolute; LEFT: 245px; TOP: 16px;'
	TxtInput_TabIndex='0'>
	<INPUTSTYLE Width='120px'></INPUTSTYLE>
	<TITLESTYLE Width='110px'></TITLESTYLE>
	<FRMFIELDKEYS FrmID='FrmITA03_d01' BOID='ITA03_d01' FieldName='ita03b001'></FRMFIELDKEYS>
</cc1:DscTextBox>
<cc1:DscTextBox id='ita03b002' runat='server' title='表單單號'
	style='display: none; Z-INDEX: 102; POSITION: absolute; LEFT: 245px; TOP: 49px;'
	TxtInput_TabIndex='0'>
	<INPUTSTYLE Width='120px'></INPUTSTYLE>
	<TITLESTYLE Width='110px'></TITLESTYLE>
	<FRMFIELDKEYS FrmID='FrmITA03_d01' BOID='ITA03_d01' FieldName='ita03b002'></FRMFIELDKEYS>
</cc1:DscTextBox>

<cc1:DscTextBox id='ita03b003' runat='server' title='序號'
	style='display: none; Z-INDEX: 700; POSITION: absolute; LEFT: 245px; TOP: 82px;'
	TxtInput_TabIndex='0'>
	<INPUTSTYLE Width='120px' CssClass='Edit20'></INPUTSTYLE>
	<TITLESTYLE Width='100px'></TITLESTYLE>
	<FRMFIELDKEYS FrmID='FrmITA03_d01' BOID='ITA03_d01' FieldName='ita03b003'></FRMFIELDKEYS>
</cc1:DscTextBox>

<cc1:DscCheckBox ID='ita03b004' runat='server' Text='新增' ShowTitle='False'
	Style="z-index:697; position: absolute; left: 47px; top: 48px;"
	CheckBoxInput_TabIndex='112'
	Checked='False' CheckedTrueValue='1' CheckedFalseValue='0'>
	<InputStyle Width='55px' Height='22px' />
	<FrmFieldKeys FrmID='FrmITA03_d01' BOID='ITA03_d01' FieldName='ita03b004'></FrmFieldKeys>
</cc1:DscCheckBox>
<cc1:DscCheckBox ID='ita03b005' runat='server' Text='刪除' ShowTitle='False'
	Style="z-index:696; position: absolute; left: 47px; top: 78px;"
	CheckBoxInput_TabIndex='113'
	Checked='False' CheckedTrueValue='1' CheckedFalseValue='0'>
	<InputStyle Width='55px' Height='22px' />
	<FrmFieldKeys FrmID='FrmITA03_d01' BOID='ITA03_d01' FieldName='ita03b005'></FrmFieldKeys>
</cc1:DscCheckBox>
<cc1:DscCheckBox ID='ita03b006' runat='server' Text='修改' ShowTitle='False'
	Style="z-index:695; position: absolute; left: 47px; top: 110px;"
	CheckBoxInput_TabIndex='114'
	Checked='False' CheckedTrueValue='1' CheckedFalseValue='0'>
	<InputStyle Width='55px' Height='22px' />
	<FrmFieldKeys FrmID='FrmITA03_d01' BOID='ITA03_d01' FieldName='ita03b006'></FrmFieldKeys>
</cc1:DscCheckBox>
<cc1:DscTextBox id='ita03b007' runat='server' title='程式代號'
	style="Z-INDEX:694; POSITION: absolute; LEFT: 80px; TOP: 73px;"
	TxtInput_TabIndex='115'>
	<FrmFieldKeys FrmID='FrmITA03_d01' BOID='ITA03_d01' FieldName='ita03b007'></FrmFieldKeys>
	<TitleStyle Width='100px'></TitleStyle>
	<InputStyle Width='96px' Height='30px' CssClass='Edit20'></InputStyle>
</cc1:DscTextBox>
<cc1:DscTextBox id='ita03b008' runat='server' title='程式名稱'
	style="Z-INDEX:690; POSITION: absolute; LEFT: 242px; TOP: 73px;"
	TxtInput_TabIndex='116'>
	<FrmFieldKeys FrmID='FrmITA03_d01' BOID='ITA03_d01' FieldName='ita03b008'></FrmFieldKeys>
	<TitleStyle Width='100px'></TitleStyle>
	<InputStyle Width='192px' Height='30px' CssClass='Edit20'></InputStyle>
</cc1:DscTextBox>
<cc1:DscCheckBox ID='ita03b009' runat='server' Text='新增' ShowTitle='False'
	Style="z-index:685; position: absolute; left: 548px; top: 37px;"
	CheckBoxInput_TabIndex='117'
	Checked='False' CheckedTrueValue='1' CheckedFalseValue='0'>
	<InputStyle Width='55px' Height='22px' />
	<FrmFieldKeys FrmID='FrmITA03_d01' BOID='ITA03_d01' FieldName='ita03b009'></FrmFieldKeys>
</cc1:DscCheckBox>
<cc1:DscCheckBox ID='ita03b010' runat='server' Text='查詢' ShowTitle='False'
	Style="z-index:684; position: absolute; left: 548px; top: 59px;"
	CheckBoxInput_TabIndex='118'
	Checked='False' CheckedTrueValue='1' CheckedFalseValue='0'>
	<InputStyle Width='55px' Height='22px' />
	<FrmFieldKeys FrmID='FrmITA03_d01' BOID='ITA03_d01' FieldName='ita03b010'></FrmFieldKeys>
</cc1:DscCheckBox>
<cc1:DscCheckBox ID='ita03b011' runat='server' Text='修改' ShowTitle='False'
	Style="z-index:683; position: absolute; left: 548px; top: 84px;"
	CheckBoxInput_TabIndex='119'
	Checked='False' CheckedTrueValue='1' CheckedFalseValue='0'>
	<InputStyle Width='55px' Height='22px' />
	<FrmFieldKeys FrmID='FrmITA03_d01' BOID='ITA03_d01' FieldName='ita03b011'></FrmFieldKeys>
</cc1:DscCheckBox>
<cc1:DscCheckBox ID='ita03b012' runat='server' Text='刪除' ShowTitle='False'
	Style="z-index:682; position: absolute; left: 548px; top: 106px;"
	CheckBoxInput_TabIndex='120'
	Checked='False' CheckedTrueValue='1' CheckedFalseValue='0'>
	<InputStyle Width='55px' Height='22px' />
	<FrmFieldKeys FrmID='FrmITA03_d01' BOID='ITA03_d01' FieldName='ita03b012'></FrmFieldKeys>
</cc1:DscCheckBox>
<cc1:DscCheckBox ID='ita03b013' runat='server' Text='確認' ShowTitle='False'
	Style="z-index:681; position: absolute; left: 548px; top: 130px;"
	CheckBoxInput_TabIndex='121'
	Checked='False' CheckedTrueValue='1' CheckedFalseValue='0'>
	<InputStyle Width='55px' Height='22px' />
	<FrmFieldKeys FrmID='FrmITA03_d01' BOID='ITA03_d01' FieldName='ita03b013'></FrmFieldKeys>
</cc1:DscCheckBox>
<cc1:DscCheckBox ID='ita03b014' runat='server' Text='取消' ShowTitle='False'
	Style="z-index:678; position: absolute; left: 630px; top: 44px;"
	CheckBoxInput_TabIndex='122'
	Checked='False' CheckedTrueValue='1' CheckedFalseValue='0'>
	<InputStyle Width='55px' Height='22px' />
	<FrmFieldKeys FrmID='FrmITA03_d01' BOID='ITA03_d01' FieldName='ita03b014'></FrmFieldKeys>
</cc1:DscCheckBox>
<cc1:DscCheckBox ID='ita03b015' runat='server' Text='作廢' ShowTitle='False'
	Style="z-index:677; position: absolute; left: 631px; top: 63px;"
	CheckBoxInput_TabIndex='123'
	Checked='False' CheckedTrueValue='1' CheckedFalseValue='0'>
	<InputStyle Width='55px' Height='22px' />
	<FrmFieldKeys FrmID='FrmITA03_d01' BOID='ITA03_d01' FieldName='ita03b015'></FrmFieldKeys>
</cc1:DscCheckBox>
<cc1:DscCheckBox ID='ita03b016' runat='server' Text='輸出' ShowTitle='False'
	Style="z-index:676; position: absolute; left: 631px; top: 87px;"
	CheckBoxInput_TabIndex='124'
	Checked='False' CheckedTrueValue='1' CheckedFalseValue='0'>
	<InputStyle Width='55px' Height='22px' />
	<FrmFieldKeys FrmID='FrmITA03_d01' BOID='ITA03_d01' FieldName='ita03b016'></FrmFieldKeys>
</cc1:DscCheckBox>
<cc1:DscCheckBox ID='ita03b017' runat='server' Text='金額' ShowTitle='False'
	Style="z-index:675; position: absolute; left: 631px; top: 110px;"
	CheckBoxInput_TabIndex='125'
	Checked='False' CheckedTrueValue='1' CheckedFalseValue='0'>
	<InputStyle Width='55px' Height='22px' />
	<FrmFieldKeys FrmID='FrmITA03_d01' BOID='ITA03_d01' FieldName='ita03b017'></FrmFieldKeys>
</cc1:DscCheckBox>
<cc1:DscTextBox id='test01' runat='server' title='test01'
	style="Z-INDEX:675; POSITION: absolute; LEFT: 95px; TOP: 120px;"
	TxtInput_TabIndex='115'>
	<FrmFieldKeys FrmID='FrmITA03_d01' BOID='ITA03_d01' FieldName='test01'></FrmFieldKeys>
	<TitleStyle Width='100px'></TitleStyle>
	<InputStyle Width='96px' Height='30px' CssClass='Edit20'></InputStyle>
</cc1:DscTextBox>
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
<script src="ITA03.js?NoCache=20230914003" type="text/javascript"></script>
</asp:Content>
