<template>
  <nav class="navbar navbar-dark navbar-expand-lg" style="background-color: #3C89AA;">
    <div class="container">
      <router-link class="navbar-brand" to="/">
        <!-- Large logo for desktop -->
        <img v-if="isDesktop" src="../images/quizlo-logo.png" id="quizlo-logo" alt="Quizlo Logo" style="width: 90px; height: auto;">
        <!-- Small logo for tablet and phone -->
        <img v-else src="../images/quizlo-logo.png" id="quizlo-logo" alt="Quizlo Logo" style="width: 60px; height: auto;">
      </router-link>
      <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
        <span class="navbar-toggler-icon"></span>
      </button>
      <div class="collapse navbar-collapse" id="navbarNav">
        <div class="navbar-nav ml-auto">
          <router-link  to="/" class="btn btn-light mx-2 custom-btn" style="background-color: #60A1BC; color: white; border: none;">Home Page</router-link>
          <routerLink to="/aboutUs" class="btn btn-light mx-2 custom-btn" style="background-color: #60A1BC; color: white; border: none;">About Us</routerLink>
          <router-link to="/login" class="btn btn-light mx-2 custom-btn" style="background-color: #60A1BC; color: white; border: none;">Log in / Register</router-link>
          <!-- Dark mode toggle button -->
          <button type="button" class="btn btn-outline-light" @click="toggleDarkMode">{{ darkModeText }}</button>
        </div>
      </div>
    </div>
  </nav>
</template>

<script setup>
import { ref, onMounted, computed } from 'vue';

const isDesktop = ref(window.innerWidth >= 992);
const darkMode = ref(localStorage.getItem('darkMode') === 'true');

const darkModeText = computed(() => darkMode.value ? 'Light Mode' : 'Dark Mode');

const toggleDarkMode = () => {
  darkMode.value = !darkMode.value;
  setDarkMode();
};

const setDarkMode = () => {
  if (darkMode.value) {
    document.body.classList.add('dark-mode');
    localStorage.setItem('darkMode', 'true');
  } else {
    document.body.classList.remove('dark-mode');
    localStorage.setItem('darkMode', 'false');
  }
};

onMounted(() => {
  window.addEventListener('resize', () => {
    isDesktop.value = window.innerWidth >= 992;
  });

  setDarkMode();
});
</script>

<style scoped>
/* Add your styles here */
</style>