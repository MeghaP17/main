#!/bin/bash

apiappname=TestCoreWebAPI$(openssl rand -hex 5)

printf "Setting username and password for Git ... (1/7)\n\n"


GIT_USERNAME=MeghaP17
GIT_EMAIL=megha.patel@centrica.com

git config --global user.name "$GIT_USERNAME"
git config --global user.email "$GIT_EMAIL"


RESOURCE_GROUP="azsu-rg-devtest-emt-integration-001"

# Create App Service plan
PLAN_NAME="ASP-azsurgdevtestemtintegration001-afa4 (S1: 1)"


printf "\nCreating App Service plan in FREE tier ... (2/7)\n\n"


az appservice plan create --name $apiappname --resource-group $RESOURCE_GROUP --sku FREE --verbose

printf "\nCreating API App ... (3/7)\n\n"

az webapp create --name $apiappname --resource-group $RESOURCE_GROUP --plan $apiappname --deployment-local-git --verbose


printf "\nSetting the account-level deployment credentials ...(4/7)\n\n"


DEPLOY_USER="MeghaP17"
DEPLOY_PASSWORD="Megh@p@tel17c"

az webapp deployment user set --user-name $DEPLOY_USER --password $DEPLOY_PASSWORD --verbose


GIT_URL="https://$DEPLOY_USER@$apiappname.scm.azurewebsites.net/$apiappname.git"

# Create Web App with local-git deploy

REMOTE_NAME=development


# Set remote on src
printf "\nSetting Git remote...(5/7)\n\n"


git remote add $REMOTE_NAME $GIT_URL


printf "\nGit add...(6/7)\n\n"

git add .
git commit -m "initial revision"


printf "\nGit push... (7/7)\n\n"


# printf "When prompted for a password enter this: $DEPLOY_PASSWORD\n"
# git push --set-upstream $REMOTE_NAME master
git push "https://$DEPLOY_USER:$DEPLOY_PASSWORD@$apiappname.scm.azurewebsites.net/$apiappname.git"


printf "Setup complete!\n\n"

printf "***********************    IMPORTANT INFO  *********************\n\n"

printf "%s %s %s\n\n" "Password for " "$GIT_URL:" "$DEPLOY_PASSWORD"

printf "Example URL: https://$apiappname.azurewebsites.net/weatherforecast\n\n"

printf "Swagger URL: https://$apiappname.azurewebsites.net/swagger\n"

