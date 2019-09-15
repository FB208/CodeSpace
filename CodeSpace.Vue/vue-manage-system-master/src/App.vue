<template>
    <div id="app">
        <router-view></router-view>
    </div>
</template>
<style>
    @import "./assets/css/main.css";
    /*@import "./assets/css/color-dark.css";     深色主题*/
    @import "./assets/css/theme-green/color-green.css"; /*  浅绿色主题*/
    /* 新增的样式文件，用less编写，以后main.css逐渐过渡到global.css */
    @import "./assets/css/global.less"
</style>