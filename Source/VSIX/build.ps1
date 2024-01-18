$root = Get-Location
nuget restore .\RelativityWizard\packages.config -SolutionDir .
Set-Location $root
dotnet build --configuration "Debug" AllRelativityTemplates.sln
