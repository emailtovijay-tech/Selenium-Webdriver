pipeline {
    agent any

    environment {
        DOTNET_ROOT = "C:\\Program Files\\dotnet"
        ALLURE_RESULTS = "Selenium-Webdriver\\allure-results"
    }

    stages {
        stage('Clean Workspace & Checkout') {
            steps {
                echo 'Cleaning workspace and checking out source code...'
                deleteDir()
                checkout scm
            }
        }

        stage('Restore Dependencies') {
            steps {
                echo 'Restoring NuGet packages...'
                bat "\"${env.DOTNET_ROOT}\\dotnet\" restore Selenium-Webdriver\\Selenium-Webdriver.csproj"
            }
        }

        stage('Build') {
            steps {
                echo 'Building project...'
                bat "\"${env.DOTNET_ROOT}\\dotnet\" build Selenium-Webdriver\\Selenium-Webdriver.csproj --configuration Release"
            }
        }

        stage('Run Tests') {
            steps {
                echo 'Running NUnit tests with Allure results...'
                // Create folder for Allure results
                bat "mkdir \"${env.ALLURE_RESULTS}\""
                // Run tests with TRX output
                bat "\"${env.DOTNET_ROOT}\\dotnet\" test Selenium-Webdriver\\Selenium-Webdriver.csproj --configuration Release --logger \"trx;LogFileName=TestResults\\result.trx\""
                // Convert TRX to Allure results
                // Requires: dotnet-allure package or adapter installed
                bat "\"${env.DOTNET_ROOT}\\dotnet\" tool run allure generate Selenium-Webdriver\\TestResults --clean -o ${env.ALLURE_RESULTS}"
            }
        }

        stage('Publish Test Results') {
            steps {
                echo 'Publishing test results and Allure report...'
                // Publish TRX results
                junit allowEmptyResults: true, testResults: 'Selenium-Webdriver\\TestResults\\*.trx'
                // Publish Allure report
                allure([
                    includeProperties: false,
                    jdk: '',
                    results: [[path: "${env.ALLURE_RESULTS}"]],
                    reportBuildPolicy: 'ALWAYS'
                ])
            }
        }
    }

    post {
        always {
            echo 'Cleaning workspace...'
            cleanWs(disableDeferredWipeout: true)
        }
        success { echo 'Pipeline completed successfully!' }
        failure { echo 'Pipeline failed!' }
    }
}
