<?php
$servername = "localhost";
$username = "ismaeltc1";
$password = "jcLrEAyNbK";
$database = "ismaeltc1";
// Create connection
$conn = new mysqli($servername, $username, $password, $database);

// Check connection
if ($conn->connect_error) {
  die("Connection failed: " . $conn->connect_error);
}
echo "Connected successfully";

$sql = "INSERT INTO `Users` (`IdUser`, `Name`, `Country`, `Date`) VALUES ('265254215', 'testUser12', 'Suiza', '2022-5-29')";
$result = $conn->query($sql);

//$sql = "SELECT IdUser, Name, Country, Date FROM Users";

// if ($result->num_rows > 0) {
//   // output data of each row
//   while($row = $result->fetch_assoc()) {
//     echo "IdUser: " . $row["IdUser"]. " - Name: " . $row["Name"]. "Country: " . $row["Country"]. "Date: " . $row["Date"]. "<br>";
//   }
// } else {
//   echo "0 results";
// }
$conn->close();
?>