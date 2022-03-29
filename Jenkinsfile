pipeline {
  agent any
  stages {
    stage('Main') {
      steps {
        echo 'Main ini'
      }
    }

    stage('Git') {
      steps {
        bat 'git --version'
        bat 'git clone https://github.com/TheNatan27/EK7TKN_HFT_2021221.git'
        echo 'Git Cloned'
      }
    }

    stage('Build and Test') {
      steps {
        dir(path: 'C:\\Users\\Admino\\AppData\\Local\\Jenkins\\.jenkins\\workspace\\HomeRun_ShellScriptBranch\\EK7TKN_HFT_2021221') {
          dotnetBuild()
          warnError(message: 'unit tests fail') {
            bat 'dotnet test'
            nunit()
          }

        }

      }
    }

  }
}