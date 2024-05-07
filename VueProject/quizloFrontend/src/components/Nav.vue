<template>
  <div>
    <nav class="navbar navbar-dark navbar-expand-lg fixed-top" style="background-color: #3C89AA; margin-top: 0; width: 100%;">
      <div class="container-fluid">
        <router-link class="navbar-brand" to="/homePage">
          <!-- Large logo for desktop -->
          <img v-if="isDesktop" src="../images/quizlo-logo.png" id="quizlo-logo" alt="Quizlo Logo" style="width: 120px; height: auto;">
          <!-- Small logo for tablet and phone -->
          <img v-else src="../images/quizlo-logo.png" id="quizlo-logo" alt="Quizlo Logo" style="width: 80px; height: auto;">
        </router-link>
        <button class="navbar-toggler" type="button" @click="toggleNavbar" aria-expanded="false" aria-label="Toggle navigation">
          <span class="navbar-toggler-icon"></span>
        </button>
        <div :class="['collapse', 'navbar-collapse', { 'show': isNavbarOpen }]" id="navbarNav">
          <div class="navbar-nav ms-auto">
            <router-link v-if="authStore.isAuthenticated && authStore.userRole==='Admin'" to="/users" class="btn btn-light mx-2 custom-btn" style="background-color: #60A1BC; color: white; border: none;">Users</router-link>
            <router-link  to="/homePage" class="btn btn-light mx-2 custom-btn" style="background-color: #60A1BC; color: white; border: none;">Home Page</router-link>
            <router-link  to="/" class="btn btn-light mx-2 custom-btn" style="background-color: #60A1BC; color: white; border: none;">Quizzes</router-link>
            <router-link to="/aboutUs" class="btn btn-light mx-2 custom-btn" style="background-color: #60A1BC; color: white; border: none;">About Us</router-link>
            <template v-if="authStore.isAuthenticated">
              <!-- Change router link to UserProfile -->
              <router-link to="/profile" class="btn btn-light mx-2 custom-btn" style="background-color: #60A1BC; color: white; border: none;">User Profile</router-link>
            </template>
            <template v-else>
              <router-link to="/login" class="btn btn-light mx-2 custom-btn" style="background-color: #60A1BC; color: white; border: none;">Log in / Register</router-link>
            </template>
            <!-- Dark mode toggle button -->
            <button type="button" class="btn btn-outline-light" @click="toggleDarkMode">{{ darkModeText }}</button>
          </div>
        </div>
      </div>
    </nav>

    <!-- Add padding to the top of the content area -->
    <div style="padding-top: 80px;">
      <!-- Your content here -->
    </div>
  </div>
</template>

<script setup>

import {useAuthStore} from "@/stores/users.js";

const authStore = useAuthStore();
import {ref, computed} from 'vue';

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
/* Add padding to create space between navbar and content below */
.navbar {
  padding-bottom: 20px; /* Adjust as needed */
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
