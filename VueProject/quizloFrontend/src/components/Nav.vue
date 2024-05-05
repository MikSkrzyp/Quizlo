<template>
  <nav class="navbar navbar-dark navbar-expand-lg" style="background-color: #3C89AA;">
    <div class="container">
      <router-link class="navbar-brand" to="/">
        <!-- Large logo for desktop -->
        <img v-if="isDesktop" src="../images/quizlo-logo.png" id="quizlo-logo" alt="Quizlo Logo" style="width: 90px; height: auto;">
        <!-- Small logo for tablet and phone -->
        <img v-else src="../images/quizlo-logo.png" id="quizlo-logo" alt="Quizlo Logo" style="width: 60px; height: auto;">
      </router-link>
      <button class="navbar-toggler" type="button" @click="toggleNavbar" aria-expanded="false" aria-label="Toggle navigation">
        <span class="navbar-toggler-icon"></span>
      </button>
      <div :class="['collapse', 'navbar-collapse', { 'show': isNavbarOpen }]" id="navbarNav">

      <div class="navbar-nav ms-auto">
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
import { ref, computed } from 'vue';

const isDesktop = ref(window.innerWidth >= 992);
const isNavbarOpen = ref(false);
const darkMode = ref(localStorage.getItem('darkMode') === 'true');

const darkModeText = computed(() => darkMode.value ? 'Light Mode' : 'Dark Mode');

const toggleNavbar = () => {
  isNavbarOpen.value = !isNavbarOpen.value;
};

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

window.addEventListener('resize', () => {
  isDesktop.value = window.innerWidth >= 992;
});

setDarkMode();
</script>

<style scoped>
@media (max-width: 991.98px) {
  .navbar-nav.ms-auto {
    margin-top: 40px; /* Adjust the margin-top value as needed */
  }
}
.btn-outline-light:hover {
  background-color: #fff;
  color: #3C89AA;
}
.custom-btn {
  transition: transform 0.3s ease;
}
.custom-btn:hover {
  transform: scale(1.1);
}

</style>