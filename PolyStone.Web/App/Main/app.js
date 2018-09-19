(function () {
    'use strict';

    var app = angular.module('app', [
        'ngAnimate',
        'ngSanitize',

        'ui.router',
        'ui.bootstrap',
        'ui.jq',

        'abp'
        , 'angularFileUpload'
    ]);

    //Configuration for Angular UI routing.
    app.config([
        '$stateProvider', '$urlRouterProvider', '$locationProvider', '$qProvider',
        function ($stateProvider, $urlRouterProvider, $locationProvider, $qProvider) {
            $locationProvider.hashPrefix('');
            $urlRouterProvider.otherwise('/');
            $qProvider.errorOnUnhandledRejections(false);


            $stateProvider
                .state('test', {
                    url: '/test',
                    templateUrl: '/App/Main/views/test/test.cshtml'//,
                    //menu: 'Roles' //Matches to name of 'Tenants' menu in PolyStoneNavigationProvider
                });


            if (abp.auth.hasPermission('Pages.Users')) {
                $stateProvider
                    .state('users', {
                        url: '/users',
                        templateUrl: '/App/Main/views/users/index.cshtml'//,
                        //menu: 'Users' //Matches to name of 'Users' menu in PolyStoneNavigationProvider
                    });
                $urlRouterProvider.otherwise('/users');
            }

            if (abp.auth.hasPermission('Pages.Roles')) {
                $stateProvider
                    .state('roles', {
                        url: '/roles',
                        templateUrl: '/App/Main/views/roles/index.cshtml'//,
                        //menu: 'Roles' //Matches to name of 'Tenants' menu in PolyStoneNavigationProvider
                    });
                $urlRouterProvider.otherwise('/roles');
            }

            if (abp.auth.hasPermission('Pages.Tenants')) {
                $stateProvider
                    .state('tenants', {
                        url: '/tenants',
                        templateUrl: '/App/Main/views/tenants/index.cshtml'//,
                        //menu: 'Tenants' //Matches to name of 'Tenants' menu in PolyStoneNavigationProvider
                    });
                $urlRouterProvider.otherwise('/tenants');
            }

            if (abp.auth.hasPermission('Pages.Category')) {
                $stateProvider
                    .state('category', {
                        url: '/category',
                        templateUrl: '/App/Main/views/category/index.cshtml'//,
                        //menu: 'Category' //Matches to name of 'Category' menu in PolyStoneNavigationProvider
                    });
                $urlRouterProvider.otherwise('/category');
            }

            if (abp.auth.hasPermission('Pages.CommunityCategory')) {
                $stateProvider
                    .state('communityCategory', {
                        url: '/communityCategory',
                        templateUrl: '/App/Main/views/communityCategory/index.cshtml'//,
                        //menu: 'CommunityCategory' //Matches to name of 'CommunityCategory' menu in PolyStoneNavigationProvider
                    });
                $urlRouterProvider.otherwise('/communityCategory');
            }

            if (abp.auth.hasPermission('Pages.Community')) {
                $stateProvider
                    .state('community', {
                        url: '/community',
                        templateUrl: '/App/Main/views/community/index.cshtml'//,
                        //menu: 'CommunityCategory' //Matches to name of 'CommunityCategory' menu in PolyStoneNavigationProvider
                    });
                $urlRouterProvider.otherwise('/community');
            }

            if (abp.auth.hasPermission('Pages.Community.EditCommunity')) {
                $stateProvider
                    .state('communityEdit', {
                        url: '/community/edit/:id',
                        templateUrl: '/App/Main/views/community/edit.cshtml',
                        controller:'app.views.community.editCommunity'
                        //menu: 'CommunityCategory' //Matches to name of 'CommunityCategory' menu in PolyStoneNavigationProvider
                    });
                $urlRouterProvider.otherwise('/community');
            }

            if (abp.auth.hasPermission('Pages.Community.CreateCommunity')) {
                $stateProvider
                    .state('communityAdd', {
                        url: '/community/add',
                        templateUrl: '/App/Main/views/community/createCommunity.cshtml',
                        controller: 'app.views.community.createCommunity'
                        //menu: 'Products' //Matches to name of 'Products' menu in PolyStoneNavigationProvider
                    });
                $urlRouterProvider.otherwise('/community/add');
            }


            if (abp.auth.hasPermission('Pages.Company')) {
                $stateProvider
                    .state('company', {
                        url: '/company',
                        templateUrl: '/App/Main/views/company/index.cshtml'//,
                        //menu: 'CommunityCategory' //Matches to name of 'CommunityCategory' menu in PolyStoneNavigationProvider
                    });
                $urlRouterProvider.otherwise('/company');
            }

            if (abp.auth.hasPermission('Pages.Company.CreateCompany')) {
                $stateProvider
                    .state('companyAdd', {
                        url: '/company/add',
                        templateUrl: '/App/Main/views/company/createCompany.cshtml',
                        controller: 'app.views.company.createCompany'
                        //menu: 'Products' //Matches to name of 'Products' menu in PolyStoneNavigationProvider
                    });
                $urlRouterProvider.otherwise('/company');
            }

            if (abp.auth.hasPermission('Pages.Region')) {
                $stateProvider
                    .state('regions', {
                        url: '/regions',
                        templateUrl: '/App/Main/views/regions/index.cshtml'//,
                        //menu: 'Regions' //Matches to name of 'Regions' menu in PolyStoneNavigationProvider
                    });
                $urlRouterProvider.otherwise('/regions');
            }

            if (abp.auth.hasPermission('Pages.Product')) {
                $stateProvider
                    .state('products', {
                        url: '/products',
                        templateUrl: '/App/Main/views/products/index.cshtml',
                        controller: 'app.views.product.index'
                        //menu: 'Products' //Matches to name of 'Products' menu in PolyStoneNavigationProvider
                    });
                $urlRouterProvider.otherwise('/products');
            }

            if (abp.auth.hasPermission('Pages.Product.CreateProduct')) {
                $stateProvider
                    .state('productsAdd', {
                        url: '/products/add',
                        templateUrl: '/App/Main/views/products/createProduct.cshtml',
                        controller:'app.views.product.createProduct'
                        //menu: 'Products' //Matches to name of 'Products' menu in PolyStoneNavigationProvider
                    });
                $urlRouterProvider.otherwise('/');
            }

            $stateProvider
                .state('home', {
                    url: '/',
                    templateUrl: '/App/Main/views/home/home.cshtml'//,
                    //menu: 'Home' //Matches to name of 'Home' menu in PolyStoneNavigationProvider
                })
                .state('about', {
                    url: '/about',
                    templateUrl: '/App/Main/views/about/about.cshtml'//,
                    //menu: 'About' //Matches to name of 'About' menu in PolyStoneNavigationProvider
                });
        }
    ]);

})();