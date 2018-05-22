import java.sql.*;
import java.io.*;
import com.mysql.jdbc.PreparedStatement;
import com.opencsv.CSVReader;
import java.lang.String;

public class JDBC_Connect {
	Connection conn;
	ResultSet rs;
	PreparedStatement stm;
	private CSVReader reader;

	public static void main( String args[] )
	{
		try {
			JDBC_Connect connect = new JDBC_Connect();
			if ( connect.connectDB() ) {		
				System.out.println("Connected successfully!");
				//Import Data from CSV's
				System.out.println("Importing data..");
				connect.importCountryData();
				connect.importPlayersData();
				connect.importMatchResultsData();
				connect.importPlayerAssistsGoalsData();
				connect.importPlayerCardData();
			}
			connect.disconnectDB();
		}
		catch (Exception exception) {
			System.out.println("\nSQLException" + exception.getMessage()+"\n");
		}
	} 

	public void importCountryData(){
		try {
			//Import Data for country
			conn.setAutoCommit(false);
			reader = new CSVReader(new FileReader(new File("inputdata/Country.csv").getAbsolutePath()), ',');
			String[] rowData = null;
			String query = "";
			while((rowData = reader.readNext()) != null)
			{
				query = "INSERT INTO `country` "
						+ "(`Country_Name`, `Population`, `No_of_Worldcup_won`, "
						+ "`Manager`) VALUES  ("
						+ "" + rowData[0] + "," 
						+ "" + rowData[1] + ","
						+ "" + rowData[2] + "," 
						+ "" + rowData[3] + ");\n";

				stm = (PreparedStatement) conn.prepareStatement(query,  Statement.RETURN_GENERATED_KEYS);
				stm.executeUpdate();
				stm.close();
			}
			conn.commit();
			System.out.println("Successfully imported data for country!");
		} catch (Exception e) {
			e.printStackTrace();
		}
	}

	public void importPlayersData(){
		try {
			//Import Data for country
			conn.setAutoCommit(false);
			reader = new CSVReader(new FileReader(new File("inputdata/Players.csv").getAbsolutePath()), ',');
			String[] rowData = null;
			String query = "";
			while((rowData = reader.readNext()) != null)
			{
				query = "INSERT INTO `players` "
						+ "(`Player_id`, `Name`, `Fname`, `Lname`, `DOB`, `Country`,"
						+ "`Height_cms`, `Club`, `Position`, `Caps_for_Country`, `IS_CAPTAIN`) VALUES  ("
						+ "" + rowData[0] + "," 
						+ "" + rowData[1] + ","
						+ "" + rowData[2] + "," 
						+ "" + rowData[3] + "," 
						+ "" + rowData[4] + ","
						+ "" + rowData[5] + "," 
						+ "" + rowData[6] + "," 
						+ "" + rowData[7] + ","
						+ "" + rowData[8] + "," 
						+ "" + rowData[9] + ","
						+ "" + rowData[10] + ");\n";

				stm = (PreparedStatement) conn.prepareStatement(query,  Statement.RETURN_GENERATED_KEYS);
				stm.executeUpdate();
				stm.close();
			}
			conn.commit();
			System.out.println("Successfully imported data for players!");
		} catch (Exception e) {
			e.printStackTrace();
		}
	}
	
	public void importMatchResultsData(){
		try {
			//Import Data for country
			conn.setAutoCommit(false);
			reader = new CSVReader(new FileReader(new File("inputdata/Match_results.csv").getAbsolutePath()), ',');
			String[] rowData = null;
			String query = "";
			while((rowData = reader.readNext()) != null)
			{
				query = "INSERT INTO `match_results` "
						+ "(`Match_id`, `Date_of_Match`, `Start_Time_Of_Match`, `Team1`, `Team2`, `Team1_score`,"
						+ "`Team2_score`, `Stadium_Name`, `Host_City`) VALUES  ("
						+ "" + rowData[0] + "," 
						+ "" + rowData[1] + ","
						+ "" + rowData[2] + "," 
						+ "" + rowData[3] + "," 
						+ "" + rowData[4] + ","
						+ "" + rowData[5] + "," 
						+ "" + rowData[6] + "," 
						+ "" + rowData[7] + ","
						+ "" + rowData[8] + ");\n";

				stm = (PreparedStatement) conn.prepareStatement(query,  Statement.RETURN_GENERATED_KEYS);
				stm.executeUpdate();
				stm.close();
			}
			conn.commit();
			System.out.println("Successfully imported data for match results!");
		} catch (Exception e) {
			e.printStackTrace();
		}
	}
	
	public void importPlayerAssistsGoalsData(){
		try {
			//Import Data for country
			conn.setAutoCommit(false);
			reader = new CSVReader(new FileReader(new File("inputdata/Player_Assists_Goals.csv").getAbsolutePath()), ',');
			String[] rowData = null;
			String query = "";
			while((rowData = reader.readNext()) != null)
			{
				query = "INSERT INTO `player_assists_goals` "
						+ "(`Player_id`, `No_of_Matches`, `Goals`, `Assists`, `Minutes_Played`) VALUES  ("
						+ "" + rowData[0] + "," 
						+ "" + rowData[1] + ","
						+ "" + rowData[2] + "," 
						+ "" + rowData[3] + "," 
						+ "" + rowData[4] + ");\n";

				stm = (PreparedStatement) conn.prepareStatement(query,  Statement.RETURN_GENERATED_KEYS);
				stm.executeUpdate();
				stm.close();
			}
			conn.commit();
			System.out.println("Successfully imported data for player assist goals!");
		} catch (Exception e) {
			e.printStackTrace();
		}
	}
	
	public void importPlayerCardData(){
		try {
			//Import Data for country
			conn.setAutoCommit(false);
			reader = new CSVReader(new FileReader(new File("inputdata/Player_Cards.csv").getAbsolutePath()), ',');
			String[] rowData = null;
			String query = "";
			while((rowData = reader.readNext()) != null)
			{
				query = "INSERT INTO `player_card` "
						+ "(`Player_id`, `Yellow_Cards`, `Red_Cards`) VALUES  ("
						+ "" + rowData[0] + "," 
						+ "" + rowData[1] + ","
						+ "" + rowData[2] + ");\n";

				stm = (PreparedStatement) conn.prepareStatement(query,  Statement.RETURN_GENERATED_KEYS);
				stm.executeUpdate();
				stm.close();
			}
			conn.commit();
			System.out.println("Successfully imported data for player cards!");
		} catch (Exception e) {
			e.printStackTrace();
		}
	}
	
	public boolean connectDB() 
	{
		String driver = "com.mysql.jdbc.Driver";
		try
		{
			Class.forName(driver);

		} 
		catch(ClassNotFoundException e)
		{
			System.err.print("Failed to Load driver.");
			return false;
		}
		try
		{
			conn = DriverManager.getConnection("jdbc:mysql://localhost:3306/soccer?" +
					"user=root&password=root123");
		}
		catch(SQLException e)
		{
			System.err.print("Failed to connect.");
			return false;
		}
		return true;
	}

	public void disconnectDB() 
	{
		try 
		{
			conn.close();
		} catch (SQLException e) 
		{
			e.printStackTrace();
		}
	}
}
