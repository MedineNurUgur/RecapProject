
CREATE TABLE Users(
	UserID int PRIMARY KEY IDENTITY(1,1),
	FirstName text,
	LastName text,
	Email text,
	UserPassword text,
)
CREATE TABLE Customers(
	CustomerID int PRIMARY KEY IDENTITY(1,1),
	UserId int,
	CompanyName text,
	FOREIGN KEY (UserID) REFERENCES Users(UserID)
)
CREATE TABLE Rentals(
	RentalID int PRIMARY KEY IDENTITY(1,1),
	CustomerId int,
	RentDate datetime,
	ReturnDate datetime,
	FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID)
)CREATE TABLE CarImages(
	CarImageID int PRIMARY KEY IDENTITY(1,1),
	CarId int,
	ImagePath text,
	UploadDate datetime,
	FOREIGN KEY (CarID) REFERENCES Cars(CarID)
)