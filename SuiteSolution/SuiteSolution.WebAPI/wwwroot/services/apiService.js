(function () {
    'use strict';

    angular
        .module('suiteApp')
        .service('api', apiService);

    apiService.$inject = ['$resource', 'blockUI'];

    function apiService($resource, blockUI) {
        var api = {
            defaultConfig: { id: '@id' },
            extraMethods: {
                'update': {
                    method: 'PUT'
                }
            },
            add: function (config) {
                var params,
                  url;
                // If the add() function is called with a
                // String, create the default configuration.
                if (angular.isString(config)) {
                    var configObj = {
                        resource: config,
                        url: '/' + config
                    };

                    config = configObj;
                }

                // If the url follows the expected pattern, we can set cool defaults
                if (!config.unnatural) {
                    var orig = angular.copy(api.defaultConfig);
                    params = angular.extend(orig, config.params);
                    url = config.url + '/:id';

                    // otherwise we have to declare the entire configuration. 
                } else {
                    params = config.params;
                    url = config.url;
                }

                // If we supply a method configuration, use that instead of the default extra. 
                var methods = config.methods || api.extraMethods;

                api[config.resource] = $resource(url, params, methods);
            }
        };
        return api;
    }

})();
