INSERT INTO `security`.`privileges` (`P_Name`, `P_Type`) VALUES ('ALTER SESSION', 'Account');
INSERT INTO `security`.`privileges` (`P_Name`, `P_Type`) VALUES ('CREATE CLUSTER', 'Account');
INSERT INTO `security`.`privileges` (`P_Name`, `P_Type`) VALUES ('CREATE DATABASE', 'Account');
INSERT INTO `security`.`privileges` (`P_Name`, `P_Type`) VALUES ('CREATE SESSION', 'Account');
INSERT INTO `security`.`privileges` (`P_Name`, `P_Type`) VALUES ('CREATE TABLE', 'Account');
INSERT INTO `security`.`privileges` (`P_Name`, `P_Type`) VALUES ('INSERT', 'Relation');
INSERT INTO `security`.`privileges` (`P_Name`, `P_Type`) VALUES ('UPDATE', 'Relation');
INSERT INTO `security`.`privileges` (`P_Name`, `P_Type`) VALUES ('DELETE', 'Relation');
INSERT INTO `security`.`privileges` (`P_Name`, `P_Type`) VALUES ('DROP DATABASE', 'Account');
INSERT INTO `security`.`privileges` (`P_Name`, `P_Type`) VALUES ('MODIFY TABLE', 'Relation');
INSERT INTO `security`.`privileges` (`P_Name`, `P_Type`) VALUES ('SELECT', 'Relation');


INSERT INTO `security`.`user_roles` (`Role_Name`, `Description`) VALUES ('DBA', 'All System privileges with Admin Option');
INSERT INTO `security`.`user_roles` (`Role_Name`, `Description`) VALUES ('Manager', 'This role is to be used by Enterprise Manager');
INSERT INTO `security`.`user_roles` (`Role_Name`, `Description`) VALUES ('Clerk', 'Displayed required data using views');

INSERT INTO `security`.`user_accounts` (`Name`, `Phone`, `Role_Name`) VALUES ('J.Smith', '6825564563', 'DBA');
INSERT INTO `security`.`user_accounts` (`Name`, `Phone`, `Role_Name`) VALUES ('R.Wong', '8972733434', 'Manager');
INSERT INTO `security`.`user_accounts` (`Name`, `Phone`, `Role_Name`) VALUES ('A.Dhotre', '7685336753', 'Manager');
INSERT INTO `security`.`user_accounts` (`Name`, `Phone`, `Role_Name`) VALUES ('R.Deshmukh', '6097465473', 'Clerk');
INSERT INTO `security`.`user_accounts` (`Name`, `Phone`, `Role_Name`) VALUES ('J.Robb', '7465452738', 'Clerk');
INSERT INTO `security`.`user_accounts` (`Name`, `Phone`, `Role_Name`) VALUES ('D.Kung', '9837354711', 'Clerk');
INSERT INTO `security`.`user_accounts` (`Name`, `Phone`, `Role_Name`) VALUES ('J.Rao', '5463788864', 'Clerk');
INSERT INTO `security`.`user_accounts` (`Name`, `Phone`, `Role_Name`) VALUES ('J.Zhang', '6825564000', 'Clerk');
INSERT INTO `security`.`user_accounts` (`Name`, `Phone`, `Role_Name`) VALUES ('G.Das', '6567099937', 'Clerk');
INSERT INTO `security`.`user_accounts` (`Name`, `Phone`, `Role_Name`) VALUES ('N.Stark', '3456783456', 'Clerk');

INSERT INTO `security`.`tables` (`Table_Name`, `Owner_Id`) VALUES ('TABLE1', '3');
INSERT INTO `security`.`tables` (`Table_Name`, `Owner_Id`) VALUES ('TABLE2', '4');
INSERT INTO `security`.`tables` (`Table_Name`, `Owner_Id`) VALUES ('TABLE3', '4');
INSERT INTO `security`.`tables` (`Table_Name`, `Owner_Id`) VALUES ('TABLE4', '4');
INSERT INTO `security`.`tables` (`Table_Name`, `Owner_Id`) VALUES ('TABLE5', '3');
INSERT INTO `security`.`tables` (`Table_Name`, `Owner_Id`) VALUES ('TABLE6', '3');
INSERT INTO `security`.`tables` (`Table_Name`, `Owner_Id`) VALUES ('TABLE7', '1');
INSERT INTO `security`.`tables` (`Table_Name`, `Owner_Id`) VALUES ('TABLE8', '1');
INSERT INTO `security`.`tables` (`Table_Name`, `Owner_Id`) VALUES ('TABLE9', '3');
INSERT INTO `security`.`tables` (`Table_Name`, `Owner_Id`) VALUES ('TABLE10', '2');


INSERT INTO `security`.`table_permissions` (`P_Name`, `Role_Name`, `Table_Name`) VALUES ('SELECT', 'Clerk', 'TABLE7');
INSERT INTO `security`.`table_permissions` (`P_Name`, `Role_Name`, `Table_Name`) VALUES ('MODIFY TABLE', 'DBA', 'TABLE10');
INSERT INTO `security`.`table_permissions` (`P_Name`, `Role_Name`, `Table_Name`) VALUES ('DELETE', 'Manager', 'TABLE1');
INSERT INTO `security`.`table_permissions` (`P_Name`, `Role_Name`, `Table_Name`) VALUES ('SELECT', 'Clerk', 'TABLE9');


INSERT INTO `security`.`account_permissions` (`P_Name`, `Role_Name`) VALUES ('CREATE DATABASE', 'DBA');
INSERT INTO `security`.`account_permissions` (`P_Name`, `Role_Name`) VALUES ('CREATE TABLE', 'Manager');
INSERT INTO `security`.`account_permissions` (`P_Name`, `Role_Name`) VALUES ('DROP DATABASE', 'DBA');
INSERT INTO `security`.`account_permissions` (`P_Name`, `Role_Name`) VALUES ('CREATE CLUSTER', 'DBA');

