<?php

$servername = "localhost";
$username = "root";
$password = "ZX__as258963";
$dbname = "mulit";

// Create connection
$conn = new mysqli($servername, $username, $password, $dbname);
// Check connection
if ($conn->connect_error) {
  die("Connection failed: " . $conn->connect_error);
}

$action = $_POST["action"];
$arrow_x = $_POST["ax"];
$arrow_y = $_POST["ay"];
$stdnum = $_POST["nums"];

if($action == "control"){
   if($stdnum!="" && $arrow_x!="" && $arrow_y!=""){
        $sql2 = "UPDATE usaction SET `action_x` = '".$arrow_x."', `action_y` = '".$arrow_y."' WHERE std_num='".$stdnum."'";

        if ($conn->query($sql2) === TRUE) {
        echo "Sucess";
        } else {
        echo "Error updating record: " . $conn->error;
        }
   }else if($stdnum=="" && $arrow_x!="" && $arrow_y!=""){
    echo "Insert stdnum";
   }else if($arrow_x=="" || $arrow_y=="" && $stdnum!=""){
    echo "Insert Arrow";
   }else{
    echo "Can't Null";
   }
    
}else if($action == "getcon"){
    $action = '';
    if($stdnum!=""){
        $sql = "SELECT action_x, action_y FROM usaction WHERE std_num='".$stdnum."'";
        $result = $conn->query($sql);
        
        if ($result->num_rows > 0) {
        // output data of each row
        $row = $result->fetch_assoc();
        echo $row["action_x"].','.$row["action_y"];
        
        } else {
        echo "This User Has No Action";
        }
    }else{
        echo "Insert stdnum";
    }
    
}else{
    echo "Can't Find Action!";
}
$conn->close();


?>