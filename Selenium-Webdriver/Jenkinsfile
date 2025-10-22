pipeline {
    agent any

    environment {
        ALLURE_RESULTS_DIR = "allure-results"
    }

    stages {

        stage('Restore Dependencies') {
            steps {
                echo "Restoring NuGet dependencies..."
                // Navigate to the folder containing your .csproj
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
                bat "cd Selenium-Webdriver && dotnet test --configuration Release /p:AllureResultsDirectory=${ALLURE_RESULTS_DIR}"
            }
        }

        stage('Publish Allure Report') {
            steps {
                echo "Publishing Allure report..."
                allure([
                    includeProperties: false,
                    jdk: '',
                    results: [[path: "${ALLURE_RESULTS_DIR}"]]
                ])
            }
        }
    }

    post {
        always {
            echo "Archiving test reports..."
            junit '**/TestResult.trx'
        }
        success {
            echo "Build and tests completed successfully!"
        }
        failure {
            echo "Build failed or tests have errors."
        }
    }
}
