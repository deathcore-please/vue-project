import Vue from 'vue'
import axios from 'axios'
import router from './router/index'
import store from './store'
import { sync } from 'vuex-router-sync'
import App from './components/app-root'
import VueAxios from 'vue-axios'
import BootstrapVue from 'bootstrap-vue'
import SingalR from './signalr';

import 'bootstrap/dist/css/bootstrap.css'
import 'bootstrap-vue/dist/bootstrap-vue.css'

axios.defaults.baseURL = 'http://localhost:60501';

Vue.use(VueAxios, axios);
Vue.use(BootstrapVue);

Vue.router = router;

Vue.use(SingalR);

sync(store, router)

const app = new Vue({
    store,
    router,
    ...App
})

app.$mount('#app')

export {
    app,
    router,
    store
}



