<template>
  <div>
    <h1>Create Quiz</h1>
    <form @submit.prevent="handleSubmitQuiz">
      <label for="title">Title:</label>
      <input type="text" id="title" v-model="quiz.title" required>

      <label for="description">Description:</label>
      <textarea id="description" v-model="quiz.description" required></textarea>

      <button type="submit">Create Quiz</button>
    </form>

    <h2>Add Questions</h2>
    <form @submit.prevent="handleSubmitQuestion">
      <label for="questionText">Question Text:</label>
      <input type="text" id="questionText" v-model="question.questionText" required>

      <label for="questionType">Question Type:</label>
      <input type="text" id="questionType" v-model="question.questionType" required>

      <div v-for="(answer, index) in question.answers" :key="index">
        <label :for="'answerText' + index">Answer Text:</label>
        <input :id="'answerText' + index" v-model="answer.answerText" required>

        <label :for="'isCorrect' + index">Is Correct:</label>
        <input type="checkbox" :id="'isCorrect' + index" v-model="answer.isCorrect">
      </div>

      <button type="button" @click="addAnswer">Add Answer</button>
      <button type="submit">Add Question</button>
    </form>

    <div v-if="error">{{ error }}</div>
  </div>
</template>

<script>
import { ref } from 'vue';
import axios from '../stores/axios.js'

export default {
  setup() {
    const quiz = ref({ title: '', description: '' });
    const question = ref({ quizID: 0, questionText: '', questionType: '', answers: [{ answerText: '', isCorrect: false }] });
    const error = ref('');

    const handleSubmitQuiz = async () => {
      try {
        const response = await axios.post('https://localhost:7244/api/Quiz/CreateOneQuiz', quiz.value);
        console.log('Quiz created successfully:', response.data);
        question.value.quizID = response.data; // Assuming the response contains the created quiz ID
      } catch (error) {
        error.value = 'Error creating quiz: ' + error.message;
      }
    };

    const handleSubmitQuestion = async () => {
      if (!question.value.quizID) {
        error.value = 'Quiz has not been created yet. Please create the quiz first.';
        return;
      }
      try {
        const response = await axios.post('https://localhost:7244/api/Questions', question.value);
        console.log('Question added successfully:', response.data);
      } catch (error) {
        error.value = 'Error adding question: ' + error.message;
      }
    };

    const addAnswer = () => {
      question.value.answers.push({ answerText: '', isCorrect: false });
    };

    return {
      quiz,
      question,
      error,
      handleSubmitQuiz,
      handleSubmitQuestion,
      addAnswer,
    };
  },
};
</script>