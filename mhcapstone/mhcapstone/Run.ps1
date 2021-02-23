Write-Host "Build and Push to Heroku"

git add --all


$mess = Read-Host 'Input Commit Message'

git commit -m $mess

git push origin m

heroku container:login

docker build -t mhcapstone .

heroku container:push -a mhcapstone web

heroku container:release -a mhcapstone web

Write-Host "SUCCESSFULLY PUSHED TO HEROKU & GITHUB!"
