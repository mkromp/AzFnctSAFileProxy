$rg = 'rg-azfnct-dev'

az group create --location westeurope --name $rg
az deployment group create --resource-group $rg --template-file ../bicep/main.bicep