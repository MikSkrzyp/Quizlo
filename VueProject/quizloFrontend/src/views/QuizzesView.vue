<template>
  <div>
    <div class="d-flex justify-content-between align-items-center">
      <h1 class="fancy-font mx-auto">Quizzes</h1>
      <router-link to="/PostQuiz" class="btn btn-light custom-btn" style="background-color: #60A1BC; color: white; border: none; margin-right: 20px;">Create Quiz</router-link>
    </div>
    <br>
    <div class="options-container">
      <div class="quiz-card" v-for="quiz in quizzes" :key="quiz.id">
        <QuizCard :quiz="quiz"/>
        <div class="bottom-text-container">
          <p class="bottom-text"><a @click="updateQuiz(quiz.quizID)" :style="{ color: '#46a8f3', cursor: 'pointer' }">Update</a></p>
          <p class="bottom-text"><a @click="deleteQuiz(quiz.quizID)" :style="{ color: '#7A2021', cursor: 'pointer' }">Delete</a></p>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { ref, onMounted } from 'vue';
import axios from 'axios';
import QuizCard from "@/components/QuizCard.vue";
import { useRouter } from 'vue-router';


export default {
  components: { QuizCard },

  setup() {
    const quizzes = ref([]);
    const router = useRouter();
    const fetchQuizzes = async () => {
      try {
        const response = await axios.get('https://localhost:7244/api/Quiz/ReadAllQuizzes');
        quizzes.value = response.data;
      } catch (error) {
        console.error('Failed to fetch quizzes:', error);
        alert('Failed to fetch quizzes. Please try again.');
      }
    };

    const deleteQuiz = async (quizId) => {
      if (!confirm('Are you sure you want to delete this quiz?')) return;

      try {
        await axios.delete(`https://localhost:7244/api/Quiz/DeleteOneQuiz/${quizId}`);
        quizzes.value = quizzes.value.filter(quiz => quiz.id !== quizId);
        alert('Quiz successfully deleted!');
        window.location.reload();  // Refresh the page to reflect changes
      } catch (error) {
        console.error('Failed to delete the quiz:', error);
        alert('Failed to delete the quiz. Please try again.');
      }
    };

    const updateQuiz = (quizId) => {
      // Navigate to the updateQuiz route with the quiz ID parameter
      router.push({ name: 'updateQuiz', params: { id: quizId } });
    };
    onMounted(fetchQuizzes);

    return {
      quizzes,
      deleteQuiz,
      updateQuiz
    };
  },
};
</script>

<style scoped>
.options-container {
  display: flex;
  flex-wrap: wrap;
  justify-content: space-between;
}

.quiz-card {
  flex: 0 0 calc(33.33% - 20px);
  margin-bottom: 20px;
  background-color: rgba(195, 195, 195, 0.92);
  border: 1px solid #ddd;
  border-radius: 14px;
  padding: 20px;
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
