<template>
    <div id="app">

        <transition name="fade">
            <div>

                <nav class="navbar navbar-expand-lg navbar-dark ">

                    <router-link to="/" class="navbar-brand">
                        <img class="logo" src="https://kms.kms.uk.net/images/came-kms-black-white.png" />
                        <span class="product">Starter App</span>
                    </router-link>

                    <button class="navbar-toggler" type="button"
                            data-toggle="collapse" data-target="#navbarSupportedContent"
                            aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                        <span class="navbar-toggler-icon"></span>
                    </button>

                    <div class="collapse navbar-collapse" id="navbarSupportedContent">
                        <nav-menu />
                    </div>

                </nav>

                <div class="container container-xl main-container">
                    <transition name="fade">
                        <router-view></router-view>
                    </transition>
                </div>
            </div>

        </transition>
    </div>
</template>

<script>
    require('bootstrap')

    import Vue from 'vue'
    import NavMenu from './nav-menu'

    Vue.component('nav-menu', NavMenu);

    import { mapMutations } from 'vuex'

    export default {
        data() {
            return {
            }
        },

        methods: {

        }
    }

</script>

<style>

    #app {
        height: 100%;
    }

    .navbar {
        background-color: rgb(0, 176, 237) !important;
    }

    div.dropdown {
        display: inline-block;
    }

    .main-container {
        margin-top: 30px;
    }

    .logo {
        height: 20px;
        margin-right: 10px;
        vertical-align: inherit;
    }

    .product {
        font-weight: 200;
        line-height: 30px;
        vertical-align: top;
    }

    .fade-enter-active, .fade-leave-active {
        transition-property: opacity;
        transition-duration: .25s;
    }

    .fade-enter-active {
        transition-delay: .25s;
    }

    .fade-enter, .fade-leave-active {
        opacity: 0
    }
</style>
