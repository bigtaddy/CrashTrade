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
    connect = require('gulp-connect');

var filePath = {
    appjsminify: { src: './Scripts/app/!**!/!*.js', dest: './dest/Scripts/app' },
    libsjsminify: { src: ['./Scripts/libs/!**!/!*.js', '!*.min.js', '!/!**!/!*.min.js'], dest: './dest/Scripts/libs/' },
    jshint: {src: './Scripts/app/**/*.js'},
    minifycss: {src: ['./styles/**/*.css', '!*.min.css', '!/**/*.min.css'], dest: './dist/styles/'}
};


/* var filePath = {
    appjsminify: { src: './Scripts/app/!**!/!*.js', dest: './Scripts/app' },
libsjsminify: { src: ['./Scripts/libs/!**!/!*.js', '!*.min.js', '!/!**!/!*.min.js'], dest: './Scripts/libs/' },
jshint: { src: './Scripts/app/!**!/!*.js' },
minifycss: { src: ['./Content/themes/!**!/!*.css', '!*.min.css', '!/!**!/!*.min.css'], dest: './Content/themes/' }
};
 */



gulp.task('libs-js-minify', function () {
    /*Excludes already minified files.*/
    gulp.src(filePath.libsjsminify.src)
        .pipe(uglify())
        .pipe(rename({ suffix: '.min' }))
        .pipe(gulp.dest(filePath.libsjsminify.dest));
});



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
    gulp.src([
            './dist/Scripts/config.js',
            './dist/Scripts/app.js',
            './dist/Scripts/**/*.js',
            './dist/Scripts/**/**/*.js'
        ])
        .pipe(concat('app.min.js'))
        .pipe(gulp.dest('./dist/Scripts/'));


    gulp.src(['./dist/styles/*.css', './dist/styles/**/*.css'])
        .pipe(concat('app.min.css'))
        .pipe(gulp.dest('./dist/styles/'));

});


gulp.task('html', function() {
    gulp.src('./index.html')
        .pipe(preprocess({context: { RELEASE: true}})) //To set environment variables in-line
        .pipe(gulp.dest('./dist/'))
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