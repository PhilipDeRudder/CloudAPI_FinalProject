pipeline {
//where to execute
   agent any
//where the 'work' happends
   stages {
      stage('build') {
         steps {
            echo 'Building application...'
         }
      stage('test') {
         steps {
            echo 'testing application...'
         }
         
       stage('dep') {
         steps {
            echo 'deploy application...'
         }
      }
   }
}
