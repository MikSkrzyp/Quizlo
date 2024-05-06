<script setup>
import {defineProps, defineEmits} from "vue"

const emit = defineEmits(["selectOption"])
const { question } = defineProps(['question']);

const emitSelectedOption = (isCorrect) => {
  emit("selectOption", isCorrect)
}
</script>

<template>
  <div class="question-container">
    <h1 class="question">
      {{question.questionText}}
    </h1>
    <h4>{{question.questionType}}</h4>
    <div
        v-for="answer in question.answers"
        :key="answer.answerID"
        @click="emitSelectedOption(answer.isCorrect)"
    >
      <h1> {{answer.answerText}} </h1>
    </div>
  </div>
</template>

<style scoped>
.question-container {
  margin: auto;
  text-align: center;
}
</style>