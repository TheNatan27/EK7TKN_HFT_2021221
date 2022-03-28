pipeline {
  agent any
  stages {
    stage('Main') {
      steps {
        echo 'Main ini'
      }
    }

    stage('Dir') {
      steps {
        fileExists 'EK7TKN_HFT_2021221.sln'
        bat 'dir'
        bat 'cd "%WORKSPACE%"'
        bat 'dir'
      }
    }

    stage('Bulid') {
      steps {
        bat 'dotnet test'
      }
    }

  }
}