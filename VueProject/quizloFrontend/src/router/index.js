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
import UsersList from "@/views/UsersList.vue";
import {useAuthStore} from "@/stores/users.js";
import UserProfile from "@/views/UserProfile.vue";



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
            component:PostQuiz,
            meta: { requiresAdmin: true }
        },
        // {
        //     path: '/deleteQuiz',
        //     name:'deleteQuiz',
        //     component:DeleteQuiz
        // },
        {
            path: '/updateQuiz/:id',
            name:'updateQuiz',
            component:PutQuiz,
            meta: { requiresAdmin: true }
        },
        {
            path: '/users',
            name:'users',
            component:UsersList,
            meta: { requiresAdmin: true }
        },
        {
            path: '/profile',
            name:'UserProfile',
            component:UserProfile,
            meta: { requiresAdmin: false }
        }

    ]
})

router.beforeEach((to, from, next) => {
    const authStore = useAuthStore();
    // Check if the route requires Admin role
    if (to.matched.some(record => record.meta.requiresAdmin)) {
        // Check if the user's role is not 'Admin'
        if (authStore.userRole !== 'Admin') {
            // Redirect to the login page
            next({ name: 'login' });
        } else {
            // Otherwise, proceed with the route transition
            next();
        }
    } else {
        // If the route does not require Admin role, proceed with the route transition
        next();
    }
});

export default router
