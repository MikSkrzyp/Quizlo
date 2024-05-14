import { createRouter, createWebHistory } from 'vue-router'
import QuizzesView from '../views/QuizzesView.vue'
import Login from '../views/Login.vue'
import Register from '../views/Register.vue'
import AboutUs from '../views/AboutUs.vue'
import QuizView from "@/views/QuizView.vue";
import PostQuiz from "@/views/PostQuiz.vue";
import HomePage from "@/views/HomePage.vue";
import PutQuiz from "@/views/PutQuiz.vue";
import UsersList from "@/views/UsersList.vue";
import { useAuthStore } from "@/stores/users.js";

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
            path: '/login',
            name: 'login',
            component: Login
        },
        {
            path: '/register',
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
            component: QuizView,
            meta: { requiresLoggedin: true }
        },
        {
            path: '/postQuiz',
            name: 'postQuiz',
            component: PostQuiz,
            meta: { requiresAdmin: true }
        },
        {
            path: '/updateQuiz/:id',
            name: 'updateQuiz',
            component: PutQuiz,
            meta: { requiresAdmin: true }
        },
        {
            path: '/users',
            name: 'users',
            component: UsersList,
            meta: { requiresAdmin: true }
        }
    ]
})

router.beforeEach((to, from, next) => {
    const authStore = useAuthStore();

    // Check if the route requires to be logged in
    if (to.matched.some(record => record.meta.requiresLoggedin)) {
        if (!authStore.isAuthenticated) {
            next({ name: 'login' });
        } else {
            next();
        }
    }

    // Check if the route requires Admin role
    else if (to.matched.some(record => record.meta.requiresAdmin)) {
        if (authStore.userRole !== 'Admin') {
            next({ name: 'login' });
        } else {
            next();
        }
    } else {
        next();
    }
});

export default router
