/// <binding AfterBuild='default' Clean='clean' />
/*
This file is the main entry point for defining Gulp tasks and using Gulp plugins.
Click here to learn more. http://go.microsoft.com/fwlink/?LinkId=518007
*/

var gulp = require('gulp');
var del = require('del'); //del是gulp的插件，github地址：https://github.com/sindresorhus/del 。使用npm install del -g 进行的全局安装。
var typescript = require('gulp-tsc'); //编译ts 的插件
var ts = require('gulp-typescript');
//var tsproj = ts.createProject("./tsconfig.json");


var paths = {
    scripts: ['tsscripts/*.ts'],
};

gulp.task('clean', function () {
    return del(['wwwroot/scripts/**/*']);
});

//记得写return https://stackoverflow.com/questions/36897877/gulp-error-the-following-tasks-did-not-complete-did-you-forget-to-signal-async
/*gulp.task('default', function () {
    return gulp.src(paths.scripts).pipe(ts()).pipe(gulp.dest('wwwroot/scripts'))
});*/

gulp.task('compile', function () {
    return gulp.src('tsscripts/*.ts')
        　　.pipe(ts())
        .pipe(gulp.dest('wwwroot/scripts'));
});

//添加监视:监听ts文件变动生成js文件
gulp.task('watch', function () {
    //gulp.watch('./tsscripts/*.ts',["compile"]);
});


//运行gulp $ gulp 