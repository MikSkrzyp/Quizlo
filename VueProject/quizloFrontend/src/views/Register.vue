<script setup>
import {ref, computed} from 'vue';

const firstName = ref('');
const lastName = ref('');
const email = ref('');
const password = ref('');
const errorMessage = ref('');

// Basic email validation
const isValidEmail = computed(() => {
  return /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/.test(email.value);
});

// Password must be at least 6 characters long
const isValidPassword = computed(() => {
  return password.value.length >= 6;
});

// Basic validation for first and last names
const isValidName = computed(() => {
  return firstName.value.trim().length > 0 && lastName.value.trim().length > 0;
});

const registerUser = async () => {
  if (!isValidName.value) {
    errorMessage.value = 'Please enter both first and last names.';
    return;
  }
  if (!isValidEmail.value) {
    errorMessage.value = 'Please enter a valid email address.';
    return;
  }
  if (!isValidPassword.value) {
    errorMessage.value = 'Password must be at least 6 characters long.';
    return;
  }

  const user = {
    firstName: firstName.value,
    lastName: lastName.value,
    email: email.value,
    password: password.value,
  };

  try {
    const response = await fetch('https://localhost:7244/api/Authentification/register', {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify(user),
    });

    if (response.ok) {
      alert('Registration successful! Redirecting to login...');
      window.location.href = '/'; // Adjust as needed for your routing
    } else {
      throw new Error('Failed to register');
    }
  } catch (error) {
    errorMessage.value = error.message || 'An error occurred during registration.';
  }
};
</script>

<template>
  <div class="container mt-5">
    <div class="row">
      <div class="col-md-6">
        <h1>Register</h1>
        <form @submit.prevent="registerUser">
          <div class="form-group">
            <label for="firstName">First Name</label>
            <input v-model="firstName" type="text" class="form-control" id="firstName" placeholder="Enter first name">
          </div>
          <div class="form-group">
            <label for="lastName">Last Name</label>
            <input v-model="lastName" type="text" class="form-control" id="lastName" placeholder="Enter last name">
          </div>
          <div class="form-group">
            <label for="email">Email address</label>
            <input v-model="email" type="email" class="form-control" id="email" placeholder="Enter email">
            <small id="emailHelp" class="form-text text-muted">We'll never share your email with anyone else.</small>
          </div>
          <div class="form-group">
            <label for="password">Password</label>
            <input v-model="password" type="password" class="form-control" id="password" placeholder="Password">
          </div>
          <div v-if="errorMessage">
            <p class="text-danger">{{ errorMessage }}</p>
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
