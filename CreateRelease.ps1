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
$patchDefault = $appVersion[2].substring(0, $appVersion[2].Indexof("-"));

Function Version{
    param(
        [Parameter(Mandatory=$true)] [ValidateRange(0,9)] [Int]$Major,
        [Parameter(Mandatory=$true)] [ValidateRange(0,9)] [Int]$Minor,
        [Parameter(Mandatory=$true)] [ValidateRange(0,20)] [Int]$Patch
    )
    [int]$PatchInc  = ($Patch + 3) -as [int];
    if($PatchInc -gt 20){
        $PatchInc = 0;
        $Minor = $Minor + 1;
    }

    $Version = "v$Major.$Minor.$PatchInc"
    Write-Output "$Version"

    $yesNo = Read-Host -prompt "Are you sure to release YouTuber ${Version}? [Y/N]"
    if ($yesNo -eq 'y')
    {
        do 
        {
            Write-output "Cleaning unused tags" 
            git fetch -p -P origin
            Write-Output ${Version}
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

# $v = [version]'1.1.1.0'
# [version]::New($v.Major,$v.Minor,$v.Build+3,$v.Revision)