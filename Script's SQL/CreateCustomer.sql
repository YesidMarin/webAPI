USE weky;

CREATE TABLE IF NOT EXISTS Customer (
	CustomerId CHAR(36) primary key,
    CustomerCityId CHAR(36) not null,
    CustomerName varchar(25) not null,
    CustomerLastName varchar(25) not null,
    CustomerIdNumber int(12) unique not null,
    CustomerTelephone int(10),
    CustomerAddress varchar(30),
    CustomerEmail varchar(30),
    
    FOREIGN KEY (CustomerCityId) REFERENCES Cities (CityId)
);

INSERT INTO Customer (CustomerId, CustomerCityId, CustomerName, CustomerLastName, CustomerIdNumber, CustomerTelephone,
 CustomerAddress, CustomerEmail) VALUES ("eccadf79-85fe-402f-893c-32d3f03ed9b1","24fd81f8-d58a-4bcc-9f35-dc6cd5641906",
 "William", "Castro", 105204598, 311258678, "Av 7", "williamcastro@email.com");
 
SELECT * FROM Customer; 


