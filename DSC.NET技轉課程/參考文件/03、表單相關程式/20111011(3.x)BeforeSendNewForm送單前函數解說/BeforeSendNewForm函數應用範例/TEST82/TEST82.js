//單頭自訂驗證
function CustomerSaveCheck(tStatus)
{
	var tErr = "";
	var tMsg = "";
	var tFieldNotFilledMsg = getI18NForSpecial('PSMSG', 'Validation', 'RequriedFieldNotFilled', '../../_Common/PlatFormUtil/KernelPage/I18N/I18NForJs.aspx');
	var tIntErrMsg = getI18NForSpecial('PSMSG', 'Validation', 'IntErrMsg', '../../_Common/PlatFormUtil/KernelPage/I18N/I18NForJs.aspx');
	var tFloatErrMsg = getI18NForSpecial('PSMSG', 'Validation', 'FloatErrMsg', '../../_Common/PlatFormUtil/KernelPage/I18N/I18NForJs.aspx');
	if (tStatus == "CREATE")
	{
		//填表時要驗證
		

	}
	else if (tStatus == "APPROVE")
	{
		//簽核時要驗證
		

	}

	//填表及簽核都要驗證
	

   
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
function CustomerDetailSaveCheck(tStatus)
{
	var tErr = "";
	var tMsg = "";
	var tFieldNotFilledMsg = getI18NForSpecial('PSMSG', 'Validation', 'RequriedFieldNotFilled', '../../_Common/PlatFormUtil/KernelPage/I18N/I18NForJs.aspx');
	var tIntErrMsg = getI18NForSpecial('PSMSG', 'Validation', 'IntErrMsg', '../../_Common/PlatFormUtil/KernelPage/I18N/I18NForJs.aspx');
	var tFloatErrMsg = getI18NForSpecial('PSMSG', 'Validation', 'FloatErrMsg', '../../_Common/PlatFormUtil/KernelPage/I18N/I18NForJs.aspx');
	if (tStatus == "CREATE")
	{
		//填表時要驗證
		

	}
	else if (tStatus == "APPROVE")
	{
		//簽核時要驗證
		

	}

	//填表及簽核都要驗證
	

   
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


function GetDetialRowCount()
{ 
	var universalID = document.getElementById("MasterPage_universalID").value; 
	var tRetVal = tw.com.dsc.easyflowDotNet.forms.TEST82.GetDetialRowCount(universalID); 
	if(tRetVal.value == '0') 
	{ 
	 var errorMsg = getI18NForSpecial('FD', 'STD007', 'MsgDatechecked','../../../src/_Common/PlatFormUtil/KernelPage/I18N/I18NForJs.aspx'); 
	 alert(errorMsg); 
	 return false; 
	} 
	else 
	{ 
	 return true; 
	} 
} 

function SetCustomSubject()
{
	var SubjectVal=document.getElementById("MasterPage_txtCreateToolSubject_txt").value;
	$("#MasterPage_txtCreateToolSubject_txt").val(SubjectVal);
}

	
//2010/06/01:3.2.1.13:hiro:S00-20100323002:功能新增：新增人員、日期、部門(含多選開窗)元件↓
function getMultiOpenWindowValues(setField)
{
	if(document.getElementById("MasterPage_MasterPageContent_edReceiver_txt")!=null && document.getElementById("MasterPage_MasterPageContent_edReceiver_txt").value != null && document.getElementById("MasterPage_MasterPageContent_edReceiver_txt").value != "")
	{
		var tValueA = unescape(document.getElementById("MasterPage_MasterPageContent_edReceiver_txt").value);
		//2011/06/07:3.3.1.1:hiro:Q00-20110607001:修正人員多選開窗物件，應僅帶回人員工號-人員姓名，不應呈現人員工號-人員姓名-部門代號-部門名稱↓
		//document.getElementById("MasterPage_MasterPageContent_"+setField).value = tValueA.replace(/├/g,";").replace(/§/g,"-");
		document.getElementById("MasterPage_MasterPageContent_"+setField).value="";
		var tArr1 = tValueA.split("├");
		var tArr2 = new Array();
		for (var i = 0; i < tArr1.length; i++) {
			if (tArr1[i] != "") {
				tArr2 = tArr1[i].split("§");
				document.getElementById("MasterPage_MasterPageContent_"+setField).value += tArr2[0] + "-" + tArr2[1] + ";";
			}
		}
		//2011/06/07:3.3.1.1:hiro:Q00-20110607001:修正人員多選開窗物件，應僅帶回人員工號-人員姓名，不應呈現人員工號-人員姓名-部門代號-部門名稱↑
		document.getElementById("MasterPage_MasterPageContent_edReceiver_txt").value = "";
	}
}
//2010/06/01:3.2.1.13:hiro:S00-20100323002:功能新增：新增人員、日期、部門(含多選開窗)元件↑

//2010/06/01:3.2.1.13:hiro:S00-20100323002:功能新增：欄位計算、單身資料加總↓
String.prototype.trim = function () {
	return this.replace(/^\s+|\s+$/g, "");
}
//2010/06/01:3.2.1.13:hiro:S00-20100323002:功能新增：欄位計算、單身資料加總↑

//2010/06/01:3.2.1.15:hiro:S00-20100323002:功能新增：新增CheckBox或RadioButton觸發必填TextBox元件↓
function InitVisiable()
{

}
//2010/06/01:3.2.1.15:hiro:S00-20100323002:功能新增：新增CheckBox或RadioButton觸發必填TextBox元件↑

//2011/01/25:3.2.1.20:hiro:S00-20101005001:新增連動式下拉選單控制項↓
function InitOnChangeItem()
{

}

function CreateOption(pValue,pText,objselect)
{
	var new_option = new Option(pText,pValue);
	objselect.options.add(new_option);
}


//2011/01/25:3.2.1.20:hiro:S00-20101005001:新增連動式下拉選單控制項↑

//2011/03/09:3.2.1.26:hiro:S00-20110218003:增加人員樹型開窗功能(參考teppy的程式段)↓
//單選開窗
function SingleSelectEmpl(pPathPath, pReturnControlClientID, pMJ) {
	var tdialogHeight = 520;
	var tdialogWidth = 780;
	var tdialogTop = (screen.height - tdialogHeight) / 2;
	var tdialogLeft = (screen.width - tdialogWidth) / 2;
	var tStyle = "dialogTop:" + tdialogTop + "px; dialogLeft:" + tdialogLeft + "px; dialogHeight:" + tdialogHeight + "px; dialogWidth:" + tdialogWidth + "px; edge: Sunken; center: No; help: No; resizable: No; status: No;";
	var tReturnValue = window.showModalDialog(pPathPath, "", tStyle);
	if ((tReturnValue != undefined) && (tReturnValue != null) && (tReturnValue != "")) {
		document.getElementById(pReturnControlClientID).value = tReturnValue;
		doValidateII(pReturnControlClientID, pMJ, pReturnControlClientID);
		return true;
	}
}


//多選開窗
function MultiSelectEmpl(pPathPath, pReturnControlClientID, pType) {
	var tdialogHeight = 520;
	var tdialogWidth = 780;
	var tdialogTop = (screen.height - tdialogHeight) / 2;
	var tdialogLeft = (screen.width - tdialogWidth) / 2;
	var tStyle = "dialogTop:" + tdialogTop + "px; dialogLeft:" + tdialogLeft + "px; dialogHeight:" + tdialogHeight + "px; dialogWidth:" + tdialogWidth + "px; edge: Sunken; center: No; help: No; resizable: No; status: No;";
	var tReturnValue = window.showModalDialog(pPathPath, "", tStyle);
	
	if ((tReturnValue != undefined) && (tReturnValue != null) && (tReturnValue != "")) {
		var objTargetValue = "";
		var tArr1 = tReturnValue.split("├");
		var tArr2 = new Array();

		if (tReturnValue.indexOf("^Flag=Y") >= 0) {//如果有追加標誌，則追加到原文本框中
			if(pType==1){//第一種多選開窗方式
				var objTarget = document.getElementById(pReturnControlClientID+"_lst"); //目標List
				for (var i = 0; i < tArr1.length; i++) {
					if (tArr1[i] != "") {
						tArr2 = tArr1[i].split("§");

						var bHadExist = false;
						for(var j=0;j<objTarget.options.length;j++)
						{
							if(tArr2[0] + " " + tArr2[1] == objTarget.options[j].text)
								bHadExist=true;
						}
						if(bHadExist)
							continue;

						if(objTarget.options.length>0 && i<tArr1.length)//畫面上已有值存在，前面要加一個分隔符號
							document.getElementById(pReturnControlClientID+'_hidText').value += "§";

						//產生一個option元件
						var opt = document.createElement("option");
						//把opt加到目標List裡
						objTarget.options.add(opt);
						//指定opt的value及text
						opt.text = tArr2[0] + " " + tArr2[1];
						opt.value = tArr2[0] + " " + tArr2[1];

						document.getElementById(pReturnControlClientID+'_hidText').value += tArr2[0] + " " + tArr2[1];
					}
				}
			}
			else{//第二種多選開窗方式
				//有追加標誌
				objTargetValue = document.getElementById(pReturnControlClientID).value;
				for (var i = 0; i < tArr1.length; i++) {
					if (tArr1[i] != "") {
						tArr2 = tArr1[i].split("§");
						if (objTargetValue.indexOf(tArr2[0] + "-" + tArr2[1] + ";") < 0) {//不存在該資料時，才追加到欄位之中
							objTargetValue += tArr2[0] + "-" + tArr2[1] + ";";
						}
					}
				}
			}
		}
		else {//沒有追加標誌
			if(pType==1){//第一種多選開窗方式
				$('#'+pReturnControlClientID+'_hidText').val("");//沒有追加，則先清空hide欄位
				var objTarget = document.getElementById(pReturnControlClientID+"_lst"); //目標List
				for (var i = 0; i < tArr1.length; i++) {
					if (tArr1[i] != "") {
						tArr2 = tArr1[i].split("§");
						
						if($('#'+pReturnControlClientID+'_hidText').val().length>0 && i<tArr1.length)//畫面上已有值存在，前面要加一個分隔符號
							document.getElementById(pReturnControlClientID+'_hidText').value += "§";

						//產生一個option元件
						var opt = document.createElement("option");
						//把opt加到目標List裡
						objTarget.options.add(opt);
						//指定opt的value及text
						opt.text = tArr2[0] + " " + tArr2[1];
						opt.value = tArr2[0] + " " + tArr2[1];

						document.getElementById(pReturnControlClientID+'_hidText').value += tArr2[0] + " " + tArr2[1];
					}
				}
			}
			else{//第二種多選開窗方式
				$('#'+pReturnControlClientID).val("");//沒有追加，則先清空hide欄位
				objTargetValue = document.getElementById(pReturnControlClientID).value;
				for (var i = 0; i < tArr1.length; i++) {
					if (tArr1[i] != "") {
						tArr2 = tArr1[i].split("§");
						objTargetValue += tArr2[0] + "-" + tArr2[1] + ";";
					}
				}
			}
		}

		if(pType==1)
			document.getElementById(pReturnControlClientID+'_hidText2').value = document.getElementById(pReturnControlClientID+'_hidText').value;
		else
			document.getElementById(pReturnControlClientID).value = objTargetValue;

		return true;
	}
	else {
		//不做任何動作
		event.returnValue = false;
		return false;
	}
}
//2011/03/09:3.2.1.26:hiro:S00-20110218003:增加人員樹型開窗功能(參考teppy的程式段)↑

