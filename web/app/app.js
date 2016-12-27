import './styles/style.scss';
import angular from 'angular';
import '../bower_components/angular-ui-select/index';
import 'angular-sanitize';

var ng = angular.module('bna', ['ui.select', 'ngSanitize']);

function requireAll(r) { r.keys().forEach(r); }
requireAll(require.context('./', true, /^(?!.*spec).*\.js$/));

ng.config(function(uiSelectConfig) {
  uiSelectConfig.theme = 'bootstrap';
  uiSelectConfig.resetSearchInput = true;
  uiSelectConfig.appendToBody = true;
});