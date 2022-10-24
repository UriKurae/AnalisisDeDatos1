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
//echo "This unity connected succesfully";

//$sql = "INSERT INTO `Users` (`IdUser`, `Name`, `Country`, `Date`) VALUES ('265254215', 'testUser12', 'Suiza', '2022-5-29')";

$sql = "SELECT StartSession, IdSession, IdUser FROM Sessions";
$result = $conn->query($sql);

if (isset($_REQUEST["StartSession"]) && isset($_REQUEST["IdUser"]))
{
  $startSession = $_POST["StartSession"];
  $idUser = $_POST["IdUser"];
  //echo "Received ". $_POST["Name"] . " Sucessfully received";

  $query = "INSERT INTO `Sessions` (`StartSession`, `IdUser`) VALUES ('$startSession', '$idUser')";
  $result = mysqli_query($conn,$query) or die('just  died');
  $last_inserted = mysqli_insert_id($conn);
  print($last_inserted);

  exit();
}
else if (isset($_REQUEST["EndSession"]) && isset($_REQUEST["IdSession"]))
{
  $endSession = $_POST["EndSession"];
  $idSession = $_POST["IdSession"];

  $query = "UPDATE `Sessions` SET EndSession = '$endSession' WHERE IdSession = $idSession";

  //$query = "UPDATE `Sessions` SET EndSession = $endSession WHERE IdSession = $idSession";
  $result = mysqli_query($conn,$query) or die('just  died2');
  //$last_inserted = mysqli_insert_id($conn);
  //print($last_inserted);

  exit();
}

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