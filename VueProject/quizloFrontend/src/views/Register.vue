<script setup>
import { ref } from 'vue';

const email = ref('');
const password = ref('');

const registerUser = () => {
  console.log('Registering user with email:', email.value);
  console.log('Password:', password.value);
  // Implement your user registration logic here
  // After registering user, you might want to redirect them to another page
  // Example: window.location.href = 'login.html';
};
</script>

<template>
  <div class="container mt-5">
    <div class="row">
      <div class="col-md-6">
        <h1>Register</h1>
        <form @submit.prevent="registerUser">
          <div class="form-group">
            <label for="email">Email address</label>
            <input v-model="email" type="email" class="form-control" id="email" aria-describedby="emailHelp" placeholder="Enter email">
            <small id="emailHelp" class="form-text text-muted">We'll never share your email with anyone else.</small>
          </div>
          <div class="form-group">
            <label for="password">Password</label>
            <input v-model="password" type="password" class="form-control" id="password" placeholder="Password">
          </div>
          <button type="submit" class="btn btn-primary">Register</button>
        </form>
      </div>
    </div>
  </div>
</template>

<style scoped>
/* Add your custom styles here */
</style>