pipeline {
    agent any

    environment {
        ALLURE_RESULTS_DIR = "allure-results"
    }

    stages {

        stage('Checkout') {
            steps {
                echo "Checking out source code..."
                checkout scm
            }
        }

        stage('Restore Dependencies') {
            steps {
                echo "Restoring NuGet dependencies..."
                bat 'cd Selenium-Webdriver && dotnet restore'
                bat 'cd Selenium-Webdriver && dotnet add package NUnit --version 3.13.4'
                bat 'cd Selenium-Webdriver && dotnet add package NUnit3TestAdapter --version 4.4.2'
                bat 'cd Selenium-Webdriver && dotnet add package Microsoft.NET.Test.Sdk --version 18.4.0'
                bat 'cd Selenium-Webdriver && dotnet add package NUnit.Allure'
                bat 'cd Selenium-Webdriver && dotnet add package Allure.Commons'
            }
        }

        stage('Build') {
            steps {
                echo "Building project..."
                bat 'cd Selenium-Webdriver && dotnet build --configuration Release'
            }
        }

        stage('Run Tests') {
            steps {
                echo "Running tests..."
                bat """
                    cd Selenium-Webdriver && 
                    dotnet test --configuration Release /p:AllureResultsDirectory=%ALLURE_RESULTS_DIR% --logger "nunit;LogFilePath=TestResults\\result.xml"
                """
            }
        }

        stage('Publish Allure Report') {
            steps {
                echo "Publishing Allure report..."
                allure includeProperties: false, jdk: '', results: [[path: "${ALLURE_RESULTS_DIR}"]]
            }
        }
    }

    post {
        always {
            echo "Archiving test results..."
            junit 'Selenium-Webdriver/TestResults/*.xml'
        }
        success {
            echo "Build and tests succeeded!"
        }
        failure {
            echo "Build or tests failed."
        }
    }
}
