(function() {
    'use strict';

    angular
        .module('app.agenda', [
            // request the the entire framework
            'angle',
            // or just modules
            'app.core',
            'app.sidebar'
            /*...*/
        ]);
})();