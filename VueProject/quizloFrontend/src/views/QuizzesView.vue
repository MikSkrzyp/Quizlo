<script setup>
import { ref, onMounted } from 'vue';
//import axios from 'axios';
import axios from '../stores/axios.js'
import QuizCard from '@/components/QuizCard.vue';
import { useRouter } from 'vue-router';
import { useAuthStore } from '@/stores/users.js';
import {API_URL} from "@/stores/config.js";


const quizzes = ref([]);
const router = useRouter();
const authStore = useAuthStore();





const fetchQuizzes = async () => {
  try {
    const response = await axios.get(`${API_URL}/api/Quiz/ReadAllQuizzes`);
    quizzes.value = response.data;
  } catch (error) {
    console.error('Failed to fetch quizzes:', error);
    alert('Failed to fetch quizzes. Please try again.');
  }
};

const deleteQuiz = async (quizId) => {
  if (!confirm('Are you sure you want to delete this quiz?')) return;

  try {
    await axios.delete(`${API_URL}/api/Quiz/DeleteOneQuiz/${quizId}`);
    quizzes.value = quizzes.value.filter(quiz => quiz.id !== quizId);
    alert('Quiz successfully deleted!');
    window.location.reload();
  } catch (error) {
    console.error('Failed to delete the quiz:', error);
    alert('Failed to delete the quiz. Please try again.');
  }
};

const updateQuiz = (quizId) => {
  router.push({ name: 'updateQuiz', params: { id: quizId } });
};

onMounted(fetchQuizzes);
</script>

<template>
  <div>
    <div class="d-flex justify-content-between align-items-center">
      <h1 class="fancy-font mx-auto">Quizzes</h1>
      <router-link
          v-if="authStore.isAuthenticated && authStore.userRole === 'Admin'"
          to="/PostQuiz"
          class="btn btn-light custom-btn"
          style="background-color: #60A1BC; color: white; border: none; margin-right: 20px;"
      >
        Create Quiz
      </router-link>
    </div>
    <br />
    <div class="options-container">
      <div class="row">
        <div
            class="col-lg-4 col-md-6 col-sm-12"
            v-for="quiz in quizzes"
            :key="quiz.id"
        >
          <div class="quiz-card">
            <div class="quiz-card-content">
              <QuizCard :quiz="quiz" />
            </div>
            <div
                v-if="authStore.isAuthenticated && authStore.userRole === 'Admin'"
                class="bottom-text-container"
            >
              <p class="bottom-text">
                <a
                    @click="updateQuiz(quiz.quizID)"
                    :style="{ color: '#46a8f3', cursor: 'pointer' }"
                >
                  Update
                </a>
              </p>
              <p class="bottom-text">
                <a
                    @click="deleteQuiz(quiz.quizID)"
                    :style="{ color: '#7A2021', cursor: 'pointer' }"
                >
                  Delete
                </a>
              </p>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>



<style scoped>
.options-container {
  padding: 0 15px;
}

.quiz-card {
  display: flex;
  flex-direction: column;
  height: 100%;
  margin-bottom: 20px;
  background-color: rgba(195, 195, 195, 0.92);
  border: 1px solid #ddd;
  border-radius: 14px;
  padding: 20px;
}

.quiz-card-content {
  flex-grow: 1;
}

.fancy-font {
  font-family: 'Lobster', cursive;
  font-size: 4rem;
  text-align: center;
  margin-top: 30px;
  color: #3C89AA;
}

.bottom-text-container {
  display: flex;
  justify-content: flex-end;
}

.bottom-text {
  margin-left: 10px;
  color: #167ac1;
}
</style>
