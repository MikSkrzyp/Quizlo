<script setup>
import QuizHeader from "@/components/QuizHeader.vue";
import {ref} from "vue";
import axios from "axios";
import {useRoute} from "vue-router";
import Question from "@/components/Question.vue";

const route = useRoute()
const quizId = parseInt(route.params.id);
const questions = ref([])
const currentQuestionIndex = ref(0);

async function fetchQuizQuestions() {
  try {
    const response = await axios.get(`https://localhost:7244/api/Questions/quiz/${quizId}/Question/GetAllQuestionsById`);
    questions.value = response.data;
  } catch (error) {
    console.error(error);
  }
}

fetchQuizQuestions(); // Call the function to fetch the quiz questions
</script>

<template>
  <QuizHeader/>
  <Question :question="questions[currentQuestionIndex]"/>
</template>
<style scoped>

</style>