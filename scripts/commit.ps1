Param(
    [Parameter(Mandatory=$false, Position=0)]
    [string]$Message
)

if (-not (git rev-parse --git-dir 2>$null)) {
    Write-Error "Not a git repository. Run this from a repo root or initialize git first."
    exit 1
}

Write-Host "Staging all changes..."
git add -A

if ([string]::IsNullOrEmpty($Message)) {
    Write-Host "No commit message provided. Launching default editor for commit message..."
    git commit
} else {
    Write-Host "Committing with message: $Message"
    git commit -m $Message
}
