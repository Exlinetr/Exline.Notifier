const gulp = require("gulp");
const ts = require('gulp-typescript');
const typescript = require('typescript');
var tsProject = ts.createProject('./tsconfig.json', { typescript: typescript });

gulp.task("build", function () {
    return gulp.src("./src/**/*{ts,tsx}")
        .pipe(ts(tsProject))
        .pipe(gulp.dest('./build'));
});

gulp.task('watch', ['scripts'], function () {
    gulp.watch('./src/**/*.ts', ['scripts']);
});

gulp.task("default", ["build"], function () {

});