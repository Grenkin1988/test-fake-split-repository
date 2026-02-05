$stamp = Get-Date -Format "yyyyMMdd-HHmmss"
$ver = "1.0.0-local.$stamp"

@"
<Project>
  <PropertyGroup>
    <SharedPackageVersion>$ver</SharedPackageVersion>
  </PropertyGroup>
</Project>
"@ | Out-File -Encoding utf8 -NoNewline "local.version.props"

# Remove old Common.* packages from local feed
Remove-Item -Force -ErrorAction SilentlyContinue .\local_nuget\*.nupkg
Remove-Item -Force -ErrorAction SilentlyContinue .\local_nuget\*.snupkg

# Pack new
dotnet pack Common/Common.slnx -c Release -o ./local_nuget /p:SharedPackageVersion=$ver
Write-Host "Packed Common with SharedPackageVersion=$ver"
