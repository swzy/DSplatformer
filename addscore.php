<?php 

$link = mysqli_connect('localhost', 'root', '', 'dsplatformer_scores');
if (!$link) {
    echo "Error: Unable to connect to MySQL." . PHP_EOL;
    echo "Debugging errno: " . mysqli_connect_errno() . PHP_EOL;
    echo "Debugging error: " . mysqli_connect_error() . PHP_EOL;
    exit;
}

$playername = $_POST["name"];
$playerscore = $_POST["score"];

$sql = "INSERT INTO scores (name, score)
VALUES ('$playername', '$playerscore');";

if ($link->query($sql) === TRUE) {
    echo "New record created successfully";
} else {
    echo "Error: " . $sql . "<br>" . $conn->error;
}

echo("0");

mysqli_close($link);
?>
