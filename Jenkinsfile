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
        bat 'git clone https://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@github.com/TheNatan27/EK7TKN_HFT_20212.git'
        git(url: 'https://github.com/TheNatan27/EK7TKN_HFT_2021221/', branch: 'WPF', credentialsId: 'TheNatan27')
      }
    }

    stage('Bulid') {
      steps {
        bat 'dotnet test'
      }
    }

  }
}