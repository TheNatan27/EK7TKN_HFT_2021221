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
        sh '''cd /var/jenkins_home/workspace/KN_HFT_2021221_ShellScriptBranch/EK7TKN_HFT_2021221.Test
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