<script setup>
import QuizHeader from "@/components/QuizHeader.vue";
import {computed, ref} from "vue";
import axios from "axios";
import { useRoute } from "vue-router";
import Question from "@/components/Question.vue";
import Result from "@/components/Result.vue";

const route = useRoute()
const quizId = parseInt(route.params.id);
const questions = ref([])

const currentQuestionIndex = ref(0);
const numberOfCorrectAnswers = ref(0)
const showResults = ref(false)





async function fetchQuizQuestions() {
  try {
    const response = await axios.get(`https://localhost:7244/api/Questions/quiz/${quizId}/Question/GetAllQuestionsById`);
    questions.value = response.data;
  } catch (error) {
    console.error(error);
  }
}

fetchQuizQuestions(); // Call the function to fetch the quiz questions

const questionStatus = computed(() => `${currentQuestionIndex.value}/${quiz.questions.length}`)
const onOptionSelected = (isCorrect) => {
  if(isCorrect){
    numberOfCorrectAnswers.value++;
  }

  if(questions.length - 1 === currentQuestionIndex.value){
    showResults.value = true
  }

  currentQuestionIndex.value++;
}

</script>

<template>
  <QuizHeader />
  <Question v-if="!showResults" :question="questions[currentQuestionIndex]" @selectOption = "onOptionSelected"/>
  <Result
      v-else
      :quizQuestionLength="quiz.questions.length"
      :numberOfCorrectAnswers="numberOfCorrectAnswers"
  />
</template>
<style scoped>

</style>