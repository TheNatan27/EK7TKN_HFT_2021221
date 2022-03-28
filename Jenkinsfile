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
        powershell 'dir'
        fileExists 'EK7TKN_HFT_2021221.sln'
        bat 'dir'
        bat 'cd '
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