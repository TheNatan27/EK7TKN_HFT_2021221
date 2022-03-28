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
        bat 'git credential-manager-core erase'
        bat 'git credential-manager-core install'
        bat 'dir /S'
        bat 'git --version'
        bat 'git config --global user.name \'TheNatan28\''
        bat 'git config --global user.email \'angolmernokinfo@gmail.com\''
        bat 'git clone https://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@github.com/TheNatan27/EK7TKN_HFT_20212.git'
      }
    }

    stage('Git') {
      steps {
        bat 'git --version'
      }
    }

    stage('Build') {
      steps {
        bat 'dotnet build'
      }
    }

  }
}