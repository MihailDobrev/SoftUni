@echo off

echo Initializing database...

php composer.phar install --no-scripts --no-progress -q

echo php bin/console doctrine:database:create --if-not-exists
echo php bin/console doctrine:schema:update --force

echo Successfully initialized database!

pause

:finish
