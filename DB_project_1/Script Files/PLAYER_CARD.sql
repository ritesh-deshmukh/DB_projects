CREATE TABLE PLAYER_CARD (
Player_id int NOT NULL,
Yellow_Cards int DEFAULT 0,
Red_Cards int DEFAULT 0,
PRIMARY KEY (Player_id),
FOREIGN KEY (Player_id) REFERENCES PLAYERS(Player_id) ON DELETE CASCADE ON UPDATE CASCADE);