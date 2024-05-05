<template>
  <div class="quiz-form-container">
    <h1>Create a Quiz</h1>
    <form @submit.prevent="submitQuiz">
      <div>
        <label for="title">Title:</label>
        <input type="text" id="title" v-model="quiz.title" required>
      </div>
      <div>
        <label for="description">Description:</label>
        <input type="text" id="description" v-model="quiz.description" required>
      </div>

      <h2>Questions</h2>
      <div v-for="(question, qIndex) in quiz.questions" :key="qIndex">
        <label for="questionText">Question Text:</label>
        <input type="text" v-model="question.questionText" required>
        <label for="questionType">Question Type:</label>
        <input type="text" v-model="question.questionType" required>
        <button type="button" @click="addAnswer(qIndex)">Add Answer</button>
        <div v-for="(answer, aIndex) in question.answers" :key="aIndex">
          <label for="answerText">Answer Text:</label>
          <input type="text" v-model="answer.answerText" required>
          <label for="isCorrect">Is Correct:</label>
          <input type="checkbox" v-model="answer.isCorrect">
          <button type="button" @click="removeAnswer(qIndex, aIndex)">Remove Answer</button>
        </div>
        <button type="button" @click="removeQuestion(qIndex)">Remove Question</button>
      </div>
      <button type="button" @click="addQuestion">Add Question</button>
      <button type="submit">Submit Quiz</button>
    </form>
    <p v-if="message">{{ message }}</p>
  </div>
</template>

<script setup>
import { reactive, ref } from 'vue';
import axios from '../stores/axios.js';

const quiz = reactive({
  title: '',
  description: '',
  questions: []
});

const message = ref('');

function addQuestion() {
  quiz.questions.push({
    questionText: '',
    questionType: '',
    answers: []
  });
}

function addAnswer(qIndex) {
  quiz.questions[qIndex].answers.push({
    answerText: '',
    isCorrect: false
  });
}

function removeQuestion(qIndex) {
  quiz.questions.splice(qIndex, 1);
}

function removeAnswer(qIndex, aIndex) {
  quiz.questions[qIndex].answers.splice(aIndex, 1);
}

async function submitQuiz() {
  try {
    // Assuming the quiz is created and you have the quizID
    const quizResponse = await axios.post('https://localhost:7244/api/Quiz/CreateOneQuiz', {
      title: quiz.title,
      description: quiz.description
    });
    const quizID = quizResponse.data;
    for (const question of quiz.questions) {
      await axios.post('https://localhost:7244/api/Questions', {
        quizID: quizID,
        ...question
      });
    }
    message.value = 'Quiz and questions created successfully';
    quiz.title = '';
    quiz.description = '';
    quiz.questions = [];
  } catch (error) {
    message.value = 'Failed to create quiz and questions: ' + error.response.data;
  }
}
</script>

<style scoped>
.quiz-form-container {
  display: flex;
  flex-direction: column;
  align-items: center;
  padding: 20px;
}

.quiz-info {
  display: flex;
  flex-direction: column;
  gap: 10px;
  margin-bottom: 20px;
}

.questions-container {
  border: 1px solid #ddd;
  border-radius: 5px;
  padding: 10px;
  margin-bottom: 10px;
}

.question {
  display: flex;
  flex-direction: column;
  gap: 5px;
  margin-bottom: 10px;
}

.answers-container {
  display: flex;
  flex-direction: column;
  gap: 5px;
}

.answer {
  display: flex;
  align-items: center;
  gap: 5px;
}

button {
  padding: 5px 10px;
  border: 1px solid #ddd;
  border-radius: 3px;
  cursor: pointer;
}
</style>
