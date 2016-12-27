import angular from 'angular';

angular.module('bna')
  .controller('displayExpensesController', 
    ['$scope', '$rootScope', 'expenseService', 
      function($scope, $rootScope, expenseService) {
        var self = this;

        $scope.getAllExpenses = getAllExpenses;

        getAllExpenses();

        $rootScope.$on('newExpense', handleNewExpense);

        function handleNewExpense() {
          getAllExpenses();
        };

        function getAllExpenses() {
          expenseService.getAllExpenses()
            .then(function(data) {
              self.refreshList(data);
            })
            .catch(function(err) {
              console.error(err);
            });
        };

        this.refreshList = function(listData) {
          $scope.expenseList = listData;
        };
}]);