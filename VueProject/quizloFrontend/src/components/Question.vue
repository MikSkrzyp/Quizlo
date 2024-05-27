<script setup>
import { defineProps, defineEmits } from "vue";

const emit = defineEmits(["selectOption"]);
const { question, selectedAnswerIndex, correctAnswerIndex } = defineProps(["question", "selectedAnswerIndex", "correctAnswerIndex"]);

const emitSelectedOption = (isCorrect, index) => {
  emit("selectOption", isCorrect, index);
};
</script>

<template>
  <div class="container">
    <div class="card border-primary mb-3" style="max-width: 600px; min-width: 200px">
      <div class="card-body">
        <div class="question-container">
          <h1 class="question">
            {{ question.questionText }}
          </h1>
          <h4>{{ question.questionType }}</h4>
          <div class="list-group">
            <a href="#"
               class="list-group-item list-group-item-action"
               :class="{ 'correct-answer': index === correctAnswerIndex, 'selected-answer': index === selectedAnswerIndex }"
               v-for="(answer, index) in question.answers"
               :key="answer.answerID"
               @click="emitSelectedOption(answer.isCorrect, index)"
            >
              {{ String.fromCharCode(65 + index) }}. {{ answer.answerText }}
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
  left: 50%;
  transform: translate(-50%, -50%);
}

/* Change background color */
.container .card {
  background-color: #f8f9fa; /* Default color */
}

/* Change text color */
.container .card-header,
.container .question-container h1,
.container .question-container h4,
.container .list-group-item {
  color: #000; /* Default color */
}

.correct-answer {
  background-color: #d4edda;
  color: #155724;
}

.selected-answer {
  background-color: #f8d7da;
  color: #721c24;
}
</style>
