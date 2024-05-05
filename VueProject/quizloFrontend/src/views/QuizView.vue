<script setup>
import QuizHeader from "@/components/QuizHeader.vue";
import {ref, computed} from "vue";
import axios from "axios";
import {useRoute} from "vue-router";
import Question from "@/components/Question.vue";
import Result from "@/components/Result.vue";

const route = useRoute()
const quizId = parseInt(route.params.id);
const questions = ref([])
const currentQuestionIndex = ref(0);
const numberOfCorrectAnswers = ref(0)
const showResults = ref(false)

const questionStatus = computed(() => `${currentQuestionIndex.value + 1}/${questions.value.length}`)
const barPercentage = computed(() => `${(currentQuestionIndex.value / questions.value.length) * 100}%`)

async function fetchQuizQuestions() {
  try {
    const response = await axios.get(`https://localhost:7244/api/Questions/quiz/${quizId}/Question/GetAllQuestionsById`);
    questions.value = response.data;
  } catch (error) {
    console.error(error);
  }
}

fetchQuizQuestions(); // Call the function to fetch the quiz questions

const onOptionSelected = (isCorrect) => {
  if(isCorrect){
    numberOfCorrectAnswers.value++;
  }

  if(questions.value.length - 1 === currentQuestionIndex.value){
    showResults.value = true
  } else {
    currentQuestionIndex.value++;
  }
}
</script>

<template>
  <div>
  <QuizHeader
    :questionStatus="questionStatus"
    :barPercentage="barPercentage"
  />

    <Question
      v-if="!showResults"
      :question="questions[currentQuestionIndex]"
      @selectOption="onOptionSelected"
    />
    <Result
      v-else
      :quizQuestionLength="questions.length"
      :numberOfCorrectAnswers="numberOfCorrectAnswers"
    />
  </div>
</template>