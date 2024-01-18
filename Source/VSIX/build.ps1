Set-Location .\RelativityWizard
nuget restore packages.config -SolutionDir .
Set-Location ..\AllRelativityTemplates
dotnet build --configuration "Debug" AllRelativityTemplates.sln
