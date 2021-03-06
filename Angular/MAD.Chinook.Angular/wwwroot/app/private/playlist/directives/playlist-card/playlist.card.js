﻿(function () {
    'use strict';
    angular.module('app')
        .directive('playlistCard', playlistCard);
    function playlistCard() {
        return {
            restrict: 'E',
            transclude: true,
            scope: {
                playlistId: '@',
                name: '@'
            },
            templateUrl: 'app/private/playlist/directives/playlist-card/playlist-card.html'

        };
    }
})();
