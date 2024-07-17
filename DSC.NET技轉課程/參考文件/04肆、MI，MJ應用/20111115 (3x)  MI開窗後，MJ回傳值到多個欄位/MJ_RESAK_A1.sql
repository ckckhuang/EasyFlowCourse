 DECLARE @MJ001 nchar(10) 
 DECLARE @MJ002 nchar(2) 
 DECLARE @MJ003 nvarchar(MAX) 
 DECLARE @MJ004 nvarchar(255) 
 SET @MJ001 = 'RESAK' 
 SET @MJ002 = 'A1' 
 SET @MJ003 = '-- MAINSELECT
SELECT resak002,resak009,resak015,resab002,resac002 FROM $$resak
left join $$resan as resan on resak001=resan003
left join $$resab as resab on resan004=resab001
left join $$resac as resac on resan005=resac001
WHERE resak001=:resak001
-- RETURN
resak002;resak009;resak015;resab002;resac002
-- MAINSELECT2' 
 SET @MJ004 = '*驗證回傳代理人工號,主要部門代號,職務,職稱' 
 IF NOT EXISTS (SELECT * FROM MJ WHERE MJ001 = @MI001 AND MJ002 = @MJ002) 
   BEGIN 
     INSERT INTO MJ 
       (MJ001, MJ002, MJ003, MJ004) 
     VALUES 
       (@MJ001, @MJ002, @MJ003, @MJ004) 
   END 
 ELSE 
   BEGIN 
     UPDATE MJ 
     SET MJ003 = @MJ003, MJ004 = @MJ004 
     WHERE MJ001 = @MJ001 and MJ002 = @MJ002 
   END 
