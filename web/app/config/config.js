import angular from 'angular';

angular.module('bna')
  .factory('config', ['baseUrl', function(baseUrl) {
    return {
      endpoints: {
        createExpense: `${baseUrl}/expenses`,
        getAllExpenses: `${baseUrl}/expenses`,
        getAllCategories: `${baseUrl}/categories`,
      }
    };
  }]);

angular.module('bna')
  .factory('baseUrl', ['$location', function($location) {
    switch ($location.host()) {
      case 'localhost':
        return 'http://localhost:9901';

      default:
        return 'http://localhost:9901';
    }
  }]);