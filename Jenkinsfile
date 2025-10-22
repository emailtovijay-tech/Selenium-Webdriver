pipeline {
    agent any

    environment {
        ALLURE_RESULTS_DIR = "allure-results"
    }

    stages {

        stage('Checkout') {
            steps {
                echo "Checking out the source code..."
                checkout scm
            }
        }

        stage('Restore Dependencies') {
            steps {
                echo "Restoring NuGet dependencies..."
                bat 'cd Selenium-Webdriver && dotnet restore'
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
                bat "cd Selenium-Webdriver && dotnet test --configuration Release /p:AllureResultsDirectory=%ALLURE_RESULTS_DIR%"
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
            junit '**/TestResults/*.xml'
        }
        success {
            echo "Build and tests succeeded!"
        }
        failure {
            echo "Build or tests failed."
        }
    }
}
