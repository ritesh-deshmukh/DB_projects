CREATE TABLE PLAYER_ASSISTS_GOALS (
Player_id int NOT NULL,
No_of_Matches int,
Goals int DEFAULT 0,
Assists int DEFAULT 0,
Minutes_Played int,
PRIMARY KEY (Player_id),
FOREIGN KEY (Player_id) REFERENCES PLAYERS(Player_id) ON DELETE CASCADE ON UPDATE CASCADE);
