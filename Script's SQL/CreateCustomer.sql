USE weky;

CREATE TABLE IF NOT EXISTS Customer (
	primaryId CHAR(36) primary key,
    cityId CHAR(36) not null,
    customerName varchar(25) not null,
    lastName varchar(25) not null,
    numberId varchar(12),
    telephone varchar(12),
    address varchar(30),
    email varchar(30),
    
    FOREIGN KEY (cityId) REFERENCES Cities (CityId)
);

INSERT INTO Customer (primaryId, cityId, customerName, lastName, numberId, telephone,
 address, email) VALUES ("eccadf79-85fe-402f-893c-32d3f03ed9b1","24fd81f8-d58a-4bcc-9f35-dc6cd5641906",
 "William", "Castro", 105204598, 311258678, "Av 7", "williamcastro@email.com");
 
DROP TABLE Customer;
 
SELECT * FROM Customer; 
DELETE  FROM Customer;

