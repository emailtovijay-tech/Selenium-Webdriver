pipeline {
    agent any

    environment {
        DOTNET_CLI_HOME = "${env.WORKSPACE}"  // Avoid dotnet temp issues on Windows
    }

    stages {

        stage('Checkout SCM') {
            steps {
                echo "Checking out source code..."
                checkout scm
            }
        }

        stage('Restore Dependencies') {
            steps {
                echo "Restoring NuGet packages..."
                bat '''
                cd Selenium-Webdriver
                dotnet restore
                dotnet add package NUnit --version 3.14.0
                dotnet add package NUnit3TestAdapter --version 4.4.2
                dotnet add package Microsoft.NET.Test.Sdk --version 18.0.0
                dotnet add package NUnit.Allure
                dotnet add package Allure.Commons
                '''
            }
        }

        stage('Build') {
            steps {
                echo "Building project..."
                bat '''
                cd Selenium-Webdriver
                dotnet build --configuration Release
                '''
            }
        }

        stage('Run Tests') {
    steps {
        echo "Running NUnit tests..."
        bat '''
        cd Selenium-Webdriver
        dotnet test --configuration Release --results-directory TestResults --logger "trx;LogFileName=TestResults\\result.trx"
        '''
    }
}

        stage('Publish Allure Report') {
            steps {
                echo "Publishing Allure report..."
                // Path to allure-results folder created by NUnit.Allure
                allure includeProperties: false, jdk: '', results: [[path: 'allure-results']]
            }
        }
    }

    post {
        always {
            echo "Archiving test results..."
            junit 'Selenium-Webdriver/TestResults/*.trx'
        }
    }
}
