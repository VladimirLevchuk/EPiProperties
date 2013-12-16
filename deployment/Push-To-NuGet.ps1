Param (
    $variables = @{},   
    $artifacts = @{},
    $scriptPath,
    $buildFolder,
    $srcFolder,
    $outFolder,
    $tempFolder,
    $projectName,
    $projectVersion,
    $projectBuildNumber
)

Write-Output "Starting deployment: $projectName $projectVersion"

# list all artifacts
foreach($artifact in $artifacts.values)
{
    Write-Output "Artifact: $($artifact.name)"
    Write-Output "Type: $($artifact.type)"
    Write-Output "Path: $($artifact.path)"
    Write-Output "Url: $($artifact.url)"
}

Write-Output "Defined variables:"

$securedValue = "*************"
# script custom variables
foreach($name in $variables.keys)
{
    $value = $variables[$name]
	$isSecured = $name.Contains("Secure") -or $name.ToLower().Contains("password")
	if ($isSecured) {
		$printedValue = $securedValue 
	} else {
		$printedValue = $value
	}
	
    Write-Output "$name=$printedValue"
}

$nuget = "$srcFolder\.nuget\NuGet.exe"
$apikey = $variables["apikeySecure"]
$path = "$tempFolder\EPiProperties\*.nupkg"
$parameters = " Push ""$path"" -ApiKey $apikey"

Write-Output "$nuget Push $path -ApiKey $securedValue"

Invoke-Expression "$nuget $parameters"
