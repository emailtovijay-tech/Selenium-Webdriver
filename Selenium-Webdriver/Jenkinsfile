pipeline {
agent any

```
tools {
    dotnet 'dotnet6'
}

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
            bat 'dotnet restore'
            bat 'dotnet add package NUnit.Allure'
            bat 'dotnet add package Allure.Commons'
        }
    }

    stage('Build') {
        steps {
            echo "Building the project..."
            bat 'dotnet build --configuration Release'
        }
    }

    stage('Run Tests') {
        steps {
            echo "Running Selenium tests with Allure results..."
            // Runs tests and produces Allure JSON results
            bat "dotnet test --configuration Release /p:CollectCoverage=false /p:AllureResultsDirectory=$(ALLURE_RESULTS_DIR)"
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
```

}
