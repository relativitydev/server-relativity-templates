%comspec% /k "C:\Program Files\Microsoft Visual Studio\2022\Professional\Common7\Tools\VsDevCmd.bat"
nuget restore RelativityWizard\packages.config -SolutionDir .
REM msbuild.exe AllRelativityTemplates.sln -t:Rebuild -p:Configuration=Debug
dotnet msbuild -t:Rebuild -p:Configuration=Debug AllRelativityTemplates.sln
