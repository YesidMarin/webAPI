USE weky;

CREATE TABLE IF NOT EXISTS Cities (
	CityId CHAR(36) primary key,
    CityName varchar(25) not null
);

INSERT INTO Cities (CityId,CityName) VALUES ("24fd81f8-d58a-4bcc-9f35-dc6cd5641906", "Bogotá");
INSERT INTO Cities (CityId,CityName) VALUES ("261e1685-cf26-494c-b17c-3546e65f5620","Barranquilla");
INSERT INTO Cities (CityId,CityName) VALUES ("a3c1880c-674c-4d18-8f91-5d3608a2c937","Cartagena");
INSERT INTO Cities (CityId,CityName) VALUES ("f98e4d74-0f68-4aac-89fd-047f1aaca6b6","Santa Marta");
INSERT INTO Cities (CityId,CityName) VALUES ("356a5a9b-64bf-4de0-bc84-5395a1fdc9c4","Amazonas");


SELECT * FROM Cities;