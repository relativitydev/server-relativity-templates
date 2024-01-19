$root = Get-Location
nuget restore .\RelativityWizard\packages.config -SolutionDir .
Set-Location $root
# No VSIX
#dotnet build --configuration "Debug" AllRelativityTemplates.sln
# No VSIX
#dotnet msbuild AllRelativityTemplates.sln -t:Rebuild -p:Configuration=Debug
#"C:\Program Files\Microsoft Visual Studio\2022\Professional\MSBuild\Current\Bin\MSBuild.exe" AllRelativityTemplates.sln -t:Rebuild -p:Configuration=Debug
