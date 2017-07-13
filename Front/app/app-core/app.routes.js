angular
    .module('app.core')
    .config(function($routeProvider) {
        $routeProvider
            .when('/login', {
                controller: 'LoginController',
                templateUrl: 'app/app-modules/login/login.html'
            })
            .when('/home', {
                controller: 'HomeController',
                templateUrl: 'app/app-modules/home/home.html',
                resolve: { auth: authService => authService.isAuthenticatedFacebookPromise() }
            })
            .when('/game', {
                controller: 'GameController',
                templateUrl: 'app/app-modules/game/game.html',
                resolve: { auth: authService => authService.isAuthenticatedFacebookPromise() }
            })
            .when('/ranking', {
                controller: 'RankingController',
                templateUrl: 'app/app-modules/ranking/ranking.html',
                resolve: { auth: authService => authService.isAuthenticatedFacebookPromise() }
            })
            .when('/loginadm', {
                controller: 'LoginadmController',
                templateUrl: 'app/app-modules/administrative/loginadm/loginadm.html'
            })
            .when('/menuadm', {
                controller: 'MenuadmController',
                templateUrl: 'app/app-modules/administrative/menuadm/menuadm.html',
                resolve: { auth: authService => authService.isAuthenticatedFacebookPromise() }
            })
            .when('/lifesadm', {
                controller: 'LifesadmController',
                templateUrl: 'app/app-modules/administrative/lifesadm/lifesadm.html',
                resolve: { auth: authService => authService.isAuthenticatedFacebookPromise() }
            })
            .when('/levelsadm', {
                controller: 'LevelsadmController',
                templateUrl: 'app/app-modules/administrative/levelsadm/levelsadm.html',
                resolve: { auth: authService => authService.isAuthenticatedFacebookPromise() }
            })
            .otherwise({
                redirectTo: '/login'
            });
    });