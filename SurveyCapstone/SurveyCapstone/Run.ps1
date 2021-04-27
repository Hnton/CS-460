Write-Host "Build and Push to Heroku"

git add --all

$mess = Read-Host 'Input Commit Message'

git commit -m $mess

git push origin main

heroku container:login

docker build -t surveycapstone .

heroku container:push -a surveycapstone web

heroku container:release -a surveycapstone web

Write-Host "SUCCESSFULLY PUSHED TO HEROKU & GITHUB!"


<#  & C:\Users\Mikael\Documents\GitHub\CS-460\SurveyCapstone\SurveyCapstone\Run.ps1 #>