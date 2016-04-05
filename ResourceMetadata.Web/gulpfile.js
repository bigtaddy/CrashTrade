/**
 * Created by shijuvar on 16/2/14.
 */


var gulp = require('gulp'),
    gutil = require('gulp-util'),
    uglify = require('gulp-uglify'),
    jshint = require('gulp-jshint'),
    concat = require('gulp-concat'),
    preprocess = require('gulp-preprocess'),
    jshintreporter = require('jshint-stylish'),
    minifycss = require('gulp-minify-css'),
    size = require('gulp-size'),
    clean = require('gulp-clean'),
    rename = require('gulp-rename'),
    open = require('gulp-open'),
    ngAnnotate = require('gulp-ng-annotate'),
    del = require('del'),
    connect = require('gulp-connect');


var filePath = {
    appjsconcat: {
        src: [
            './Scripts/config.js',
            './Scripts/app/app.js',
            './Scripts/app/**/*.js'
        ],
        dest: './dist/Scripts/'
    },
    libsjsconcat: {
        src: [
            './Scripts/libs/angular.js',
            './Scripts/libs/angular-sanitize.js',
            './Scripts/libs/angular-route.js',
            './Scripts/libs/angular-resource.js',
            './Scripts/libs/angular-animate.js',
            './Scripts/libs/select/select.js',
            './Scripts/libs/ng-flow-standalone.js',
            './Scripts/libs/ng-table/ng-table.js',
            './Scripts/libs/photoswipe.min.js',
            './Scripts/libs/truncate.js',
            './Scripts/libs/photoswipe-ui-default.min.js',
            './Scripts/libs/angular-photoswipe.js',
            './Scripts/libs/loading-bar.js',
            './Scripts/libs/ui-bootstrap/ui-bootstrap-tpls-0.14.3.min.js',
            './Scripts/libs/angular-local-storage.js'
        ],
        dest: './dist/Scripts/libs'
    },
    jshint: {src: './Scripts/app/**/*.js'},
    concatcss: {
        src: [
            './styles/*.css',
            './styles/**/*.css'
        ],
        dest: './dist/styles/'
    }
};

gulp.task('jshint', function () {
    gulp.src(filePath.jshint.src)
        .pipe(jshint())
        .pipe(jshint.reporter(jshintreporter));
});

gulp.task('clean', function () {
    del(['dist']);
});

gulp.task('copy', function () {
    gulp.src([
        'assets/images/*.*',
        'assets/images/photoswipe/*.*'
    ])
        .pipe(gulp.dest('dist/assets/images'));

    gulp.src(['assets/images/photoswipe/*.*'])
        .pipe(gulp.dest('dist/assets/images/photoswipe'));

    gulp.src([
        './Scripts/app/**/*.html',
        './Scripts/app/**/**/*.html'
    ]).pipe(gulp.dest('dist/Scripts/app'));
});

gulp.task('concat', function () {
    gulp.src(filePath.appjsconcat.src)
        .pipe(concat('app.js'))
        .pipe(ngAnnotate())
        .pipe(uglify())
        .pipe(rename({suffix: '.min'}))
        .pipe(gulp.dest(filePath.appjsconcat.dest));


    gulp.src(filePath.libsjsconcat.src)
        .pipe(concat('libs.js'))
        .pipe(ngAnnotate())
        .pipe(uglify())
        .pipe(rename({suffix: '.min'}))
        .pipe(gulp.dest(filePath.libsjsconcat.dest));


    gulp.src([
        './styles/*.css',
        './styles/**/*.css'
    ])
        .pipe(concat('app.css'))
        .pipe(minifycss())
        .pipe(rename({suffix: '.min'}))
        .pipe(gulp.dest('./dist/styles/'));
});


gulp.task('preprocess', function () {
    gulp.src('./index.html')
        .pipe(preprocess({context: {RELEASE: true}})) //To set environment variables in-line
        .pipe(gulp.dest('./dist/'))
});


gulp.task('build', [
    'clean',
    'concat',
    'copy',
    'preprocess'
]);

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