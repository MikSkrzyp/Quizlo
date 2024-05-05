<template>
  <div class="quiz-list">
    <h1>Quizzes</h1>
    <div class="options-container">
      <QuizCard v-for="(quiz, index) in quizzes" :key="quiz.id" :quiz="quiz"/>
    </div>
  </div>
</template>

<script>
import { ref, onMounted } from 'vue';
import axios from 'axios';
import QuizCard from "@/components/QuizCard.vue";

export default {
  components: {QuizCard},
  setup() {
    const quizzes = ref([]);

    onMounted(async () => {
      try {
        const response = await axios.get('https://localhost:7244/api/Quiz/ReadAllQuizzes');
        quizzes.value = response.data;
      } catch (error) {
        console.error(error);
      }
    });


    return {
      quizzes,
    };
  },
};
</script>

<style scoped>
.quiz-list {
  max-width: 600px;
  margin: 40px auto;
  padding: 20px;
  background-color: #f7f7f7;
  border: 1px solid #ddd;
  box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
}

.quiz-list h1 {
  margin-top: 0;
}

.quiz-list ul {
  list-style: none;
  padding: 0;
  margin: 0;
}

.quiz-list li {
  padding: 10px;
  border-bottom: 1px solid #ccc;
}

.quiz-list li:last-child {
  border-bottom: none;
}
</style>