<template>
  <div class="container mt-5">
    <div class="row justify-content-center">
      <div class="col-md-6">
        <div class="card">
          <div class="card-body">
            <h1 class="card-title text-center mb-4">User Profile</h1>
            <div class="text-center mb-4">
              <img :src="photoURL || 'path/to/default/photo.jpg'" alt="User Photo" class="img-fluid rounded-circle" style="width: 200px;">
            </div>
            <div class="mb-3">
              <input type="file" @change="handlePhotoUpload" class="form-control">
            </div>
            <button @click="logout" class="btn btn-danger btn-block">Log out</button>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { useAuthStore } from "@/stores/users.js";

export default {
  computed: {
    photoURL() {
      return useAuthStore().photoURL;
    }
  },
  methods: {
    async handlePhotoUpload(event) {
      const file = event.target.files[0];
      try {
        const url = URL.createObjectURL(file);
        useAuthStore().setPhotoURL(url);
      } catch (error) {
        console.error('Error uploading photo:', error);
      }
    },
    logout() {
      try {
        useAuthStore().clearToken();
        this.$router.push('/login');
      } catch (error) {
        console.error('Error logging out:', error);
      }
    }
  }
}
</script>

<style>
/* No additional custom styles needed */
</style>
