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
      }
    }

    stage('Build') {
      steps {
        bat 'dotnet test'
      }
    }

  }
}