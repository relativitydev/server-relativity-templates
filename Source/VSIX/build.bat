%comspec% /k "C:\Program Files\Microsoft Visual Studio\2022\Professional\Common7\Tools\VsDevCmd.bat"
nuget restore RelativityWizard\packages.config -SolutionDir .
REM Calling MSBuild directly does not work.
REM msbuild.exe AllRelativityTemplates.sln -t:Rebuild -p:Configuration=Debug
REM https://github.com/dotnet/msbuild/issues/2653
dotnet msbuild -t:Rebuild -p:Configuration=Debug AllRelativityTemplates.sln
