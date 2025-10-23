pipeline {
    agent any

    environment {
        // If dotnet is in PATH, you can skip this. Otherwise, set full path with quotes.
        DOTNET_CMD = "dotnet"
        // If you want to use DOTNET_HOME, wrap it with quotes:
        // DOTNET_CMD = "\"C:\\Program Files\\dotnet\\dotnet.exe\""
    }

    stages {

        stage('Checkout') {
            steps {
                echo "Checking out source code..."
                git url: 'https://github.com/emailtovijay-tech/Selenium-Webdriver.git', branch: 'master'
            }
        }

        stage('Restore Dependencies') {
            steps {
                echo "Restoring NuGet packages..."
                bat "${DOTNET_CMD} restore Selenium-Webdriver\\Selenium-Webdriver.csproj"
            }
        }

        stage('Build') {
            steps {
                echo "Building project..."
                bat "${DOTNET_CMD} build Selenium-Webdriver\\Selenium-Webdriver.csproj --configuration Release"
            }
        }

        stage('Run Tests') {
            steps {
                echo "Running NUnit tests..."
                bat "${DOTNET_CMD} test Selenium-Webdriver\\Selenium-Webdriver.csproj --configuration Release --logger \"trx;LogFileName=TestResults\\result.trx\""
            }
        }

        stage('Publish Test Results') {
            steps {
                echo "Publishing test results to Jenkins..."
                junit 'Selenium-Webdriver\\TestResults\\result.trx'
            }
        }
    }

     post {
        always {
            echo 'Cleaning workspace...'
            script {
                try {
                    cleanWs()
                } catch (err) {
                    echo "Workspace cleanup failed, but ignoring: ${err}"
                }
            }
        }

        success {
            echo "Build and tests completed successfully!"
        }

        failure {
            echo "Build failed!"
        }
    }
}
