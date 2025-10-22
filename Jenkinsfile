pipeline {
    agent any

    environment {
        ALLURE_RESULTS_DIR = "allure-results"
    }

    stages {
        stage('Checkout') {
            steps {
                checkout scm
            }
        }

        stage('Restore Dependencies') {
            steps {
                bat 'cd Selenium-Webdriver && dotnet restore'
                bat 'cd Selenium-Webdriver && dotnet add package NUnit --version 3.14.0'
                bat 'cd Selenium-Webdriver && dotnet add package NUnit3TestAdapter --version 4.4.2'
                bat 'cd Selenium-Webdriver && dotnet add package Microsoft.NET.Test.Sdk --version 18.0.0'
                bat 'cd Selenium-Webdriver && dotnet add package NUnit.Allure'
                bat 'cd Selenium-Webdriver && dotnet add package Allure.Commons'
            }
        }

        stage('Build') {
            steps {
                bat 'cd Selenium-Webdriver && dotnet build --configuration Release'
            }
        }

        stage('Run Tests') {
            steps {
                bat """
                cd Selenium-Webdriver && dotnet test --configuration Release \
                /p:AllureResultsDirectory=%ALLURE_RESULTS_DIR% \
                --logger "nunit;LogFilePath=TestResults\\result.xml"
                """
            }
        }

        stage('Publish Allure Report') {
            steps {
                allure includeProperties: false, jdk: '', results: [[path: "${ALLURE_RESULTS_DIR}"]]
            }
        }
    }

    post {
        always {
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
