use AdvanceAddressBook;

Select * from AddressBookDetails

Alter Procedure AddContactDetails(
@firstName varchar(20),
@lastName varchar(20),
@address varchar(30),
@city varchar(20),
@state varchar(20),
@zip bigint,
@phonenumber bigint , 
@email varchar(30),
@ContactTime Datetime
)
As
begin 
insert Into AddressBookDetails values(@firstName,@lastName,@address,@city,@state,@zip,@phonenumber,@email,@ContactTime)
Update AddressBookDetails set  contactTime=GetDate() where firstname=@firstname
End

Create Procedure GetAllDetails
As
Begin 
Select * from AddressBookDetails
End

Create Procedure EditContactDetails(
@firstName varchar(20),
@lastName varchar(20),
@address varchar(30),
@city varchar(20),
@state varchar(20),
@zip bigint,
@phonenumber varchar(10), 
@email varchar(30) 
)
As
begin
update AddressBookDetails set firstName=@firstName,lastName=@lastName,address=@address,city=@city,state=@state,zip=@zip,phonenumber=@phonenumber,email=@email,ContactTime=GetDate() where firstName=@firstName
End

Alter procedure GetRecords(
@contactTime datetime
)
As
begin
Select * from AddressBookDetails where ContactTime between CAST(@ContactTime as Date) and GETDATE();
End

Create Procedure CountinCity
As
Begin 
Select city, count(*)as count from AddressBookDetails group by city
End


Create Procedure CountinState
As
Begin 
Select state, count(*)as count from AddressBookDetails group by state
End