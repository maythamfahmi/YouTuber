$appVersion = (git describe --match "v*" main).replace("v", "").split(".")
$majorDefault = $appVersion[0]
$minorDefault = $appVersion[1]
$patchDefault = $appVersion[2]

function Func1{
	param (	
        [Parameter(Mandatory = $false)][Alias('major')][AllowNull()]
        ${major[1]},
        [Parameter(Mandatory = $false)][Alias('minor')][AllowNull()]
        ${minor[2]},
		[Parameter(Mandatory = $false)][Alias('patch')][AllowNull()]
        ${patch[3]}
    )
    $major = 
        if (${major[1]}) {
            ${major[1]}
        } else {
            $majorDefault
        }
    $minor = 
        if (${minor[2]}) {
            ${minor[2]}
        } else {
            $minorDefault
        }
	$patch = 
        if (${patch[3]}) {
            ${patch[3]}
        } else {
            $patchDefault
        }
    [PSCustomObject]@{
        major = $major
        minor = $minor
		patch = $patch
    }
}

write-host $majorDefault
write-host $minorDefault
write-host $patchDefault

Func1



write-host $major

# $MajorFromObj = "Please input Major version"
# $majorInput = { (Read-Host $MajorFromObj) -as [int] }
# $FromInput = & $majorInput

# $FromInput = 
# if (${Parameter1[default value]}) {
	# ${Parameter1[default value]}
# } else {
	# $FromInput
# }

# # $major = { (Read-Host $Major) -as [string] }
# # $minor = { (Read-Host $Minor) -as [int] }
# # $patch = { (Read-Host $Patch) -as [int] }

# write-host $FromInput
# write-host $Major
# write-host $Minor
# write-host $Patch

## https://stackoverflow.com/questions/39878202/powershell-mandatory-parameter-with-default-value-shown


# $param1=$args[0]

# git fetch -p -P origin
# git tag v$param1 -a -m "Release $param1"