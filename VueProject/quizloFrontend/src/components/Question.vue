<script setup>
import {defineProps, defineEmits} from "vue"

const emit = defineEmits(["selectOption"])
const { question } = defineProps(['question']);

const emitSelectedOption = (isCorrect) => {
  emit("selectOption", isCorrect)
}
</script>

<template>
  <div class="container">
    <div class="card border-primary mb-3" style="max-width: 600px; min-width: 200px">
      <div class="card-body">
        <div class="question-container">
          <h1 class="question">
            {{question.questionText}}
          </h1>
          <h4>{{question.questionType}}</h4>
          <div class="list-group">
            <a href="#"
               class="list-group-item list-group-item-action"
               v-for="(answer, index) in question.answers"
               :key="answer.answerID"
               @click="emitSelectedOption(answer.isCorrect)"
            >
              {{ String.fromCharCode(65 + index) }}. {{answer.answerText}}
            </a>
          </div>
        </div>
      </div>
    </div>
  </div>

</template>

<style scoped>
.container {
  margin: auto;
  text-align: center;
}
/* Center container */
.container {
  position: fixed;
  top: 50%;
  left: 50% ;
  transform: translate(-50%, -50%);
}

/* Change background color */
.container .card {
  background-color: #f8f9fa; /* Default color */
}

/* Change text color */
.container .card-header,
.container.question-container h1,
.container .question-container h4,
.container .list-group-item {
  color: #000; /* Default color */
}
</style>