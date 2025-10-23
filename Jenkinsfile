pipeline {
    agent any

    environment {
        DOTNET_ROOT = "C:\\Program Files\\dotnet"
    }

    stages {
        stage('Checkout SCM') {
            steps {
                echo 'Checking out source code...'
                checkout scm
            }
        }

        stage('Restore Dependencies') {
            steps {
                echo 'Restoring NuGet packages...'
                bat "${env.DOTNET_ROOT}\\dotnet restore Selenium-Webdriver\\Selenium-Webdriver.csproj"
            }
        }

        stage('Build') {
            steps {
                echo 'Building project...'
                bat "${env.DOTNET_ROOT}\\dotnet build Selenium-Webdriver\\Selenium-Webdriver.csproj --configuration Release"
            }
        }

        stage('Run Tests') {
            steps {
                echo 'Running NUnit tests...'
                bat "${env.DOTNET_ROOT}\\dotnet test Selenium-Webdriver\\Selenium-Webdriver.csproj --configuration Release --logger \"trx;LogFileName=TestResults\\result.trx\""
            }
        }

        stage('Publish Test Results') {
            steps {
                echo 'Publishing test results...'
                // Publish NUnit test results (even if previous steps failed)
                junit 'Selenium-Webdriver\\TestResults\\*.trx'
            }
        }
    }

    post {
        always {
            echo 'Cleaning workspace...'
            script {
                try {
                    cleanWs(disableDeferredWipeout: true)
                } catch (err) {
                    echo "Workspace cleanup failed, ignoring: ${err}"
                }
            }
        }

        success {
            echo 'Pipeline completed successfully!'
        }

        failure {
            echo 'Pipeline failed!'
        }
    }
}
