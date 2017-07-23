<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>First Steps Into PHP</title>

</head>
<body>
    <form>
        N: <input type="text" name="num" />
        <input type="submit" />
    </form>
    <?php
    if (isset($_GET['num'])) {
        $num=intval($_GET['num']);
        for( $j = 2; $j <= $num; $j++ )
        {
            for( $k = 2; $k < $j; $k++ )
            {
                if( $j % $k == 0 )
                {
                    break;
                }
            }
            if( $k == $j )
                $primeNumbers[]=$j;
        }
        $reversed=array_reverse($primeNumbers);
        echo implode(" ", $reversed);
    }
    ?>
</body>
</html>