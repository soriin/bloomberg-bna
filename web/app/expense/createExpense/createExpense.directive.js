import angular from 'angular';
import template from './createExpense.html';

angular.module('bna')
  .directive('bnaCreateExpense', function() {
    return {
      template: template,
      controller: 'createExpenseController',
      scope: {}
    }
})