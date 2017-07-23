<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>First Steps Into PHP</title>

</head>
<body>
    <form>
        N: <input type="text" name="num1" />
        M: <input type="text" name="num2" />
        <input type="submit" />
    </form>
	<ul>
        <?php
        if (!isset($_GET['num1']) && !isset($_GET['num2'])) {
            exit(1);
        }
        $num1=intval($_GET['num1']);
        $num2=intval($_GET['num2']);

        echo"<ul>\n";
        for ($i=1;$i<=$num1;$i++) {
            echo "<li>List $i\n<ul>";
            for ($j=1;$j<=$num2;$j++) {
               echo "<li>Element $i.$j</li>\n";
            }
            echo"</ul>\n</li>";
        }
        ?>
	</ul>
</body>
</html>