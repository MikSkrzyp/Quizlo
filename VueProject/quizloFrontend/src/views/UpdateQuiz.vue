<template>
  <div>
    <h1>Create Quiz</h1>
    <form @submit.prevent="submitForm">
      <div>
        <label for="title">Title:</label>
        <input id="title" v-model="quiz.title" type="text" required>
      </div>
      <div>
        <label for="description">Description:</label>
        <input id="description" v-model="quiz.description" type="text" required>
      </div>
      <button type="submit">Create Quiz</button>
    </form>
  </div>
</template>

<script>
import { ref } from 'vue'
import axios from 'axios'

export default {
  name: 'CreateQuiz',
  setup() {
    const quiz = ref({
      title: '',
      description: ''
    })

    const submitForm = async () => {
      try {
        const response = await axios.post('https://localhost:7244/api/Quiz/CreateOneQuiz', quiz.value)
        console.log(response.data)
        // Handle successful creation of the quiz
      } catch (error) {
        console.error(error)
        // Handle error in creating the quiz
      }
    }

    return {
      quiz,
      submitForm
    }
  }
}
</script>
