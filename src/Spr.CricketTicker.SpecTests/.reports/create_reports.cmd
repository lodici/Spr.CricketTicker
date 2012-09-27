@echo off
cls

REM if NOT [%1]==[SILENT] (
REM 	echo 
REM 	echo Ensure you are running this script from within
REM 	echo "<Specflow project folder>\.reports".
REM 	echo 
REM 	echo {CTRL-Pause/Break}, then {ENTER} to cancel batch job if not.
REM 	pause 
REM 	cls
REM )

set ProjectName=Spr.CricketTicker.SpecTests
set ProjectPath=..\%ProjectName%.vbproj
set SpecFlowExe=..\..\packages\SpecFlow.1.9.0\tools\specflow.exe

REM BinDirectoryPath should be full path. 
REM Step Definition Report /binFolder parameter does not work with relative path.
set BinDirectoryPath=D:\_DATA\Visual Studio 2010\Projects\Spr.CricketTicker\bin\Debug

REM Test Execution Report
nunit-console.exe /labels /out=TestResult.txt /xml=TestResult.xml "%BinDirectoryPath%\%ProjectName%.dll"
%SpecFlowExe% nunitexecutionreport "%ProjectPath%" /xmlTestResult:TestResult.xml /testOutput:TestResult.txt /out:"TestExecReport(%ProjectName%).html"
del TestResult.*

REM Step Definition Report
%SpecFlowExe% stepdefinitionreport "%ProjectPath%" /binFolder:"%BinDirectoryPath%" /out:"StepDefReport(%ProjectName%).html"

explorer .