<template>
  <div>
    <h1>Delete Quiz</h1>
    <input v-model="quizId" type="text" placeholder="Enter Quiz ID to delete" />
    <button @click="deleteQuiz">Delete Quiz</button>
    <p v-if="errorMessage">{{ errorMessage }}</p>
  </div>
</template>

<script>
import { ref } from 'vue';
import axios from 'axios'
export default {
  setup() {
    const quizId = ref('');
    const errorMessage = ref('');

    const deleteQuiz = async () => {
      if (!quizId.value) {
        errorMessage.value = 'Please enter a valid Quiz ID.';
        return;
      }

      try {
        await axios.delete(`https://localhost:7244/api/Quiz/DeleteOneQuiz/${quizId.value}`);
        alert('Quiz successfully deleted!');
        quizId.value = ''; // Reset the input after deletion
      } catch (error) {
        errorMessage.value = 'Failed to delete the quiz: ' + error.message;
      }
    };

    return {
      quizId,
      deleteQuiz,
      errorMessage
    };
  }
};
</script>

<style scoped>
/* Add some basic styling */
input[type="text"] {
  margin: 10px 0;
  padding: 8px;
  border: 1px solid #ccc;
  border-radius: 4px;
}

button {
  padding: 10px 20px;
  background-color: #007bff;
  color: white;
  border: none;
  border-radius: 4px;
  cursor: pointer;
}

button:hover {
  background-color: #0056b3;
}

p {
  color: red;
}
</style>
