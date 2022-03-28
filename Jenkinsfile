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
        bat '@echo off  forfiles /s /m *.* /c "cmd /c echo @relpath"'
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