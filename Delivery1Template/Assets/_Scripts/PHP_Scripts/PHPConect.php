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
?>