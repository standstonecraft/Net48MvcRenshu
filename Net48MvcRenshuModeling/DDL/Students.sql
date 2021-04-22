DROP TABLE [dbo].[Students]
CREATE TABLE [dbo].[Students]
(
	[student_no] NVARCHAR(10) NOT NULL PRIMARY KEY, 
    [sei] NVARCHAR(50) NULL, 
    [mei] NVARCHAR(50) NULL, 
    [sei_kana] NVARCHAR(50) NULL, 
    [mei_kana] NVARCHAR(50) NULL, 
    [birth_date] DATE NULL, 
    [blood_type] NVARCHAR(10) NULL, 
    [gender] NVARCHAR(10) NULL, 
    [phone] NVARCHAR(15) NULL, 
    [postal_code] NVARCHAR(8) NULL, 
    [addr_pref] NVARCHAR(10) NULL, 
    [addr_city] NVARCHAR(20) NULL, 
    [addr_street] NVARCHAR(60) NULL, 
    [addr_building] NVARCHAR(60) NULL, 
    [addr_pref_kana] NVARCHAR(10) NULL, 
    [addr_city_kana] NVARCHAR(20) NULL, 
    [addr_street_kana] NVARCHAR(60) NULL, 
    [addr_building_kana] NVARCHAR(60) NULL 
)
