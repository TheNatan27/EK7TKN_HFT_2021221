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
        bat 'dir /A'
        bat 'cd C:\\Users\\Admino\\AppData\\Local\\Jenkins\\.jenkins\\workspace\\'
        bat 'dir /S'
      }
    }

    stage('Bulid') {
      steps {
        bat 'dotnet test'
      }
    }

  }
}