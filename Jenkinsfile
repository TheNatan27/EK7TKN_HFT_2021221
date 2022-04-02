pipeline {
  agent any
  stages {
    stage('Git') {
      steps {
        bat 'git --version'
        bat 'git clone https://github.com/TheNatan27/EK7TKN_HFT_2021221.git'
      }
    }

    stage('Build and Test') {
      steps {
        bat 'dir'
        dir(path: 'C:\\Users\\Admino\\AppData\\Local\\Jenkins\\.jenkins\\workspace\\HomeRun_ShellScriptBranch\\EK7TKN_HFT_2021221') {
          dotnetBuild()
          warnError(message: 'unit tests faile') {
            bat(script: 'dotnet test ', returnStdout: true, returnStatus: true)
            bat 'dir'
          }

        }

      }
    }
    stage("Publish NUnit Test Report") {
        nunit testResultsPattern: 'TestResult.xml'
    }
  }
}
