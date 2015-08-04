var ngPhotoSwipe = angular.module('ngPhotoSwipe', []);

/**
 * photoSwipe directive
 */
ngPhotoSwipe.directive('photoSwipe', [ function () {
	var template =
		'<div>' +
		'<div class="eight columns">' +
		'<a href="">' +
		'<ul class="">' +
		'<li class=""><img alt="" data-ng-click="openPhotoSwipe(0)" class="site" src="{{images[0].FullName}}"></li>' +
		'</ul>' +
		'</a>' +

		'<div class="twelve columns">' +
		'<div ng-repeat="image in images" class="three columns">' +
		'<a href="">' +
		'<ul class="">' +
		'<div><img alt="" data-ng-click="openPhotoSwipe($index)" class="site" src="{{image.FullName}}"></div>' +
		'</ul>' +
		'</a>' +
		'</div>' +
		'</div>' +
		'</div>' +
		'<photo-slider />';

	var initPhotoSwipeFromDOM = function(gallerySelector, $scope) {

        /**
         * parseThumbnailElements
         * @returns {Array}
         */
        var parseThumbnailElements = function () {
            var items = [];
            for (var i = 0; i < $scope.images.length; i++) {
                items[i] = {};
                items[i].src = $scope.images[i].FullName;
                items[i].h = 401;
                items[i].w = 708;

				var img = new Image();
				img.src = items[i].src;
				items[i].h = img.height;
				items[i].w = img.width;
            }

            return items;
        };

		/**
		 * openPhotoSwipe
		 * @param index
		 * @param disableAnimation
		 */
		$scope.openPhotoSwipe = function(index, disableAnimation) {
			var pswpElement = document.querySelectorAll('.pswp')[0],
				gallery,
				options,
				items;

			items = parseThumbnailElements();

			// define options (if needed)
			options = {
				index: index,
				history: false,
				focus: false,

				showAnimationDuration: 0,
				hideAnimationDuration: 0
			};

			// Pass data to PhotoSwipe and initialize it
			gallery = new PhotoSwipe( pswpElement, PhotoSwipeUI_Default, items, options);
			gallery.init();
		};
	};

    /**
     * linkFn
     * @param elem
     * @param attr
     * @param $scope
     */
	var linkFn = function($scope, elem, attr) {
        $scope.imagesPromise.then(function (result) {
            $scope.images = result;
        });

        initPhotoSwipeFromDOM('#' + elem.attr('id'), $scope);

	};

	return {
        restrict: 'EA',
        replace: true,
		scope: {
            imagesPromise: '=',
            width: '=',
			height: '=',
			template: '='
        },
        template: template,
		link: linkFn
    };
}]);

/**
 * photoSlider directive
 */
ngPhotoSwipe.directive('photoSlider', [ function () {
	var template =
		'<div class="pswp" tabindex="-1" role="dialog" aria-hidden="true">' +
			'<div class="pswp__bg"></div>' +
			'<div class="pswp__scroll-wrap">' +
				'<div class="pswp__container">' +
					'<div class="pswp__item"></div>' +
					'<div class="pswp__item"></div>' +
					'<div class="pswp__item"></div>' +
				'</div>' +
				'<div class="pswp__ui pswp__ui--hidden">' +
					'<div class="pswp__top-bar">' +
						'<div class="pswp__counter"></div>' +
						'<button class="pswp__button pswp__button--close" title="Close (Esc)"></button>' +
						'<button class="pswp__button pswp__button--share" title="Share"></button>' +
						'<button class="pswp__button pswp__button--fs" title="Toggle fullscreen"></button>' +
						'<button class="pswp__button pswp__button--zoom" title="Zoom in/out"></button>' +
						'<div class="pswp__preloader">' +
							'<div class="pswp__preloader__icn">' +
							  '<div class="pswp__preloader__cut">' +
								'<div class="pswp__preloader__donut"></div>' +
							  '</div>' +
							'</div>' +
						'</div>' +
					'</div>' +
					'<div class="pswp__share-modal pswp__share-modal--hidden pswp__single-tap">' +
						'<div class="pswp__share-tooltip"></div>' +
					'</div>' +
					'<button class="pswp__button pswp__button--arrow--left" title="Previous (arrow left)">' +
					'</button>' +
					'<button class="pswp__button pswp__button--arrow--right" title="Next (arrow right)">' +
					'</button>' +
					'<div class="pswp__caption">' +
						'<div class="pswp__caption__center"></div>' +
					'</div>' +
				'</div>' +
			'</div>' +
		'</div>';

	return {
        restrict: 'EA',
        replace: true,
        template: template
    };
}]);
