pipeline {
  agent any
  stages {
    stage('Main') {
      steps {
        echo 'Main ini'
      }
    }

    stage('Shell') {
      steps {
        bat 'dir'
      }
    }

    stage('Build') {
      steps {
        dotnetBuild()
      }
    }

    stage('Test') {
      steps {
        dotnetTest()
      }
    }

  }
}