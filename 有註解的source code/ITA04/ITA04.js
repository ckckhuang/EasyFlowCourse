//單頭自訂驗證
function CustomerSaveCheck_Head(tStatus)
{
	var tErr = "";
	var tFieldNotFilledMsg = getI18NForSpecial('PSMSG', 'Validation', 'RequriedFieldNotFilled', '../../_Common/PlatFormUtil/KernelPage/I18N/I18NForJs.aspx');
	var tIntErrMsg = getI18NForSpecial('PSMSG', 'Validation', 'IntErrMsg', '../../_Common/PlatFormUtil/KernelPage/I18N/I18NForJs.aspx');
	var tFloatErrMsg = getI18NForSpecial('PSMSG', 'Validation', 'FloatErrMsg', '../../_Common/PlatFormUtil/KernelPage/I18N/I18NForJs.aspx');
	var tDecimalErrMsg = getI18NForSpecial('PSMSG', 'Validation', 'DecimalErrMsg', '../../_Common/PlatFormUtil/KernelPage/I18N/I18NForJs.aspx');
	if (tStatus == "CREATE")
	{
		//填表時要驗證

	}
	else if (tStatus == "APPROVE")
	{
		//簽核時要驗證

	}

	//填表及簽核都要驗證
	//Int格式驗証
	var tita04a007 = $('#MasterPage_MasterPageContent_ita04a007_txt');
	if(tita04a007.length>0){
		var tita04a007Value = $('#MasterPage_MasterPageContent_ita04a007_txt').val().trim();
		if (tita04a007Value.length>0){
			if(!/^-?\d+$/.test(tita04a007Value)){
				//輸入的資料不符合int數值格式 !
				tErr += '「' + getI18NForSpecial('FD', 'ITA04', 'ita04a007', '../../_Common/PlatformUtil/KernelPage/I18N/I18NForJs.aspx') + '」  ' + tIntErrMsg + '\r\n';
			}
		}
	}

    //^_^ 20230921 edit by yating ↓
    //前端走Ajax後端執行檢查
    var _universalID = document.getElementById("MasterPage_universalID").value; //universalID

    //命名空間.類別名稱.Ajax Function名稱.value;
	var tRet = tw.com.dsc.easyflowDotNet.forms.ITA04.ajaxCheckBodyItemStock(_universalID).value;

	if (tRet!="") {
		tErr += tRet + "\r\n";
    }
	//^_^ 20230921 edit by yating ↑

	if (tErr == "")
	{
		return true;
	}
	else
	{
		alert(tErr);
		return false;
	}
}

//2020/03/25;6.1.13.5;hiro;S00-20200225001;草稿儲存僅做數值驗證，不做其他驗證↓
//草稿數值驗證
function DraftSaveCheck(){
	var tErr = "";
	var tIntErrMsg = getI18NForSpecial('PSMSG', 'Validation', 'IntErrMsg', '../../_Common/PlatFormUtil/KernelPage/I18N/I18NForJs.aspx');
	var tFloatErrMsg = getI18NForSpecial('PSMSG', 'Validation', 'FloatErrMsg', '../../_Common/PlatFormUtil/KernelPage/I18N/I18NForJs.aspx');
	var tDecimalErrMsg = getI18NForSpecial('PSMSG', 'Validation', 'DecimalErrMsg', '../../_Common/PlatFormUtil/KernelPage/I18N/I18NForJs.aspx');
	//數值驗證
	//Int格式驗証
	var tita04a007 = $('#MasterPage_MasterPageContent_ita04a007_txt');
	if(tita04a007.length>0){
		var tita04a007Value = $('#MasterPage_MasterPageContent_ita04a007_txt').val().trim();
		if (tita04a007Value.length>0){
			if(!/^-?\d+$/.test(tita04a007Value)){
				//輸入的資料不符合int數值格式 !
				tErr += '「' + getI18NForSpecial('FD', 'ITA04', 'ita04a007', '../../_Common/PlatformUtil/KernelPage/I18N/I18NForJs.aspx') + '」  ' + tIntErrMsg + '\r\n';
			}
		}
	}



	if (tErr == "")
	{
		return true;
	}
	else
	{
		alert(tErr);
		return false;
	}
}
//2020/03/25;6.1.13.5;hiro;S00-20200225001;草稿儲存僅做數值驗證，不做其他驗證↑

//單頭表單簽核鈕驗證單身全部欄位
function CustomerSaveCheck_DetailAllData(pFormId, pUniversalId)
{
	var tErr = "";

	tErr = tw.com.dsc.easyflowDotNet.forms.ITA04.ajaxCheckAllDetailDataVerify(pFormId, pUniversalId).value;

	if (tErr == "")
	{
		return true;
	}
	else
	{
		alert(tErr);
		return false;
	}
}


//單身自訂驗證
function CustomerSaveCheck_Body(tStatus)
{
	var tErr = "";
	var tFieldNotFilledMsg = getI18NForSpecial('PSMSG', 'Validation', 'RequriedFieldNotFilled', '../../_Common/PlatFormUtil/KernelPage/I18N/I18NForJs.aspx');
	var tIntErrMsg = getI18NForSpecial('PSMSG', 'Validation', 'IntErrMsg', '../../_Common/PlatFormUtil/KernelPage/I18N/I18NForJs.aspx');
	var tFloatErrMsg = getI18NForSpecial('PSMSG', 'Validation', 'FloatErrMsg', '../../_Common/PlatFormUtil/KernelPage/I18N/I18NForJs.aspx');
	var tDecimalErrMsg = getI18NForSpecial('PSMSG', 'Validation', 'DecimalErrMsg', '../../_Common/PlatFormUtil/KernelPage/I18N/I18NForJs.aspx');
	if (tStatus == "CREATE")
	{
		//填表時要驗證

	}
	else if (tStatus == "APPROVE")
	{
		//簽核時要驗證

	}

	//填表及簽核都要驗證
	if($('#MasterPage_MasterPageContent_TabStrip2')[0].selectedIndex==0){
		//Int格式驗証
		var tita04b006 = $('#MasterPage_MasterPageContent_ita04b006_txt');
		if(tita04b006.length>0){
			var tita04b006Value = $('#MasterPage_MasterPageContent_ita04b006_txt').val().trim();
			if (tita04b006Value.length>0){
				if(!/^-?\d+$/.test(tita04b006Value)){
					//輸入的資料不符合int數值格式 !
					tErr += '「' + getI18NForSpecial('FD', 'ITA04_d01', 'ita04b006', '../../_Common/PlatformUtil/KernelPage/I18N/I18NForJs.aspx') + '」  ' + tIntErrMsg + '\r\n';
				}
			}
		}
	}


	if($('#MasterPage_MasterPageContent_TabStrip2')[0].selectedIndex==0){
		//Int格式驗証
		var tita04b007 = $('#MasterPage_MasterPageContent_ita04b007_txt');
		if(tita04b007.length>0){
			var tita04b007Value = $('#MasterPage_MasterPageContent_ita04b007_txt').val().trim();
			if (tita04b007Value.length>0){
				if(!/^-?\d+$/.test(tita04b007Value)){
					//輸入的資料不符合int數值格式 !
					tErr += '「' + getI18NForSpecial('FD', 'ITA04_d01', 'ita04b007', '../../_Common/PlatformUtil/KernelPage/I18N/I18NForJs.aspx') + '」  ' + tIntErrMsg + '\r\n';
				}
			}
		}
	}


	if($('#MasterPage_MasterPageContent_TabStrip2')[0].selectedIndex==0){
		//Int格式驗証
		var tita04b008 = $('#MasterPage_MasterPageContent_ita04b008_txt');
		if(tita04b008.length>0){
			var tita04b008Value = $('#MasterPage_MasterPageContent_ita04b008_txt').val().trim();
			if (tita04b008Value.length>0){
				if(!/^-?\d+$/.test(tita04b008Value)){
					//輸入的資料不符合int數值格式 !
					tErr += '「' + getI18NForSpecial('FD', 'ITA04_d01', 'ita04b008', '../../_Common/PlatformUtil/KernelPage/I18N/I18NForJs.aspx') + '」  ' + tIntErrMsg + '\r\n';
				}
			}
		}
	}

	//^_^ 20230921 edit by yating ↓
	var _universalID = document.getElementById("MasterPage_universalID").value;
	var _ita04b003 = document.getElementById("MasterPage_MasterPageContent_ita04b003_txt").value; //當前的序號
	var _ita04b004 = document.getElementById("MasterPage_MasterPageContent_ita04b004_txt").value; //當前的品項ID
	var _ita04b005 = document.getElementById("MasterPage_MasterPageContent_ita04b005_txt").value; //當前的需求日

	//命名空間.類別名稱.GetServerTime().value;
	var tRet = tw.com.dsc.easyflowDotNet.forms.ITA04.ajaxCheckBodyItem(_universalID, _ita04b003, _ita04b004, _ita04b005).value;

	if (tRet) {
		//單身已存在相同品項+需求日期資料，請重新輸入!
		tErr += getI18NForSpecial('FD', 'ITA04', 'MSG001', '../../_Common/PlatFormUtil/KernelPage/I18N/I18NForJs.aspx') + "\r\n";
	}
	//^_^ 20230921 edit by yating ↑


	if (tErr == "")
	{
		return true;
	}
	else
	{
		alert(tErr);
		return false;
	}
}

String.prototype.trim = function () {
	return this.replace(/^\s+|\s+$/g, "");
}

//填表時顯示提示字串
function InitOpenShowMSG(){
	alert('');
}

function InitTriggerMust(tStatus){
	//2022/07/15;Folls;C01-20220715005;Radio及checkbox於簽核時無法實現觸發顯示欄位
	if(tStatus=="CREATE" || tStatus=="DISPLAY" || tStatus==""|| tStatus=="APPROVE"){

	}
}

function InitTriggerOpen(){

}

function InitCalculated(){

}

function InitOnChangeItem()
{

}

function CreateOption(pValue,pText,objselect)
{
	var new_option = new Option(pText,pValue);
	objselect.options.add(new_option);
}

function FunOnChange_ita04a005()
{
	var evt = (event)?event:window.event;
	var element=evt.srcElement || evt.target;
	//如果是透過 automimj 不觸發
	if (element != null && element.id != null)
	{
		$('#MasterPage_MasterPageContent_ita04a006_txt').val("");
		$('#MasterPage_MasterPageContent_ita04a006_txt2').text("");
	}
}//EndFun_FunOnChange_ita04a005()

function FunCheckIsChanged_ita04a005()
{
	var PreSetValue = $('#MasterPage_MasterPageContent_hdnOpenQueryPreSetValue').val();
	if(PreSetValue.length>0){
		var aryPreSetValue = PreSetValue.split('§');
		if(aryPreSetValue.length>1){
			if("ita04a005" == aryPreSetValue[0] && $('#MasterPage_MasterPageContent_ita04a005_txt').val() != aryPreSetValue[1])
				FunOnChange_ita04a005();
		}
	}
	else{
		FunOnChange_ita04a005();
	}
}//EndFun_FunCheckIsChanged_ita04a005()



function InitNumberToWord()
{

}

function getMoneyWord(pNumberContrlID, pDecimalPlaces, pWordControlID)
{
	var strErr="";
	if($('#MasterPage_MasterPageContent_'+pNumberContrlID+'_txt').length>0 && $('#MasterPage_MasterPageContent_'+pNumberContrlID+'_txt').is(':visible')){
		var tControlNumValue = $('#MasterPage_MasterPageContent_'+pNumberContrlID+'_txt').val().trim();
		if(tControlNumValue.length>0){
			if(isNaN(tControlNumValue)) {
				//請輸入數值!
				strErr = getI18NForSpecial('PSMSG','NumsCheck','NumsCheckMSG001','../../../src/_Common/PlatFormUtil/KernelPage/I18N/I18NForJs.aspx');
			}
			else{
				//這裡使用者如果輸入超過16進位的數值，就會失真！
				//tControlNumValue = parseFloat(tControlNumValue).toFixed(pDecimalPlaces);
				tControlNumValue = tw.com.dsc.easyflowDotNet.forms.ITA04.ajaxGetFixedNum(tControlNumValue, pDecimalPlaces).value;

				$('#MasterPage_MasterPageContent_'+pNumberContrlID+'_txt').val(tControlNumValue);
				var iIntegerSTR="";
				var tDecimalSTR="";
				if(pDecimalPlaces>0){
					//含小數位
					var aryControlNumValue = tControlNumValue.toString().split('.');
					iIntegerSTR = parseInt(aryControlNumValue[0]);
					tDecimalSTR = aryControlNumValue[1];
				}
				else{
					iIntegerSTR = tControlNumValue;
				}

				//if(iIntegerSTR>=10000000000000000 || iIntegerSTR<=-9999999999999999)
				if(iIntegerSTR<0){
					if(iIntegerSTR.toString().length>17)
						//數值溢位!請輸入較大的數值!
						strErr = getI18NForSpecial('Message','NumsCheck','NumsOverRangMSG001','../../../src/_Common/PlatFormUtil/KernelPage/I18N/I18NForJs.aspx');
				}
				else{
					if(iIntegerSTR.toString().length>16)
						//數值溢位!請輸入較小的數值!
						strErr = getI18NForSpecial('Message','NumsCheck','NumsOverRangMSG002','../../../src/_Common/PlatFormUtil/KernelPage/I18N/I18NForJs.aspx');
				}
			}

			if(strErr!=""){
				alert(strErr);
				$('#MasterPage_MasterPageContent_'+pNumberContrlID+'_txt').val("");
				$('#MasterPage_MasterPageContent_'+pWordControlID+'_txt').val("");
				return false;
			}

			var tControlWordValue = tw.com.dsc.easyflowDotNet.forms.ITA04.ajaxGetMoneyWord(tControlNumValue).value;
			$('#MasterPage_MasterPageContent_'+pWordControlID+'_txt').val(tControlWordValue);
		}
		//2015/09/14;3.7.3.19;hiro;V00-20150914007;修正數值轉大寫，數值為空白時，沒有一併清空轉大寫欄位↓
		else {
			$('#MasterPage_MasterPageContent_'+pWordControlID+'_txt').val("");
		}
		//2015/09/14;3.7.3.19;hiro;V00-20150914007;修正數值轉大寫，數值為空白時，沒有一併清空轉大寫欄位↑
	}
	return true;
}

function InitReadOnly()
{

}


function SetCustomSubject()
{
	//使用者自訂主旨start
	var tSubjectVal='';
	var tSubjectTxt=document.getElementById("MasterPage_txtCreateToolSubject_txt").value;
	var tSubjectSelf='';
	tSubjectSelf+='文具請領單，申請人'+
$('#MasterPage_MasterPageContent_ita04a006_txt').val()+'-'+$('#MasterPage_MasterPageContent_ita04a006_txt2hdn').val()+'，申請部門'+
$('#MasterPage_MasterPageContent_ita04a005_txt').val()+'-'+$('#MasterPage_MasterPageContent_ita04a005_txt2hdn').val();

	//自訂主旨
	tSubjectVal=tSubjectSelf;

	if(tSubjectVal.length>255){tSubjectVal=tSubjectVal.substring(0,255);}
	//使用者自訂主旨end

	$("#MasterPage_txtCreateToolSubject_txt").val(tSubjectVal);
}


function setSelectPanelValue()
{
	var aryFields = [];//單頭、單身多選開窗
	var intFieldsLength = aryFields.length;
	for(var i=0;i<intFieldsLength;i++){
		var tField=aryFields[i];
		if($('#MasterPage_MasterPageContent_DscOpenQuery'+tField+'_txt').length>0){
			var hdnValue = $('#MasterPage_MasterPageContent_DscOpenQuery'+tField+'_txt').val();
			$('#MasterPage_MasterPageContent_SelectPanel'+tField+'_hidText').val(hdnValue);
			$('#MasterPage_MasterPageContent_SelectPanel'+tField+'_hidText2').val(hdnValue);

			if($('#MasterPage_MasterPageContent_SelectPanel'+tField+'_lst').length>0){
				$('#MasterPage_MasterPageContent_SelectPanel'+tField+'_lst')[0].options.length=0;

				if($('#MasterPage_MasterPageContent_SelectPanel'+tField+'_lstTbx').length>0){
					$('#MasterPage_MasterPageContent_SelectPanel'+tField+'_lstTbx').val("");
				}

				if(hdnValue.length>0){
					var aryHdnFieldSplit = hdnValue.split('§');
					var intHdnFieldSplitLength = aryHdnFieldSplit.length;
					for (var j = 0; j < intHdnFieldSplitLength; j++){
						var tShowItem = aryHdnFieldSplit[j];
						tShowItem=tShowItem.replace(/┼┼/g, " ");
						var new_option = new Option(tShowItem, tShowItem);
						$('#MasterPage_MasterPageContent_SelectPanel'+tField+'_lst')[0].options.add(new_option);

						if($('#MasterPage_MasterPageContent_SelectPanel'+tField+'_lstTbx').length>0){
							document.getElementById('MasterPage_MasterPageContent_SelectPanel' + tField + '_lstTbx').value += tShowItem;
							if (j != intHdnFieldSplitLength - 1)
							{
								document.getElementById('MasterPage_MasterPageContent_SelectPanel' + tField + '_lstTbx').value += '\r\n';
							}
						}
					}
				}
			}
		}
	}
}


function jsDoDispatch(pFormID, pSheetNo, pDispatchFormID){
	//若您已有編輯此表單資料, 此動作會清除您所編輯的資料! [請問是否繼續?
	var tConfirmSTR = getI18NForSpecial('FD','EFBaseMasterPage','EFMsgBoxJS007','../../../src/_Common/PlatFormUtil/KernelPage/I18N/I18NForJs.aspx');
	if(window.confirm(tConfirmSTR.split('[')[0].toString() + "\r\n\r\n" + tConfirmSTR.split('[')[1].toString())){
		var bResult = tw.com.dsc.easyflowDotNet.forms.ITA04.ajaxDoDispatchForm(pFormID, pSheetNo, pDispatchFormID).value;
		var tDispatchFormResult="";
		if(bResult){
			//執行派送表單成功!
			tDispatchFormResult=getI18NForSpecial('Message','EFWizardForm','DispatchFormSuccess','../../../src/_Common/PlatFormUtil/KernelPage/I18N/I18NForJs.aspx');
			alert(tDispatchFormResult);
			//Refresh 原頁面避免 Session 錯亂
			location.reload();
		}
		else{
			//執行派送表單失敗!
			tDispatchFormResult=getI18NForSpecial('Message','EFWizardForm','DispatchFormFail','../../../src/_Common/PlatFormUtil/KernelPage/I18N/I18NForJs.aspx');
			alert(tDispatchFormResult);
		}
	}
}

//單身新增狀態，開窗控件MJ取得初始值設定
function AutoMJForBodyAddStatus(){
	try{
		var tHeadStatus = document.getElementById("MasterPage_MasterPageContent_currentDiv").value;
		if (tHeadStatus=='qbeResult'){}
		else{
			var tBody01DetailStatus=$("#MasterPage_MasterPageContent_GridUserControl1_hdnGS002").val();
			if("add"==tBody01DetailStatus){
				if(document.getElementById('MasterPage_MasterPageContent_ita04b004_txt') != null)
				{
					document.getElementById('MasterPage_MasterPageContent_ita04b004_txt').onchange(); document.getElementById('MasterPage_MasterPageContent_ita04b004_txt').onblur();
				}
			}
		}
	}
	catch(e){}
}
// ^_^ CK edit 20230920
function funComputeSubtotal() {
	var _price = document.getElementById("MasterPage_MasterPageContent_ita04b006_txt").value;
	var _qty = document.getElementById("MasterPage_MasterPageContent_ita04b007_txt").value;
	document.getElementById("MasterPage_MasterPageContent_ita04b008_txt").value = _price * _qty;
}
// ^_^ CK edit 20230920

//^_^ 20230921 edit by yating ↓
//強制觸發申請人驗證
function do_ita04a006OnBulr() {
	var _ita04a006 = document.getElementById("MasterPage_MasterPageContent_ita04a006_txt");

	if (_ita04a006 != null) {
		_ita04a006.onchange(); //強制告知程式此欄位有異動
		_ita04a006.onblur();  //觸發驗證
    }
}

//^_^ 20230921 edit by yating ↑