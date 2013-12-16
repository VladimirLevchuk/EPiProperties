﻿Param (
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

# script custom variables
foreach($name in $variables.keys)
{
    $value = $variables[$name]
	$printedValue = ($name.Contains("Secure") || $name.ToLower.Contains("password")) ? "*************" : $value
    Write-Output "$name=$printedValue"
}

$nuget = "$srcFolder\.nuget\NuGet.exe"
$apikey = $variables["apikeySecure"]
$path = "$tempFolder\EPiProperties\*.nupkg"
$parameters = " Push ""$path"" -ApiKey $apikey"

Write-Output "$nuget Push $path -ApiKey *************"

Invoke-Expression "$nuget $parameters"
