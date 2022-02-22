param(
     [Parameter()][AllowNull()]
     [string]$Major,
     [Parameter()][AllowNull()]
     [string]$Minor,
     [Parameter()][AllowNull()]
     [string]$Patch
 )

$appVersion = (git describe --match "v*" main).replace("v", "").split(".")
$majorDefault = $appVersion[0]
$minorDefault = $appVersion[1]
$patchDefault = $appVersion[2]

Function Version{
    param(
        [Parameter(Mandatory=$true)] [ValidateRange(0,9)] [Int]$Major,
        [Parameter(Mandatory=$true)] [ValidateRange(0,9)] [Int]$Minor,
        [Parameter(Mandatory=$true)] [ValidateRange(0,9)] [Int]$Patch
    )
    $PatchInc = $Patch + 1;
    $Version = "v$Major.$Minor.$PatchInc"
    Write-Output "$Version"

    $yesNo = Read-Host -prompt "Are you sure to release YouTuber ${Version}? [Y/N]"
    if ($yesNo -eq 'y')
    {
        do 
        {
            Write-output "Cleaning unused tags" 
            git fetch -p -P origin
            Write-output "Create tag Release" 
            git tag ${Version} -a -m "Release ${Version}"
            Write-output "Push Release" 
            git push --tags
            Write-output "$value" 
        }
        while($strQuit -eq 'y')
    }

}

$majorVal = If([string]::IsNullOrEmpty($Major)) {$majorDefault} else {$Major}
$minorVal = If([string]::IsNullOrEmpty($Minor)) {$minorDefault} else {$Minor}
$patchVal = If([string]::IsNullOrEmpty($Patch)) {$patchDefault} else {$Patch}
Version -Major $majorVal -Minor $minorVal -Patch $patchVal