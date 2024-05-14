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

<template>
  <div class="container">
    <div class="row justify-content-center">
      <div class="col-md-8">
        <div class="quiz-form-container">
          <h1>Create a Quiz</h1>
          <form @submit.prevent="submitQuiz">
            <div class="mb-3">
              <label for="title" class="form-label">Title:</label>
              <input type="text" id="title" v-model="quiz.title" class="form-control" required>
            </div>
            <div class="mb-3">
              <label for="description" class="form-label">Description:</label>
              <input type="text" id="description" v-model="quiz.description" class="form-control" required>
            </div>

            <h2>Questions</h2>
            <div v-for="(question, qIndex) in quiz.questions" :key="qIndex" class="questions-container">
              <div class="question">
                <label for="questionText" class="form-label">Question Text:</label>
                <input type="text" v-model="question.questionText" class="form-control" required>
                <label for="questionType" class="form-label">Question Type:</label>
                <input type="text" v-model="question.questionType" class="form-control" required>
                <button type="button" class="btn btn-secondary" @click="addAnswer(qIndex)">Add Answer</button>
                <div v-for="(answer, aIndex) in question.answers" :key="aIndex" class="answers-container">
                  <div class="answer">
                    <label for="answerText" class="form-label">Answer Text:</label>
                    <input type="text" v-model="answer.answerText" class="form-control" required>
                    <label for="isCorrect" class="form-check-label">Is Correct:</label>
                    <input type="checkbox" v-model="answer.isCorrect" class="form-check-input">
                    <button type="button" class="btn btn-danger" @click="removeAnswer(qIndex, aIndex)">Remove Answer</button>
                  </div>
                </div>
                <button type="button" class="btn btn-danger" @click="removeQuestion(qIndex)">Remove Question</button>
              </div>
            </div>
            <button type="button" class="btn btn-primary" @click="addQuestion">Add Question</button>
            <button type="submit" class="btn btn-success">Submit Quiz</button>
          </form>
          <p v-if="message">{{ message }}</p>
        </div>
      </div>
    </div>
  </div>
</template>



<style scoped>
.quiz-form-container {
  display: flex;
  flex-direction: column;
  align-items: center;
  padding: 20px;
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
</style>
