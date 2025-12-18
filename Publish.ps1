<#
.SYNOPSIS
    Publishes the Uk.Nhs.CyberAlerts.Api NuGet package to nuget.org.

.PARAMETER SkipTests
    Skips running unit tests before publishing.

.EXAMPLE
    .\Publish.ps1
    .\Publish.ps1 -SkipTests
#>

param(
    [switch]$SkipTests
)

$ErrorActionPreference = 'Stop'

$projectPath = "Uk.Nhs.CyberAlerts.Api\Uk.Nhs.CyberAlerts.Api.csproj"
$nugetKeyFile = "nuget-key.txt"

# Step 1: Check for git porcelain (clean working directory)
Write-Host "Checking for clean git working directory..." -ForegroundColor Cyan
$gitStatus = git status --porcelain
if ($gitStatus) {
    Write-Error "Git working directory is not clean. Please commit or stash your changes."
    exit 1
}
Write-Host "Git working directory is clean." -ForegroundColor Green

# Step 2: Determine the Nerdbank git version
Write-Host "Determining Nerdbank git version..." -ForegroundColor Cyan
$versionOutput = nbgv get-version -p $projectPath -f json | ConvertFrom-Json
if (-not $versionOutput) {
    Write-Error "Failed to get Nerdbank git version."
    exit 1
}
$version = $versionOutput.NuGetPackageVersion
Write-Host "Version: $version" -ForegroundColor Green

# Step 3: Check that nuget-key.txt exists, has content and is gitignored
Write-Host "Checking nuget-key.txt..." -ForegroundColor Cyan
if (-not (Test-Path $nugetKeyFile)) {
    Write-Error "nuget-key.txt does not exist."
    exit 1
}

$nugetKey = (Get-Content $nugetKeyFile -Raw).Trim()
if ([string]::IsNullOrWhiteSpace($nugetKey)) {
    Write-Error "nuget-key.txt is empty."
    exit 1
}

$gitIgnoreCheck = git check-ignore $nugetKeyFile
if (-not $gitIgnoreCheck) {
    Write-Error "nuget-key.txt is not gitignored. Add it to .gitignore for security."
    exit 1
}
Write-Host "nuget-key.txt is valid and gitignored." -ForegroundColor Green

# Step 4: Run unit tests (unless -SkipTests is specified)
if (-not $SkipTests) {
    Write-Host "Running unit tests..." -ForegroundColor Cyan
    dotnet test --configuration Release --no-restore
    if ($LASTEXITCODE -ne 0) {
        Write-Error "Unit tests failed."
        exit 1
    }
    Write-Host "Unit tests passed." -ForegroundColor Green
}
else {
    Write-Host "Skipping unit tests." -ForegroundColor Yellow
}

# Step 5: Build and pack
Write-Host "Building and packing..." -ForegroundColor Cyan
dotnet build $projectPath --configuration Release
if ($LASTEXITCODE -ne 0) {
    Write-Error "Build failed."
    exit 1
}

# Step 6: Publish to nuget.org
Write-Host "Publishing to nuget.org..." -ForegroundColor Cyan
$nupkgPath = "Uk.Nhs.CyberAlerts.Api\bin\Release\Uk.Nhs.CyberAlerts.Api.$version.nupkg"
if (-not (Test-Path $nupkgPath)) {
    Write-Error "NuGet package not found at: $nupkgPath"
    exit 1
}

dotnet nuget push $nupkgPath --api-key $nugetKey --source https://api.nuget.org/v3/index.json --skip-duplicate
if ($LASTEXITCODE -ne 0) {
    Write-Error "Failed to publish to nuget.org."
    exit 1
}

Write-Host "Successfully published Uk.Nhs.CyberAlerts.Api v$version to nuget.org" -ForegroundColor Green
exit 0
