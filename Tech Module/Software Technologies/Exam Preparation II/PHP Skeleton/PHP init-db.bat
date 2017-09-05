@echo off

echo Initializing database...

echo php composer.phar install

php bin/console doctrine:database:create --if-not-exists
echo php bin/console doctrine:schema:update --force

echo Successfully initialized database!

:finish
