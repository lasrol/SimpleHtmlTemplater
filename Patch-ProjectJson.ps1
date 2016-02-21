Param([string]$Version)

$scriptDir = Split-Path -Path $MyInvocation.MyCommand.Definition -Parent
Get-ChildItem -Path "$scriptDir\src\" | where {$_.PSIsContainer} | foreach {
    $path = $_.FullName+"\project.json"
    $json = Get-Content -Raw -Path $path | ConvertFrom-Json
    $json.version = $Version
    $json | ConvertTo-Json -depth 999 | Out-File $path  
}