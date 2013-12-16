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

# list all artifacts
foreach($artifact in $artifacts.values)
{
    Write-Output "EPiProperties Artifact: $($artifact.name)"
    Write-Output "Type: $($artifact.type)"
    Write-Output "Path: $($artifact.path)"
    Write-Output "Url: $($artifact.url)"
}

Write-Output "EPiProperties\deployment"

# script custom variables
foreach($name in $variables.keys)
{
    $value = $variables[$name]
    Write-Output "$name=$value"
}