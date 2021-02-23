Write-Host "Build and Push to Heroku"

git add --all

$mess = Read-Host 'Input Commit Message'

git commit -m $mess

git push origin main

heroku container:login

docker build -t mhcapstone .

heroku container:push -a mhcapstone web

heroku container:release -a mhcapstone web

Write-Host "SUCCESSFULLY PUSHED TO HEROKU & GITHUB!"


<#  & C:\Users\Mikael\Documents\GitHub\CS-460\mhcapstone\mhcapstone\Run.ps1 #>