<template>
  <div>
    <h1 class="fancy-font">Quizzes</h1>
    <div class="options-container">
      <div class="quiz-card" v-for="quiz in quizzes" :key="quiz.id">
        <QuizCard :quiz="quiz"/>
        <div class="bottom-text-container">
          <p class="bottom-text"><a href="updateQuiz">Update</a></p>
          <p class="bottom-text"><a @click="deleteQuiz(quiz.id)" style="color: #7A2021; cursor: pointer;">Delete</a></p>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { ref, onMounted } from 'vue';
import axios from 'axios';
import QuizCard from "@/components/QuizCard.vue";

export default {
  components: { QuizCard },
  setup() {
    const quizzes = ref([]);

    const fetchQuizzes = async () => {
      try {
        const response = await axios.get('https://localhost:7244/api/Quiz/ReadAllQuizzes');
        quizzes.value = response.data;
      } catch (error) {
        console.error('Failed to fetch quizzes:', error);
        console.error('Request URL:', error.config.url);
        console.error('Status Code:', error.response.status);
        console.error('Response Data:', error.response.data);
        alert('Failed to fetch quizzes. Please try again.');
      }
    };

    const deleteQuiz = async (quizId) => {
      if (!confirm('Are you sure you want to delete this quiz?')) return;

      try {
        await axios.delete(`https://localhost:7244/api/Quiz/DeleteOneQuiz/${quizId}`);
        quizzes.value = quizzes.value.filter(quiz => quiz.id !== quizId);
        alert('Quiz successfully deleted!');
      } catch (error) {
        console.error('Failed to delete the quiz:', error);
        console.error('Request URL:', error.config.url);
        console.error('Status Code:', error.response.status);
        console.error('Response Data:', error.response.data);
        alert('Failed to delete the quiz. Please try again.');
      }
    };

    onMounted(fetchQuizzes);

    return {
      quizzes,
      deleteQuiz
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
  background-color: #ffffff;
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
