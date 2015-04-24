/// <vs BeforeBuild='webpack' />
'use strict';

var path = require('path'),
    gulp = require('gulp'),
    webpack = require('gulp-webpack-build');

var src = './app',
    // The destination is the project root folder as the final destination is configured 
    // in the webpack.config file
    dest = '.',
    webpackOptions = {
        debug: true,
        devtool: '#source-map',
        watchDelay: 200
    },
    webpackConfig = {
        useMemoryFs: true,
        progress: true
    },
    CONFIG_FILENAME = webpack.config.CONFIG_FILENAME;

gulp.task('webpack', [], function () {
    //return gulp.src(path.join(src, '**', CONFIG_FILENAME), { base: path.resolve(src) })
    return gulp.src(path.join(CONFIG_FILENAME))
        .pipe(webpack.configure(webpackConfig))
        .pipe(webpack.overrides(webpackOptions))
        .pipe(webpack.compile())
        .pipe(webpack.format({
            version: false,
            timings: true
        }))
        .pipe(webpack.failAfter({
            errors: true,
            warnings: true
        }))
        .pipe(gulp.dest(dest));
});