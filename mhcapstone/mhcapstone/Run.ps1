Write-Host "Build and Push to Heroku"

$mess = Read-Host 'Input Commit Message'

git commit -m $mess

heroku container:login

docker build -t mhcapstone .

heroku container:push -a mhcapstone web

heroku container:release -a mhcapstone web

Write-Host "SUCCESSFULLY PUSHED TO HEROKU!"
