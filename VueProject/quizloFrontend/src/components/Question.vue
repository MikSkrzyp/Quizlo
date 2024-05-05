<script setup>
import {defineProps} from "vue"
const { question } = defineProps(['question']);

</script>

<template>
  <div class="question-container">
    <h1 class="question">
      {{question.questionText}}
    </h1>
    <h1>{{question.questionType}}</h1>
    <div
        v-for="answer in question.answers"
        :key="answer.ID">
      <h1> {{answer.answerText}} </h1>
    </div>


  </div>
</template>

<style scoped>

</style>