import { createRouter, createWebHistory } from 'vue-router'
import QuizzesView from '../views/QuizzesView.vue'
import Login from '../views/Login.vue' // Import the Login component
import Register from '../views/Register.vue' // Import the Register component
import AboutUs from '../views/AboutUs.vue'
import QuizView from "@/views/QuizView.vue";
import PostQuiz from "@/views/PostQuiz.vue"; // Import the AboutUs component
import HomePage from "@/views/HomePage.vue";
import DeleteQuiz from "@/views/DeleteQuiz.vue";
import PutQuiz from "@/views/PutQuiz.vue";


const router = createRouter({
    history: createWebHistory(import.meta.env.BASE_URL),
    routes: [
        {
            path: '/homePage',
            name: 'HomePage',
            component: HomePage
        },
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
        },
        {
            path: '/quiz/:id',
            name: 'quizId',
            component: QuizView

        },
        {
            path: '/postQuiz',
            name:'postQuiz',
            component:PostQuiz
        },
        {
            path: '/deleteQuiz',
            name:'deleteQuiz',
            component:DeleteQuiz
        },
        {
            path: '/updateQuiz',
            name:'updateQuiz',
            component:PutQuiz
        }

    ]
})

export default router
