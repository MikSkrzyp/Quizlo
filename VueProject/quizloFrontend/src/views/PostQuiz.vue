<template>
  <div>
    <h1>Create Quiz</h1>
    <form @submit.prevent="handleSubmit">
      <label for="title">Title:</label>
      <input type="text" id="title" v-model="quiz.title" required>

      <label for="description">Description:</label>
      <textarea id="description" v-model="quiz.description" required></textarea>

      <button type="submit">Create Quiz</button>
    </form>
    <div v-if="error">{{ error }}</div>
  </div>
</template>

<script>
import { ref } from 'vue';
import axios from '../stores/axios.js'
 // Assuming you have axios installed

export default {
  setup() {
    const quiz = ref({ title: '', description: '' });
    const error = ref('');

    const handleSubmit = async () => {
      try {
        const response = await axios.post('https://localhost:7244/api/Quiz/CreateOneQuiz', quiz.value);
        // Handle successful quiz creation (e.g., redirect, display success message)
        console.log('Quiz created successfully:', response.data);
      } catch (error) {
        error.value = 'Error creating quiz: ' + error.message;
      }
    };

    return {
      quiz,
      error,
      handleSubmit,
    };
  },
};
</script>
