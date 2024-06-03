<script setup>
import QuizHeader from "@/components/QuizHeader.vue";
import { ref, computed } from "vue";
import axios from "axios";
import { useRoute } from "vue-router";
import Question from "@/components/Question.vue";
import Result from "@/components/Result.vue";
import {API_URL} from "@/stores/config.js";

const route = useRoute();
const quizId = parseInt(route.params.id);
const questions = ref([]);
const currentQuestionIndex = ref(0);
const numberOfCorrectAnswers = ref(0);
const showResults = ref(false);
const selectedAnswerIndex = ref(null); // New state to keep track of selected answer index
const correctAnswerIndex = ref(null); // New state to keep track of the correct answer index

const questionStatus = computed(() => `${currentQuestionIndex.value + 1}/${questions.value.length}`);
const barPercentage = computed(() => `${(currentQuestionIndex.value / questions.value.length) * 100}%`);

async function fetchQuizQuestions() {
  try {
    const response = await axios.get(`${API_URL}/api/Questions/quiz/${quizId}/Question/GetAllQuestionsById`);
    questions.value = response.data;
  } catch (error) {
    console.error(error);
  }
}

fetchQuizQuestions(); // Call the function to fetch the quiz questions

const onOptionSelected = (isCorrect, index) => {
  selectedAnswerIndex.value = index; // Set the selected answer index
  correctAnswerIndex.value = questions.value[currentQuestionIndex.value].answers.findIndex(answer => answer.isCorrect); // Find the correct answer index

  if (isCorrect) {
    numberOfCorrectAnswers.value++;
  }

  // Delay before moving to the next question
  setTimeout(() => {
    if (questions.value.length - 1 === currentQuestionIndex.value) {
      showResults.value = true;
    } else {
      currentQuestionIndex.value++;
      selectedAnswerIndex.value = null; // Reset the selected answer index for the next question
      correctAnswerIndex.value = null; // Reset the correct answer index for the next question
    }
  }, 1000); // 1-second delay
};
</script>

<template>
  <div>
    <QuizHeader
        :questionStatus="questionStatus"
        :barPercentage="barPercentage"
    />
    <Question
        style="display: flex; justify-content: center"
        v-if="!showResults"
        :question="questions[currentQuestionIndex]"
        :selectedAnswerIndex="selectedAnswerIndex"
        :correctAnswerIndex="correctAnswerIndex"
        @selectOption="onOptionSelected"
    />
    <Result
        v-else
        :quizQuestionLength="questions.length"
        :numberOfCorrectAnswers="numberOfCorrectAnswers"
    />
  </div>
</template>
