CREATE TABLE MATCH_RESULTS (
Match_id int NOT NULL,
Date_of_Match date,
Start_Time_Of_Match time,
Team1 varchar(25) NOT NULL,
Team2 varchar(25) NOT NULL,
Team1_score int DEFAULT 0,
Team2_score int DEFAULT 0,
Stadium_Name varchar(35) NOT NULL,
Host_City varchar(20) NOT NULL,
PRIMARY KEY (Match_id),
FOREIGN KEY (Team1) REFERENCES COUNTRY(Country_Name) ON UPDATE CASCADE,
FOREIGN KEY (Team2) REFERENCES COUNTRY(Country_Name) ON UPDATE CASCADE);






