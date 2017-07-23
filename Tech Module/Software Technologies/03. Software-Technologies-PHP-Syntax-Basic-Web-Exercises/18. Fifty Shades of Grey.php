<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>First Steps Into PHP</title>
    <style>
        div {
            display: inline-block;
            margin: 5px;
            width: 20px;
            height: 20px;
        }
    </style> 
</head>
<body>
<?php
$red=0;
$green=0;
$blue=0;
for ($row=1;$row<=5;$row++) {
    for ($col=1;$col<=10;$col++){
        echo "<div style='background-color: rgb($red,$green,$blue)'></div>";
        $red+=5;
        $green+=5;
        $blue+=5;
    }
    $red+=1;
    $green+=1;
    $blue+=1;
    echo "<br/>";
}
    ?>
</body>
</html>