﻿(function () {
    'use strict';
    angular.module('app')
        .directive('albumCard', albumCard);
    function albumCard() {
        return {
            restrict: 'E',
            transclude: true,
            scope: {
                albumId: '@',
                title: '@',
                artistId: '@'
            },
            templateUrl: 'app/private/album/directives/album-card/album-card.html'

        };
    }
})();
