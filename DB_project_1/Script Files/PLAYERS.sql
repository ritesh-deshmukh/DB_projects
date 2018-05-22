CREATE TABLE PLAYERS (
Player_id int NOT NULL,
Name varchar (40) NOT NULL,
Fname varchar (20) NOT NULL,
Lname varchar (35) NOT NULL,
DOB date NOT NULL,
Country varchar(20),
Height_cms int NOT NULL,
Club varchar(30),
Position varchar(10),
Caps_for_Country int DEFAULT 0,
IS_CAPTAIN Boolean NOT NULL,
PRIMARY KEY (Player_id),
FOREIGN KEY(Country) references COUNTRY(Country_Name) ON DELETE CASCADE ON UPDATE CASCADE);
