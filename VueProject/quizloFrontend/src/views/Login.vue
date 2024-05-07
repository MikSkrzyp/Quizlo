<script setup>
import {ref} from 'vue';
import {useAuthStore} from '../stores/users'
import {useRouter} from 'vue-router'


const auth = useAuthStore()
const email = ref('');
const password = ref('');
const router = useRouter()

const attemptLogin = async () => {
  const success = await auth.login({email: email.value, password: password.value});
  if (success) {
    // Redirect to the profile view upon successful login
    await router.push('/profile')
  }
};

const register = async () => {
  await auth.register({email: email.value, password: password.value});
};
</script>

<template>
  <div class="container mt-5">
    <div class="row">
      <div class="col-md-6">
        <h1>Log in</h1>
        <form @submit.prevent="attemptLogin">
          <div class="form-group">
            <label for="email">Email address</label>
            <input v-model="email" type="email" class="form-control" id="email" aria-describedby="emailHelp"
                   placeholder="Enter email">
            <small id="emailHelp" class="form-text text-muted">We'll never share your email with anyone else.</small>
          </div>
          <div class="form-group">
            <label for="password">Password</label>
            <input v-model="password" type="password" class="form-control" id="password" placeholder="Password">
          </div>
          <button type="submit" class="btn btn-light mx-2 custom-btn"
                  style="background-color: #60A1BC; color: white; border: none;">Submit
          </button>
          <p v-if="auth.error" class="text-danger">{{ auth.error }}</p>
        </form>
      </div>
      <div class="col-md-6 d-flex flex-column justify-content-center align-items-center">
        <div>
          <br>
          <h6>If you haven't registered yet, please register first.</h6>
          <router-link to="/register" class="btn btn-light mx-2 custom-btn"
                       style="background-color: #60A1BC; color: white; border: none;">Register
          </router-link>
        </div>
      </div>
    </div>
  </div>
</template>

<style scoped>
/* Add your custom styles here */
</style>
