import angular from 'angular';

angular.module('bna')
  .factory('expenseService', ['$http', '$q', 'config', function($http, $q, config) {
    var createExpense = function(expense) {
      var deferred = $q.defer();
      $http({
        method: 'POST',
        url: config.endpoints.createExpense,
        data: expense
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

    var getAllExpenses = function() {
      var deferred = $q.defer();

      $http({
        method: 'GET',
        url: config.endpoints.getAllExpenses
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
      createExpense: createExpense,
      getAllExpenses: getAllExpenses
    };
  }]);