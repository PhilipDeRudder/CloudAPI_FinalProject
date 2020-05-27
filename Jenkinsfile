pipeline {
//where to execute
   agent any
//where the 'work' happends
   stages {
      stage('install') {
         steps {
            echo 'install node modules...'
            sh "npm install"
         }
      stage('build') {
         steps {
            echo "npm run build --prod"
         }
         
       stage('dep') {
         steps {
            echo 'deploy application...'
         }
      }
   }
}
