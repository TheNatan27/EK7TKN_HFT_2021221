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
        bat 'git --version'
        git(url: 'https://github.com/SpecFlowOSS/SpecFlow-Examples.git', credentialsId: 'JenkiNatan')
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