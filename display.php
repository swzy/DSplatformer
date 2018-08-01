<?php
    // Send variables for the MySQL database class.
    $link = mysqli_connect('localhost', 'root', '', 'dsplatformer_scores');

if (!$link) {
    echo "Error: Unable to connect to MySQL." . PHP_EOL;
    echo "Debugging errno: " . mysqli_connect_errno() . PHP_EOL;
    echo "Debugging error: " . mysqli_connect_error() . PHP_EOL;
    exit;
}

    $query = "SELECT * FROM `scores` ORDER by `score` DESC LIMIT 15";
    $result = mysqli_query($link, $query) or die('Query failed: ' . mysql_error());
 
    $num_results = mysqli_num_rows($result);  
 
    for($i = 0; $i < $num_results; $i++)
    {
         $row = mysqli_fetch_array($result);
         echo $row['id'] . "\t" . $row['name'] . "\t" . $row['score'] . "\n";
    }
?>
