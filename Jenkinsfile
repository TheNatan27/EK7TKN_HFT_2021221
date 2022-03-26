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
        sh 'pwd'
        sh '''
export PATH=/usr/local/share/dotnet:$PATH'''
        sh '''cd /var/jenkins_home/workspace/KN_HFT_2021221_ShellScriptBranch/EK7TKN_HFT_2021221.Test

ls
'''
      }
    }

    stage('Dotnet?') {
      steps {
        sh 'dotnet test'
      }
    }

  }
}