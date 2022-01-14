if not exists (Select * From sys.databases Where name='SWCRM')
Create Database SWCRM
Go
Use SWCRM
Go
/** departmanlar tablosu**/
if not exists (Select * From INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME='Departments')
Create Table Departments
(
 DepartmanId int identity Primary Key,
 Name Nvarchar(max)
)
Go

if not exists (Select * From INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME='Situations')
Create Table Situations
(
StatusId int identity,
[Status] nvarchar(100),
CONSTRAINT Pk_Situations_StatusId Primary Key (StatusId)
)
Go
/** çalýþma durumu  **/
if not exists (Select * From INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME='WorkingSituations')
Create Table WorkingSituations
(
WorkingStatusId int identity,
WorkingStatus nvarchar(100),
CONSTRAINT Pk_WorkingSituations_WorkingStatusId Primary Key (WorkingStatusId)
)
Go
/** sonuç tablosu**/
if not exists (Select * From INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME='Results')
Create Table Results
( 
ResultId int identity,
ResultName nvarchar(50),
CONSTRAINT Pk_Results_ResultId Primary Key (ResultId)
)
Go
if not exists (Select * From INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME='Categories')
Create Table Categories
(
CategoryId int identity Primary Key,
Name nvarchar(50),
StatusId int,
CONSTRAINT Fk_Categories_StatusId Foreign Key (StatusId) References Situations(StatusId)

)
Go

/** markalar tablosu**/
if not exists (Select * From INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME='Brands')
Create Table Brands
(
BrandId int identity Primary Key,
Name nvarchar(50),
StatusId int,
CONSTRAINT Fk_Brands_StatusId Foreign Key (StatusId) References Situations(StatusId)

)
Go

/** kayýt ol kullanýcý giriþi tablosu**/
if not exists (Select * From INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME='SingUp')
Create Table SingUp
(
SingUpId int identity Primary Key ,
Name nvarchar(max),
Surname nvarchar(max),
CompanyName nvarchar(max),
Phone nvarchar(11),
Email nvarchar(max),/*kullanýcý giriþinde kullanýlacak*/
[Password] nvarchar(max),/*kullanýcý giriþnde kullanýlacak*/
PasswordAgain nvarchar(max)

)
Go
if not exists (Select * From INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME='Employers')
Create Table Employers
(
SingUpId int identity Primary Key ,
UserName nvarchar(max),
NameSurname nvarchar(max),
[Password] nvarchar(max)
)
Go
/** sektör tablosu**/
if not exists (Select * From INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME='Sectors')
Create Table Sectors
(
SectorId int identity,
SectorsName nvarchar(100),
CONSTRAINT Pk_Sectors_SectorId Primary Key (SectorId)
)
Go
/** çalýþan sayýsý tablosu**/
if not exists (Select * From INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME='NumberOfEmployees')
Create Table NumberOfEmployees
(
NumberOfEmployeeId int identity,
NumberOfEmployeeName nvarchar(50),
CONSTRAINT Pk_NumberOfEmployees_NumberOfEmployeeId Primary Key (NumberOfEmployeeId)
)
Go
/** kayýt tipi tablosu**/
if not exists (Select * From INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME='RecordTypes')
Create Table RecordTypes
(
RecordTypeId int identity,
RecordTypeName nvarchar(50),
CONSTRAINT Pk_RecordTypes_RecordTypeId Primary Key (RecordTypeId)
)
Go
/** teklif durumu tablosu**/
if not exists (Select * From INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME='DealStatus')
Create Table DealStatus
(
DealStatusId int identity,
DealStatusName nvarchar(50),
CONSTRAINT Pk_DealStatus_DealStatusId Primary Key (DealStatusId)
)
Go

if not exists (Select * From INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME='Genders')
Create Table Genders
(
GenderId int identity,
GenderName nvarchar(100),
CONSTRAINT Pk_Genders_GenderId Primary Key (GenderId)
)
Go
/** kontaklar- firma tablosu**/
if not exists (Select * From INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME='Contacts')
Create Table Contacts
(
ContactId int identity Primary Key,
NameSurname nvarchar(100),
CompanyName nvarchar(max),
Position nvarchar(max),
RecordTypeId int,
Phone nvarchar(11),
Email nvarchar(max),
[Address] ntext,
NumberOfEmployeesId int,
SectorId int,
SingUpId int,
GenderId int,
CONSTRAINT Fk_Contacts_RecordTypeId Foreign Key (RecordTypeId) References RecordTypes(RecordTypeId),
CONSTRAINT Fk_Contacts_NumberOfEmployeesId Foreign Key (NumberOfEmployeesId) References NumberOfEmployees(NumberOfEmployeeId),
CONSTRAINT Fk_Contacts_SectorId Foreign Key (SectorId) References Sectors(SectorId),
CONSTRAINT Fk_Contacts_SingUpId Foreign Key (SingUpId) References SingUp(SingUpId),
CONSTRAINT Fk_Contacts_GenderId Foreign Key (GenderId) References Genders(GenderId)
)
Go

/** genel ayarlar tablosu**/
if not exists (Select * From INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME='GeneralSettings')
Create Table GeneralSettings
(
GeneralSettingId int identity Primary Key,
ContactLogo nvarchar(max),
ContactId int,
CONSTRAINT Fk_GeneralSettings_ContactId Foreign Key (ContactId) References Contacts(ContactId)
)
Go
/** para birimi tablosu*/
if not exists (Select * From INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME='Currencies')
Create Table Currencies
(
CurrencyId int identity Primary Key,
Name nvarchar(50)
)
Go
/** ürünler tablosu**/
if not exists (Select * From INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME='Products')
Create Table Products
(
ProductId int identity Primary Key ,
ProductName nvarchar(max),
ProductPrice nvarchar(max),
StockQuantity nvarchar(max),
[Description] ntext,
BrandId int,
CategoryId int,
CurrencyId int,
StatusId int,
CONSTRAINT Fk_Products_StatusId Foreign Key (StatusId) References Situations(StatusId),
CONSTRAINT Fk_Products_BrandId Foreign Key (BrandId) References Brands(BrandId),
CONSTRAINT Fk_Products_CategoryId Foreign Key (CategoryId) References Categories(CategoryId),
CONSTRAINT Fk_Products_CurrencyId Foreign Key (CurrencyId) References Currencies(CurrencyId)
)
Go

/** satýþ tablosu**/
if not exists (Select * From INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME='Sales')
Create Table Sales
(
SalesId int identity Primary Key ,
SalesName nvarchar(max),
SalesDate nvarchar(max),
SalesType nvarchar(max),
[Description] ntext,
Price money,
ContactId int,
SingUpId int,
CurrencyId int,
CONSTRAINT Fk_Sales_ContactId Foreign Key (ContactId) References Contacts(ContactId),
CONSTRAINT Fk_Sales_SingUpId Foreign Key (SingUpId) References SingUp(SingUpId),
CONSTRAINT Fk_Sales_CurrencyId Foreign Key (CurrencyId) References Currencies(CurrencyId)
)
Go
/** personeller tablosu**/
if not exists (Select * From INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME='Employees')
Create Table Employees
(
EmployeeId int identity,
NameSurname nvarchar(100),
Telephone nvarchar(30),
Email nvarchar(30),
[Address] ntext,
DateOfBirth nvarchar(30),
Position nvarchar(30),
DepartmentId int,
DateOfEmployment nvarchar(30),
Salary money,
UserName nvarchar(max),
[Password] nvarchar(30),
GenderId int,
WorkingStatusId int,
StatusId int,
CurrencyId int,
CONSTRAINT Pk_Employees_EmployeeId Primary Key (EmployeeId),
CONSTRAINT Fk_Employees_DepartmentId Foreign Key (DepartmentId) References Departments(DepartmanId),/*Departman tablosundan veri çekilecek*/
CONSTRAINT Fk_Employees_GenderId Foreign Key (GenderId) References Genders(GenderId),
CONSTRAINT Fk_Employees_WorkingStatusId Foreign Key (WorkingStatusId) References WorkingSituations(WorkingStatusId),
CONSTRAINT Fk_Employees_StatusId Foreign Key (StatusId) References Situations(StatusId),
CONSTRAINT Fk_Employees_CurrencyId Foreign Key (CurrencyId) References Currencies(CurrencyId)

)
Go
/** teklif tablosu**/
if not exists (Select * From INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME='Deals')
Create Table Deals
(
DealId int identity Primary Key,
DealName nvarchar(max),
StartDate nvarchar(max),
FinishDate nvarchar(max),
Price nvarchar(max),
[Description] ntext,
ContactId int,
EmployeeId int,
CurrencyId int,
DealStatusId int,
CONSTRAINT Fk_Deals_CurrencyId Foreign Key (CurrencyId) References Currencies(CurrencyId),
CONSTRAINT Fk_Deals_ContactId Foreign Key (ContactId) References Contacts(ContactId),
CONSTRAINT Fk_Deals_EmployeeId Foreign Key (EmployeeId) References Employees(EmployeeId),
CONSTRAINT Fk_Deals_DealStatusId Foreign Key (DealStatusId) References DealStatus(DealStatusId)
)
Go
/** ajanda tipi tablosu**/
if not exists (Select * From INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME='AgendaTypes')
Create Table AgendaTypes
(
  AgendaTypeId int identity Primary Key ,
  Name Nvarchar(max)
)
Go
/** ajanda durum tablosu**/
if not exists (Select * From INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME='AgendaStatus')
Create Table AgendaStatus
(
  AgendaStatusId int identity Primary Key , 
  Name Nvarchar(max)

)
Go
/** önem derece tablosu**/
if not exists (Select * From INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME='ImportanceLevels')
Create Table ImportanceLevels
(
  ImportanceId int identity Primary Key,
  Name Nvarchar(50)
)
Go
/** ajandalar tablosu**/
if not exists (Select * From INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME='Agendas')
Create Table Agendas
(
  AgendaId int identity Primary Key,
  Descriptionn nvarchar(max),
  AgendaTypeId int,
  AgendaStatusId int,
  ImportanceId int,
  StartDate nvarchar(max),
  StartTime nvarchar(max),
  FinishDate nvarchar(max),
  FinisTime nvarchar(max),
  SingUpId int,
  ContactId int,
  ResultId int,
CONSTRAINT Fk_Agendas_AgendaTypeId Foreign Key (AgendaTypeId) References AgendaTypes(AgendaTypeId),
CONSTRAINT Fk_Agendas_AgendaStatusId Foreign Key (AgendaStatusId) References AgendaStatus(AgendaStatusId),
CONSTRAINT Fk_Agendas_ImportanceId Foreign Key (ImportanceId) References ImportanceLevels(ImportanceId),
CONSTRAINT Fk_Agendas_SingUpId Foreign Key (SingUpId) References SingUp(SingUpId),
CONSTRAINT Fk_Agendas_ContactId Foreign Key (ContactId) References Contacts(ContactId),
CONSTRAINT Fk_Agendas_ResultId Foreign Key (ResultId) References Results(ResultId)

)
Go
/** görevler tablosu**/
if not exists (Select * From INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME='Tasks')
Create Table Tasks
(
   TaskId int identity Primary Key ,
   Descriptioon nvarchar(200),
   AgendaTypeId int,
   AgendaStatusId int,
   ImportanceId int,
   StartDate nvarchar(50),
   StartTime nvarchar(30),
   FinishDate nvarchar(50),
   FinisTime nvarchar(30),
   SingUpId int,
   ContactId int,
   ResultId int,
CONSTRAINT Fk_Tasks_AgendaTypeId Foreign Key (AgendaTypeId) References AgendaTypes(AgendaTypeId),
CONSTRAINT Fk_Tasks_AgendaStatusId Foreign Key (AgendaStatusId) References AgendaStatus(AgendaStatusId),
CONSTRAINT Fk_Tasks_ImportanceLevels Foreign Key (ImportanceId) References ImportanceLevels(ImportanceId),
CONSTRAINT Fk_Tasks_SingUpId Foreign Key (SingUpId) References SingUp(SingUpId),
CONSTRAINT Fk_Tasks_ContactId Foreign Key (ContactId) References Contacts(ContactId),
CONSTRAINT Fk_Tasks_ResultId Foreign Key (ResultId) References Results(ResultId)
)
Go

