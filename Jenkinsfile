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

    stage('Shell') {
      steps {
        sh '''cd 
'''
        sh 'ls'
        sh 'pwd'
      }
    }

    stage('Dotnet') {
      steps {
        dotnetBuild()
      }
    }

  }
}