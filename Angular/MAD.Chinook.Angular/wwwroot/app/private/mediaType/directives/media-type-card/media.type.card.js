(function () {
    'use strict';
    angular.module('app')
        .directive('mediaTypeCard', mediaTypeCard);
    function mediaTypeCard() {
        return {
            restrict: 'E',
            transclude: true,
            scope: {
                mediaTypeId: '@',
                name: '@'
            },
            templateUrl: 'app/private/mediaType/directives/media-type-card/media-type-card.html'

        };
    }
})();
