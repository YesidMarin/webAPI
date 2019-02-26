USE weky;

CREATE TABLE IF NOT EXISTS Cities (
	CityId int auto_increment primary key,
    CityName varchar(25) not null
);

INSERT INTO Cities (CityName) VALUES ("Bogotá");
INSERT INTO Cities (CityName) VALUES ("Barranquilla");
INSERT INTO Cities (CityName) VALUES ("Cartagena");
INSERT INTO Cities (CityName) VALUES ("Santa Marta");
INSERT INTO Cities (CityName) VALUES ("Amazonas");


SELECT * FROM Cities;