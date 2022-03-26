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
ln -s /usr/local/share/dotnet/dotnet /usr/local/bin'''
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