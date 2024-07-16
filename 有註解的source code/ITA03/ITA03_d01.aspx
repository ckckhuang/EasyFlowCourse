<%@ Page language="c#" CodeFile="ITA03_d01.aspx.cs" MasterPageFile="~/src/_Common/AppUtil/EFMasterPage/EFBaseMasterPage.master" AutoEventWireup="false" enableEventValidation="false" Inherits="tw.com.dsc.easyflowDotNet.forms.ITA03_d01" %>
<%@ Register TagPrefix="uc1" TagName="gridUserControl" Src="../../_Common/PlatformUtil/KernelPage/Grid/gridUserControl.ascx" %>
<%@ Register TagPrefix="iewc" Namespace="Microsoft.Web.UI.WebControls" Assembly="Microsoft.Web.UI.WebControls" %>
<%@ Register TagPrefix="cc1" Namespace="tw.com.dsc.dscDotNet.dscWebControls" Assembly="PlatformUtil" %>
@RegisterTag
<asp:Content ID="ITA03_d01FormContent" ContentPlaceHolderID="MasterPageContent" runat="server">
	<!--單檔架構 -->
	<!--2009/03/19:Joseph:<div id="cover" style="OVERFLOW: auto; WIDTH: 100%;">-->
		<div id="cover" style="WIDTH: 100%;">
			<div id="createRecord" style="WIDTH: 100%; HEIGHT: 100%" runat="server">
				<cc1:DscPanel id="ecPnlMaster" runat="server" Width="98%" IniHTML='&#10;<div style="OVERFLOW: auto; WIDTH: 100%; POSITION: relative; HEIGHT: 100%" ms_positioning="GridLayout"></div>'
					FrmDefineKeys-FrmType="Query" FrmDefineKeys-FrmID="FrmITA03_d01" FrmDefineKeys-BOID="ITA03_d01"
					BorderStyle="None" BorderColor="Transparent" BorderWidth="0px" Height="@divHeadHeightpx">
					<!--單頭頁籤-->
					<iewc:TabStrip id="TabStrip1" runat="server" 
						TabDefaultStyle="background-image:url(../../_Common/AppUtil/Themes/images/Menu/Tbtn01.gif);" 
						TabHoverStyle="background-image:url(../../_Common/AppUtil/Themes/images/Menu/Tbtn01.gif);" 
						TabSelectedStyle="background-image:url(../../_Common/AppUtil/Themes/images/Menu/Tbtn02.gif);" 
						CssClass="divToolBar2" ><table><tr><td height='5'></td></tr></table>
					<!--單身頁籤-->
					<iewc:TabStrip id='TabStrip2' runat='server' CssClass='divToolBar2'
						TabDefaultStyle='background-image:url(../../_Common/AppUtil/Themes/images/Menu/Tbtn01.gif);'
						TabHoverStyle='background-image:url(../../_Common/AppUtil/Themes/images/Menu/Tbtn01.gif);'
						TabSelectedStyle='background-image:url(../../_Common/AppUtil/Themes/images/Menu/Tbtn02.gif);'>
						<iewc:Tab ID="bodyDefault" Text="單身頁籤1" DefaultStyle="width:100px;height:27px;vertical-align:middle;text-align:center;"></iewc:Tab>
					</iewc:TabStrip>

					</iewc:TabStrip>
					<!--單頭頁籤畫面集合-->

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

							</cc1:DscPanel>
							<uc1:gridusercontrol id='GridUserControl1' runat='server'></uc1:gridusercontrol>
						</cc1:DscPanel>
					</div>


					
					<!--單身Grid畫面-->
					
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
@UpdatePanel
<!--引用JavaScript-->
<script src="ITA03_d01.js?NoCache=202207291705" type="text/javascript"></script>
</asp:Content>
