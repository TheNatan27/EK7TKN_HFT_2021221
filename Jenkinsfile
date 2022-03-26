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
        sh 'dotnet test'
        sh 'apt-get install dotnet-sdk-2.0.0'
      }
    }

  }
}