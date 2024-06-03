<script setup>
import { ref, reactive, onMounted } from 'vue';
import axios from '../stores/axios.js';
import { useRoute } from 'vue-router';
import {API_URL} from "@/stores/config.js";

const route = useRoute();
const quiz = reactive({
  title: '',
  description: ''
});
const questions = ref([]);
const loaded = ref(false);


const fetchQuestions = async () => {
  try {
    const quizId = route.params.id;
    const response = await axios.get(`${API_URL}/api/Questions/quiz/${quizId}/Question/GetAllQuestionsById`);
    questions.value = response.data;
    fetchQuizDetails(quizId);
  } catch (error) {
    console.error('Failed to fetch questions:', error);
    alert('Failed to load data.');
    loaded.value = false;
  }
};

const fetchQuizDetails = async (quizId) => {
  try {
    const response = await axios.get(`${API_URL}/api/Quiz/ReadOneQuiz/${quizId}`);
    quiz.title = response.data.title;
    quiz.description = response.data.description;
    loaded.value = true;
  } catch (error) {
    console.error('Failed to fetch quiz details:', error);
    alert('Failed to load quiz details.');
    loaded.value = false;
  }
};

const updateAll = async () => {
  try {
    await updateQuiz();
    for (let question of questions.value) {
      await updateQuestion(question);
    }
    alert('Quiz and all questions updated successfully!');
  } catch (error) {
    console.error('Failed to update quiz:', error);
    alert('Failed to update quiz.');
  }
};

const updateQuiz = async () => {
  try {
    const quizId = route.params.id;
    const quizData = {
      title: quiz.title,
      description: quiz.description
    };
    await axios.put(`${API_URL}/api/Quiz/UpdateOneQuiz/${quizId}`, quizData);
    console.log('Quiz updated successfully!');
  } catch (error) {
    console.error('Failed to update quiz:', error);
  }
};

const updateQuestion = async (question) => {
  const quizId = route.params.id;
  const questionData = {
    quizID: quizId,
    questionText: question.questionText,
    questionType: question.questionType,
    answers: question.answers.map(a => ({
      answerText: a.answerText,
      isCorrect: a.isCorrect
    }))
  };
  try {
    await axios.put(`${API_URL}/api/Questions/${question.questionID}`, questionData);
    console.log('Question updated successfully!');
  } catch (error) {
    console.error('Failed to update question:', error);
    alert('Failed to update question.');
  }
};

onMounted(fetchQuestions);
</script>

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
