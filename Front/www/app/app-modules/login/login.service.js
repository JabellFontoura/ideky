angular
    .module('app.core')
    .factory('LoginService', function($http) {
        const url = 'http://localhost:60550/api/auth';

        return {
            login: login
        }

        function login() {
            $http.get(`${url}/ExternalLogin?provider=Facebook`);
        }
    });