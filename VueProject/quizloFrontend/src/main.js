import { createApp } from 'vue'
import App from './App.vue'
import router from './router'
import 'bootstrap/dist/css/bootstrap.css'
import 'bootstrap/dist/js/bootstrap.js'
import './assets/global.css'
import { createPinia } from 'pinia'

import axios from 'axios'
import Cookies from 'js-cookie'

const app = createApp(App)

app.use(router)
app.use(createPinia())

app.mount('#app')