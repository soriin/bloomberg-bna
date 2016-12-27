import angular from 'angular';

angular.module('bna')
  .factory('categoriesService', ['$http', '$q', 'config', function($http, $q, config) {
    var createCategory = function(category) {
      var deferred = $q.defer();
      $http({
        method: 'POST',
        url: config.endpoints.createCategory,
        data: category
      })
      .then(function() {
        deferred.resolve();
      })
      .catch(function(err) {
        console.error(err);
        deferred.reject();
      });     

      return deferred.promise;
    };

    var getAllCategories = function() {
      var deferred = $q.defer();

      $http({
        method: 'GET',
        url: config.endpoints.getAllCategories
      })
      .then(function(data) {
        deferred.resolve(data.data);
      })
      .catch(function(err) {
        console.error(err);
        deferred.reject();
      });

      return deferred.promise;
    };

    return {
      createCategory: createCategory,
      getAllCategories: getAllCategories
    };
  }]);