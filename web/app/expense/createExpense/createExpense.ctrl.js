import angular from 'angular';

angular.module('bna')
  .controller('createExpenseController', 
    ['$scope', '$rootScope', 'expenseService', 'categoriesService',
      function($scope, $rootScope, expenseService, categoriesService) {
        resetForm();

        $scope.getCategories = function(query) {
          categoriesService.getAllCategories(query)
            .then(function(data) {
              $scope.categories = data;
            })
            .catch(function(err) {
              console.error(err);
            });
        }

        $scope.submitExpense = function(entry) {
          expenseService.createExpense(entry)
            .then(function() {
              $rootScope.$emit('newExpense', entry);
              resetForm();
            })
            .catch(function(err) {
              console.error(err);
            });
        };

        function resetForm() {
          $scope.expense = { category: {}};

          if ($scope.expenseForm) {
              $scope.expenseForm.$setPristine();
              $scope.expenseForm.$setUntouched();
          }
        }
}]);