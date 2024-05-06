<template>
  <div class="container">
    <h1 class="mt-4">Quiz Updater</h1>
    <div v-if="loaded" class="mt-4">
      <div class="card">
        <div class="card-body">
          <h2 class="card-title">Quiz Details</h2>
          <input v-model="quiz.title" class="form-control mb-3" placeholder="Quiz Title" />
          <textarea v-model="quiz.description" class="form-control" placeholder="Quiz Description"></textarea>
        </div>
      </div>
      <div class="mt-4" v-for="(question, index) in questions" :key="question.questionID">
        <div class="card">
          <div class="card-body">
            <h3 class="card-title">Question {{ index + 1 }}</h3>
            <input v-model="question.questionText" class="form-control mb-3" placeholder="Question Text" />
            <input v-model="question.questionType" class="form-control mb-3" placeholder="Question Type" />
            <div v-for="(answer, aIndex) in question.answers" :key="aIndex">
              <input v-model="answer.answerText" class="form-control mb-2" placeholder="Answer Text" />
              <div class="form-check">
                <input type="checkbox" class="form-check-input" v-model="answer.isCorrect" :id="'checkbox-' + aIndex" />
                <label class="form-check-label" :for="'checkbox-' + aIndex">Correct Answer</label>
              </div>
            </div>
          </div>
        </div>
      </div>
      <button @click="updateAll" class="btn btn-primary mt-4">Update All</button>
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
        const quizId = this.$route.params.id;
        const response = await axios.get(`https://localhost:7244/api/Questions/quiz/${quizId}/Question/GetAllQuestionsById`);
        this.questions = response.data;
        this.loaded = true;
        this.quizId = quizId; // Set the quizId retrieved from route params
      } catch (error) {
        console.error('Failed to fetch questions:', error);
        alert('Failed to load data.');
        this.loaded = false;
      }
    },
    async updateAll() {
      try {
        await this.updateQuiz();
        for (let question of this.questions) {
          await this.updateQuestion(question);
        }
        alert('Quiz and all questions updated successfully!');
      } catch (error) {
        console.error('Failed to update quiz:', error);
        alert('Failed to update quiz.');
      }
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
        quizID: this.quizId,
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
        alert('Failed to update question.');
      }
    }
  },
  mounted() {
    this.fetchQuestions(); // Call fetchQuestions method on component mount
  }
};
</script>
