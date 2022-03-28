pipeline {
  agent any
  stages {
    stage('Main') {
      steps {
        echo 'Main ini'
      }
    }

    stage('Build') {
      steps {
        powershell 'dir'
      }
    }

    stage('Test') {
      steps {
        dotnetTest()
      }
    }

  }
}