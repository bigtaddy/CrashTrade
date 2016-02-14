/**
 * Created by shijuvar on 16/2/14.
 */


var gulp = require('gulp'),
    gutil = require('gulp-util'),
    uglify = require('gulp-uglify'),
    jshint = require('gulp-jshint'),
    concat = require('gulp-concat'),
    jshintreporter = require('jshint-stylish'),
    minifycss = require('gulp-minify-css'),
    size = require('gulp-size'),
    clean = require('gulp-clean'),
    rename = require('gulp-rename'),
    open = require('gulp-open'),
    connect = require('gulp-connect');

var filePath = {
    appjsminify: {
        src: ['./Scripts/*.js', './Scripts/app/**/*.js', './Scripts/libs/**/*.js',
            '!*.min.js', '!/**/*.min.js'], dest: './dist/Scripts/'
    },
    jshint: {src: './Scripts/app/**/*.js'},
    minifycss: {src: ['./styles/**/*.css', '!*.min.css', '!/**/*.min.css'], dest: './dist/styles/'}
};


gulp.task('app-js-minify', function () {
    gulp.src(filePath.appjsminify.src)
        .pipe(uglify())
        .pipe(size())
        .pipe(gulp.dest(filePath.appjsminify.dest));
});


gulp.task('jshint', function () {
    gulp.src(filePath.jshint.src)
        .pipe(jshint())
        .pipe(jshint.reporter(jshintreporter));
});


gulp.task('minify-css', function () {
    /*Excludes already minified files.*/
    gulp.src(filePath.minifycss.src)
        .pipe(minifycss())
        .pipe(rename({suffix: '.min'}))
        .pipe(gulp.dest(filePath.minifycss.dest));
});

/*gulp.task('clean', function () {
 gulp.src(
 [
 './dist/Scripts/app/site.min.js',
 './dist/Scripts/libs/libs.min.js',
 './dist/styles/site.min.css'
 ], { read: false })
 .pipe(clean({ force: true }));
 });*/

gulp.task('concat', function () {
    gulp.src(['./dist/Scripts/app/*.js',
            './dist/Scripts/angular.js',
            './dist/Scripts/angular-sanitize.js',
            './dist/Scripts/angular-route.js',
            './dist/Scripts/angular-resource.js',
            './dist/Scripts/angular-animate.js',
            './dist/Scripts/select/select.js',
            './dist/Scripts/ng-flow-standalone.js',
            './dist/Scripts/ng-table/ng-table.js',
            './dist/Scripts/photoswipe.min.js',
            './dist/Scripts/truncate.js',
            './dist/Scripts/photoswipe-ui-default.min.js',
            './dist/Scripts/angular-photoswipe.js',
            './dist/Scripts/loading-bar.js',
            './dist/Scripts/ui-bootstrap/ui-bootstrap-tpls-0.14.3.min.js',
            './dist/Scripts/angular-local-storage.js',
            './dist/Scripts/config.js',
            './dist/Scripts/app.js',
            './dist/Scripts/**/*.js',
            './dist/Scripts/**/**/*.js'
        ])
        .pipe(concat('app.min.js'))
        .pipe(gulp.dest('./Scripts/'));

    gulp.src(['./dist/styles/*.css', './dist/styles/**/*.css'])
        .pipe(concat('app.min.css'))
        .pipe(gulp.dest('./styles/'));

});

gulp.task('build', ['jshint', 'app-js-minify', 'minify-css', 'concat']);
gulp.task('cleanbuild', ['clean']);

/*gulp.task('tests', function () {
 connect.server({
 port:8000
 });
 var testUrl = "http://localhost:8000/SpecRunner.html";
 gulp.src("./SpecRunner.html")
 .pipe(open("", { url: testUrl }));
 });
 */
//gulp.watch('./app/**/*.js', ['js']);