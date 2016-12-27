import angular from 'angular';
import template from './displayExpenses.html';

angular.module('bna')
  .directive('bnaDisplayExpenses', function() {
    return {
      template: template,
      controller: 'displayExpensesController',
      scope: {}
    }
})