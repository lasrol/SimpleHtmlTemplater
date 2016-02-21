Param([string]$Version)

$scriptDir = Split-Path -Path $MyInvocation.MyCommand.Definition -Parent
$filePath = $scriptDir+"\Project.json"
$json = Get-Content -Raw -Path $filePath | ConvertFrom-Json
$json.version = $Version
$json | ConvertTo-Json -depth 999 | Out-File $filePath
