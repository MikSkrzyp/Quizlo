<script setup>
import {defineProps,defineEmits} from "vue"
const { question } = defineProps(['question']);

const emit = defineEmits(['selectOption'])

const emitSelectedOption = (isCorrect) => {
  emit("selectOption", isCorrect)
}

</script>

<template>
  <div class="question-container">
    <h1 class="question">
      {{question.questionText}}
    </h1>
    <h1>{{question.questionType}}</h1>
    <div
        v-for="answer in question.answers"
        :key="answer.ID"
        @click="emitSelectedOption(answer.isCorrect)">
     <h1> {{answer.answerText}} </h1>
    </div>


  </div>
</template>

<style scoped>

</style>