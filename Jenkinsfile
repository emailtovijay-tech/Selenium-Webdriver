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
        bat "cd Selenium-Webdriver && dotnet test --configuration Release --logger \"trx;LogFileName=TestResult.xml\" /p:AllureResultsDirectory=allure-results"
    }
}

stage('Publish Allure Report') {
    steps {
        echo "Publishing Allure report..."
        // ensure allure-results folder exists
        bat "if not exist allure-results mkdir allure-results"
        allure([
            includeProperties: false,
            jdk: '',
            results: [[path: "Selenium-Webdriver/allure-results"]]
        ])
    }
}

post {
    always {
        echo "Archiving test reports..."
        junit '**/Selenium-Webdriver/TestResult.xml'
    }
}
}

}