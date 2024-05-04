import { createRouter, createWebHistory } from 'vue-router'
import QuizzesView from '../views/QuizzesView.vue'
import Login from '../views/Login.vue' // Import the Login component
import Register from '../views/Register.vue' // Import the Register component
import AboutUs from '../views/AboutUs.vue' // Import the AboutUs component

const router = createRouter({
    history: createWebHistory(import.meta.env.BASE_URL),
    routes: [
        {
            path: '/',
            name: 'quizes',
            component: QuizzesView
        },
        {
            path: '/login', // Add a route for the login page
            name: 'login',
            component: Login
        },
        {
            path: '/register', // Add a route for the register page
            name: 'register',
            component: Register
        },
        {
            path: '/aboutUs',
            name: 'aboutUs',
            component: AboutUs
        }
    ]
})

export default router
