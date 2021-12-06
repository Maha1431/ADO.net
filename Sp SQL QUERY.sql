use Addressbook_service;


create procedure spGetAllAddressBook
As 
Begin try
select * from Address_Book
end try
Begin catch
SELECT
    ERROR_NUMBER() AS ErrorNumber,
    ERROR_STATE() AS ErrorState,
    ERROR_PROCEDURE() AS ErrorProcedure,
    ERROR_LINE() AS ErrorLine,
    ERROR_MESSAGE() AS ErrorMessage;
END CATCH 

exec spGetAllAddressBook

Create procedure spAddInAddress_Book
(
@Firstname varchar(20),
@Lastname varchar(20),
@Address varchar(100),
@City varchar(50),
@State varchar(30),
@Zipcode int,
@PhoneNumber varchar(10),
@Email varchar(100)
)
As 
Begin try
insert into Address_Book (Firstname,Lastname,Address,City,State,Zipcode,PhoneNumber,Email)values
(@Firstname,@Lastname,@Address,@City,@State,@Zipcode,@PhoneNumber,@Email)
end try
Begin catch
SELECT
    ERROR_NUMBER() AS ErrorNumber,
    ERROR_STATE() AS ErrorState,
    ERROR_PROCEDURE() AS ErrorProcedure,
    ERROR_LINE() AS ErrorLine,
    ERROR_MESSAGE() AS ErrorMessage;
END CATCH  

exec spAddInAddress_Book
'cheenu','kumar','HSR layot ','Bangalore','Karnataka',09922,61651515,'cheenu@gmail.com'


create procedure spUpdateInAddressBook
(
@Firstname varchar(20),
@State varchar(20)
)
As 
Begin try
update Address_Book
set State=@State
where Firstname=@Firstname
end try
Begin catch
SELECT
    ERROR_NUMBER() AS ErrorNumber,
    ERROR_STATE() AS ErrorState,
    ERROR_PROCEDURE() AS ErrorProcedure,
    ERROR_LINE() AS ErrorLine,
    ERROR_MESSAGE() AS ErrorMessage;
END CATCH  

exec spUpdateInAddressBook
'malini','Karnataka'



Create procedure spDeleteInAddressBook
(
@Firstname varchar(20)
)
As 
Begin try
delete from Address_Book where Firstname=@Firstname 
end try
Begin catch
SELECT
    ERROR_NUMBER() AS ErrorNumber,
    ERROR_STATE() AS ErrorState,
    ERROR_PROCEDURE() AS ErrorProcedure,
    ERROR_LINE() AS ErrorLine,
    ERROR_MESSAGE() AS ErrorMessage;
END CATCH  

exec spDeleteInAddressBook
'teju'

CREATE PROCEDURE spPersonsCityorState 
@City varchar(50),
@State varchar(50)
AS
Begin try
SELECT FirstName,City,State FROM Address_Book WHERE City = @City or State=@State
end try
Begin catch
SELECT
    ERROR_NUMBER() AS ErrorNumber,
    ERROR_STATE() AS ErrorState,
    ERROR_PROCEDURE() AS ErrorProcedure,
    ERROR_LINE() AS ErrorLine,
    ERROR_MESSAGE() AS ErrorMessage;
END CATCH  

exec spPersonsCityorState
'pune','mumbai'


create procedure spRetrieveCountOfContactsByCity
(
@City varchar(20)
)
As
Begin try
select * from Address_Book where City=@City
end try
Begin catch
SELECT
    ERROR_NUMBER() AS ErrorNumber,
    ERROR_STATE() AS ErrorState,
    ERROR_PROCEDURE() AS ErrorProcedure,
    ERROR_LINE() AS ErrorLine,
    ERROR_MESSAGE() AS ErrorMessage;
END CATCH 

exec spRetrieveCountOfContactsByCity
'mumbai'