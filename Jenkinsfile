pipeline {
  agent any
  stages {
    stage('Main') {
      steps {
        echo 'Main ini'
      }
    }

    stage('"Building"') {
      steps {
        echo 'Build is building'
      }
    }

    stage('Unit tests') {
      steps {
        sh '''cd 
'''
        sh 'ls'
        sh 'pwd'
        pwsh 'param( [string] $sourceDirectory = $env:WORKSPACE , $fileFilters = @("*.UnitTests.dll", "*_UnitTests.dll", "*UnitTests.dll") , [string]$filterText = "*\\bin\\Debug*" )  #script that executes all unit tests available. $nUnitLog = Join-Path $sourceDirectory "UnitTestResults.txt" $nUnitErrorLog = Join-Path $sourceDirectory "UnitTestErrors.txt"  Write-Host "Source: $sourceDirectory" Write-Host "NUnit Results: $nUnitLog" Write-Host "NUnit Error Log: $nUnitErrorLog" Write-Host "File Filters: $fileFilters" Write-Host "Filter Text: $filterText"  $cFiles = "" $nUnitExecutable = "C:\\Program Files (x86)\\NUnit 2.6.3\\bin\\nunit-console-x86.exe"  # look through all subdirectories of the source folder and get any unit test assemblies. To avoid duplicates, only use the assemblies in the Debug folder [array]$files = get-childitem $sourceDirectory -include $fileFilters -recurse | select -expand FullName | where {$_ -like $filterText}  foreach ($file in $files) {     $cFiles = $cFiles + $file + " " }  # set all arguments and execute the unit console $argumentList = @("$cFiles", "/framework:net-4.5", "/xml=UnitTestResults.xml")  $unitTestProcess = start-process -filepath $nUnitExecutable -argumentlist $argumentList -wait -nonewwindow -passthru -RedirectStandardOutput $nUnitLog -RedirectStandardError $nUnitErrorLog  if ($unitTestProcess.ExitCode -ne 0) {     "Unit Test Process Exit Code: " + $unitTestProcess.ExitCode     "See $nUnitLog for more information or $nUnitErrorLog for any possible errors."     "Errors from NUnit Log File ($nUnitLog):"     Get-Content $nUnitLog | Write-Host }  $exitCode = $unitTestProcess.ExitCode  exit $exitCode'
      }
    }

  }
}