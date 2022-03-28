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
        bat 'dir'
        dir(path: 'C:\\Users\\Admino\\AppData\\Local\\Jenkins\\.jenkins\\workspace\\HomeRun_ShellScriptBranch\\EK7TKN_HFT_2021221') {
          dotnetBuild()
          bat 'dotnet test'
          dotnetTest()
        }

        bat 'dotnet test'
      }
    }

  }
}