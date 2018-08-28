(function () {
    'use strict';

    var app = angular.module('app', [
        'ngAnimate',
        'ngSanitize',

        'ui.router',
        'ui.bootstrap',
        'ui.jq',

        'abp'
    ]);

    //Configuration for Angular UI routing.
    app.config([
        '$stateProvider', '$urlRouterProvider', '$locationProvider', '$qProvider',
        function ($stateProvider, $urlRouterProvider, $locationProvider, $qProvider) {
            $locationProvider.hashPrefix('');
            $urlRouterProvider.otherwise('/');
            $qProvider.errorOnUnhandledRejections(false);

            if (abp.auth.hasPermission('Pages.Users')) {
                $stateProvider
                    .state('users', {
                        url: '/users',
                        templateUrl: '/App/Main/views/users/index.cshtml',
                        menu: 'Users' //Matches to name of 'Users' menu in PolyStoneNavigationProvider
                    });
                $urlRouterProvider.otherwise('/users');
            }

            if (abp.auth.hasPermission('Pages.Roles')) {
                $stateProvider
                    .state('roles', {
                        url: '/roles',
                        templateUrl: '/App/Main/views/roles/index.cshtml',
                        menu: 'Roles' //Matches to name of 'Tenants' menu in PolyStoneNavigationProvider
                    });
                $urlRouterProvider.otherwise('/roles');
            }

            if (abp.auth.hasPermission('Pages.Tenants')) {
                $stateProvider
                    .state('tenants', {
                        url: '/tenants',
                        templateUrl: '/App/Main/views/tenants/index.cshtml',
                        menu: 'Tenants' //Matches to name of 'Tenants' menu in PolyStoneNavigationProvider
                    });
                $urlRouterProvider.otherwise('/tenants');
            }

            if (abp.auth.hasPermission('Pages.Category')) {
                $stateProvider
                    .state('category', {
                        url: '/category',
                        templateUrl: '/App/Main/views/category/index.cshtml',
                        menu: 'Category' //Matches to name of 'Category' menu in PolyStoneNavigationProvider
                    });
                $urlRouterProvider.otherwise('/category');
            }

            if (abp.auth.hasPermission('Pages.CommunityCategory')) {
                $stateProvider
                    .state('communityCategory', {
                        url: '/communityCategory',
                        templateUrl: '/App/Main/views/communityCategory/index.cshtml',
                        menu: 'CommunityCategory' //Matches to name of 'CommunityCategory' menu in PolyStoneNavigationProvider
                    });
                $urlRouterProvider.otherwise('/communityCategory');
            }

            $stateProvider
                .state('home', {
                    url: '/',
                    templateUrl: '/App/Main/views/home/home.cshtml',
                    menu: 'Home' //Matches to name of 'Home' menu in PolyStoneNavigationProvider
                })
                .state('about', {
                    url: '/about',
                    templateUrl: '/App/Main/views/about/about.cshtml',
                    menu: 'About' //Matches to name of 'About' menu in PolyStoneNavigationProvider
                });
        }
    ]);

})();