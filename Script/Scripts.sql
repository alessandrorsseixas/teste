Create Database supermercadoteste

use supermercadoteste

Create table product(
Id int not null identity,
Code uniqueidentifier not null,
Name varchar(100) not null, 
Value decimal(18,2) not null, 
[Image] varchar(255) not null, 
CreatedDate Datetime not null,
Createduser varchar(11) not null,
UpdatedDate Datetime ,
Updateduser varchar(11),
primary key(Id)
)