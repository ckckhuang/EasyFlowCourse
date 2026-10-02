/****** Table [sysba] [INSERT Command] ******/

IF NOT EXISTS(SELECT * FROM sysba WHERE sysba001='ODMDefaultCompany')
BEGIN
INSERT sysba (sysba001, sysba002, sysba003, pseudo, sysba004, sysba005, sysba006, sysba007, sysba008, sysba009, sysba061, sysba062, sysba063, sysba064, sysba065, sysba066, sysba067, sysba068, sysba069, sysba070) VALUES (N'ODMDefaultCompany', N'L0000174328_GP32', N'預設的公司別DBName', NULL, N'all', N'預設的公司別DBName', N'預設的公司別DBName', N'ODM', N'Y', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL )
END

IF NOT EXISTS(SELECT * FROM sysba WHERE sysba001='ODMERPDBLoginName')
BEGIN
INSERT sysba (sysba001, sysba002, sysba003, pseudo, sysba004, sysba005, sysba006, sysba007, sysba008, sysba009, sysba061, sysba062, sysba063, sysba064, sysba065, sysba066, sysba067, sysba068, sysba069, sysba070) VALUES (N'ODMERPDBLoginName', N'sa', N'ERP 資料庫帳號(回寫用)', NULL, N'all', N'ERP 資料庫帳號(回寫用)', N'ERP 資料庫帳號(回寫用)', N'ODM', N'Y', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL )
END

IF NOT EXISTS(SELECT * FROM sysba WHERE sysba001='ODMERPDBPwd')
BEGIN
INSERT sysba (sysba001, sysba002, sysba003, pseudo, sysba004, sysba005, sysba006, sysba007, sysba008, sysba009, sysba061, sysba062, sysba063, sysba064, sysba065, sysba066, sysba067, sysba068, sysba069, sysba070) VALUES (N'ODMERPDBPwd', N'123', N'ERP 資料庫密碼(回寫用)', NULL, N'all', N'ERP 資料庫密碼(回寫用)', N'ERP 資料庫密碼(回寫用)', N'ODM', N'Y', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL )
END

IF NOT EXISTS(SELECT * FROM sysba WHERE sysba001='ODMERPIP')
BEGIN
INSERT sysba (sysba001, sysba002, sysba003, pseudo, sysba004, sysba005, sysba006, sysba007, sysba008, sysba009, sysba061, sysba062, sysba063, sysba064, sysba065, sysba066, sysba067, sysba068, sysba069, sysba070) VALUES (N'ODMERPIP', N'10.20.81.56', N'ERP LINK SERVER IP', NULL, N'all', N'ERP LINK SERVER IP', N'ERP LINK SERVER IP', N'OEM', N'Y', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL )
END

IF NOT EXISTS(SELECT * FROM sysba WHERE sysba001='ODMERPSYSDBName')
BEGIN
INSERT sysba (sysba001, sysba002, sysba003, pseudo, sysba004, sysba005, sysba006, sysba007, sysba008, sysba009, sysba061, sysba062, sysba063, sysba064, sysba065, sysba066, sysba067, sysba068, sysba069, sysba070) VALUES (N'ODMERPSYSDBName', N'D0000174328_GP32', N'ERPSYSDBName', NULL, N'all', N'ERPSYSDBName', N'ERPSYSDBName', N'ODM', N'Y', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL )
END

IF NOT EXISTS(SELECT * FROM sysba WHERE sysba001='ODMShowERPDBName')
BEGIN
INSERT sysba (sysba001, sysba002, sysba003, pseudo, sysba004, sysba005, sysba006, sysba007, sysba008, sysba009, sysba061, sysba062, sysba063, sysba064, sysba065, sysba066, sysba067, sysba068, sysba069, sysba070) VALUES (N'ODMShowERPDBName', N'L0000174328_GP32', N'要顯示在公司別下拉的ERP公司別DBName，空白表全部，用分號隔開，ex:CompanyA;CompanyB', NULL, N'all', N'要顯示在公司別下拉的ERP公司別DBName，空白表全部，用分號隔開，ex:CompanyA;CompanyB', N'要顯示在公司別下拉的ERP公司別DBName，空白表全部，用分號隔開，ex:CompanyA;CompanyB', N'ODM', N'Y', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL )
END


/****** Table [sysba] [UPDATE Command] ******/

UPDATE sysba SET sysba002=N'L0000174328_GP32', sysba003=N'預設的公司別DBName', pseudo=NULL, sysba004=N'all', sysba005=N'預設的公司別DBName', sysba006=N'預設的公司別DBName', sysba007=N'ODM', sysba008=N'Y', sysba009=NULL, sysba061=NULL, sysba062=NULL, sysba063=NULL, sysba064=NULL, sysba065=NULL, sysba066=NULL, sysba067=NULL, sysba068=NULL, sysba069=NULL, sysba070=NULL WHERE sysba001='ODMDefaultCompany' 
UPDATE sysba SET sysba002=N'sa', sysba003=N'ERP 資料庫帳號(回寫用)', pseudo=NULL, sysba004=N'all', sysba005=N'ERP 資料庫帳號(回寫用)', sysba006=N'ERP 資料庫帳號(回寫用)', sysba007=N'ODM', sysba008=N'Y', sysba009=NULL, sysba061=NULL, sysba062=NULL, sysba063=NULL, sysba064=NULL, sysba065=NULL, sysba066=NULL, sysba067=NULL, sysba068=NULL, sysba069=NULL, sysba070=NULL WHERE sysba001='ODMERPDBLoginName' 
UPDATE sysba SET sysba002=N'123', sysba003=N'ERP 資料庫密碼(回寫用)', pseudo=NULL, sysba004=N'all', sysba005=N'ERP 資料庫密碼(回寫用)', sysba006=N'ERP 資料庫密碼(回寫用)', sysba007=N'ODM', sysba008=N'Y', sysba009=NULL, sysba061=NULL, sysba062=NULL, sysba063=NULL, sysba064=NULL, sysba065=NULL, sysba066=NULL, sysba067=NULL, sysba068=NULL, sysba069=NULL, sysba070=NULL WHERE sysba001='ODMERPDBPwd' 
UPDATE sysba SET sysba002=N'10.20.81.56', sysba003=N'ERP LINK SERVER IP', pseudo=NULL, sysba004=N'all', sysba005=N'ERP LINK SERVER IP', sysba006=N'ERP LINK SERVER IP', sysba007=N'OEM', sysba008=N'Y', sysba009=NULL, sysba061=NULL, sysba062=NULL, sysba063=NULL, sysba064=NULL, sysba065=NULL, sysba066=NULL, sysba067=NULL, sysba068=NULL, sysba069=NULL, sysba070=NULL WHERE sysba001='ODMERPIP' 
UPDATE sysba SET sysba002=N'D0000174328_GP32', sysba003=N'ERPSYSDBName', pseudo=NULL, sysba004=N'all', sysba005=N'ERPSYSDBName', sysba006=N'ERPSYSDBName', sysba007=N'ODM', sysba008=N'Y', sysba009=NULL, sysba061=NULL, sysba062=NULL, sysba063=NULL, sysba064=NULL, sysba065=NULL, sysba066=NULL, sysba067=NULL, sysba068=NULL, sysba069=NULL, sysba070=NULL WHERE sysba001='ODMERPSYSDBName' 
UPDATE sysba SET sysba002=N'L0000174328_GP32', sysba003=N'要顯示在公司別下拉的ERP公司別DBName，空白表全部，用分號隔開，ex:CompanyA;CompanyB', pseudo=NULL, sysba004=N'all', sysba005=N'要顯示在公司別下拉的ERP公司別DBName，空白表全部，用分號隔開，ex:CompanyA;CompanyB', sysba006=N'要顯示在公司別下拉的ERP公司別DBName，空白表全部，用分號隔開，ex:CompanyA;CompanyB', sysba007=N'ODM', sysba008=N'Y', sysba009=NULL, sysba061=NULL, sysba062=NULL, sysba063=NULL, sysba064=NULL, sysba065=NULL, sysba066=NULL, sysba067=NULL, sysba068=NULL, sysba069=NULL, sysba070=NULL WHERE sysba001='ODMShowERPDBName' 

