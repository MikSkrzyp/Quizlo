<template>
  <div>
    <h1>Quiz Updater</h1>
    <input v-model="quizId" placeholder="Enter Quiz ID" />
    <button @click="fetchQuestions">Load Quiz</button>
    <div v-if="loaded">
      <div>
        <h2>Quiz Details</h2>
        <input v-model="quiz.title" placeholder="Quiz Title" />
        <textarea v-model="quiz.description" placeholder="Quiz Description"></textarea>
      </div>
      <div v-for="(question, index) in questions" :key="question.questionID">
        <h3>Question {{ index + 1 }}</h3>
        <input v-model="question.questionText" placeholder="Question Text" />
        <input v-model="question.questionType" placeholder="Question Type" />
        <div v-for="(answer, aIndex) in question.answers" :key="aIndex">
          <input v-model="answer.answerText" placeholder="Answer Text" />
          <label><input type="checkbox" v-model="answer.isCorrect"> Correct Answer</label>
        </div>
      </div>
      <button @click="updateAll">Update All</button>
    </div>
  </div>
</template>

<script>
import axios from 'axios';

export default {
  data() {
    return {
      quizId: '',
      quiz: {
        title: '',
        description: ''
      },
      questions: [],
      loaded: false
    };
  },
  methods: {
    async fetchQuestions() {
      try {
        const response = await axios.get(`https://localhost:7244/api/Questions/quiz/${this.quizId}/Question/GetAllQuestionsById`);
        this.questions = response.data; // Assuming this is the structure provided by the GET endpoint
        this.loaded = true;
      } catch (error) {
        console.error('Failed to fetch questions:', error);
        alert('Failed to load data.');
        this.loaded = false;
      }
    },
    async updateAll() {
      await this.updateQuiz();
      for (let question of this.questions) {
        await this.updateQuestion(question);
      }
      alert('Quiz and all questions updated successfully!');
    },
    async updateQuiz() {
      try {
        const quizData = {
          title: this.quiz.title,
          description: this.quiz.description
        };
        await axios.put(`https://localhost:7244/api/Quiz/UpdateOneQuiz/${this.quizId}`, quizData);
        console.log('Quiz updated successfully!');
      } catch (error) {
        console.error('Failed to update quiz:', error);
        alert('Failed to update quiz.');
      }
    },
    async updateQuestion(question) {
      const questionData = {
        quizID: this.quizId, // Assuming you need to send the quizID with the question update
        questionText: question.questionText,
        questionType: question.questionType,
        answers: question.answers.map(a => ({
          answerText: a.answerText,
          isCorrect: a.isCorrect
        }))
      };
      try {
        await axios.put(`https://localhost:7244/api/Questions/${question.questionID}`, questionData);
        console.log('Question updated successfully!');
      } catch (error) {
        console.error('Failed to update question:', error);
      }
    }
  }
};
</script>
