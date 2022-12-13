$subId = ''
$rg = ''

az ad sp create-for-rbac --name "GitHubAction" --role contributor --scopes "/subscriptions/$subId/resourceGroups/$rg"