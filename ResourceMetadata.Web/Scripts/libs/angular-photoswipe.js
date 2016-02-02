var ngPhotoSwipe = angular.module('ngPhotoSwipe', []);

/**
 * photoSwipe directive
 */
ngPhotoSwipe.directive('photoSwipe', [ function () {
	var template =
		'<div class="row"">' +



		'<div class="col-lg-12">' +
		'<a class="" href="" data-ng-click="openPhotoSwipe(0)">' +
		'<img style="box-shadow:0 0 10px #000;" class="img-rounded img-responsive shadow" alt="" ng-src="{{images[0].FullName}}">' +
		'</a>' +
		'</div>' +

		'<div class="img_scrollbar details_img_scrollbar col-lg-12">' +



		'<div ng-repeat="image in images" style="display: inline-block">' +
		'<div>'+
		'<a class="" data-ng-click="openPhotoSwipe($index)" href="">' +
		'<img class="img-rounded img-responsive shadow" style="max-height: 100px" ng-src="{{image.FullName}}">' +
		'</a>' +
		'</div>' +
		'</div>' +

		'</div>' +

		'<photo-slider />' +
		'</div>';

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
