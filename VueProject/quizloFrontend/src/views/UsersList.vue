<script setup>
import { ref, onMounted } from 'vue';
//import axios from 'axios';
import axios from '../stores/axios.js';
import {API_URL} from "@/stores/config.js";
const users = ref([]);


const fetchUsers = async () => {
  try {
    const response = await axios.get(`${API_URL}/api/User/ReadAllUsers`);
    users.value = response.data;
    //filter not to show admin
    users.value = users.value.filter(user => user.id !== 'admin-user-id');
  } catch (error) {
    console.error('Failed to fetch users:', error);
    alert('Failed to load users.');
  }
};

const deleteUser = async (userId) => {
  try {
    await axios.delete(`${API_URL}/api/User/DeleteOneUser/${userId}`);
    users.value = users.value.filter(user => user.id !== userId);
    alert('User deleted successfully');
  } catch (error) {
    console.error('Failed to delete user:', error);
    alert('Failed to delete user.');
  }
};

onMounted(fetchUsers);
</script>

<template>
  <div>
    <h1>User List</h1>
    <table class="table">
      <thead>
      <tr>
        <th scope="col">number</th>
        <th scope="col">First Name</th>
        <th scope="col">Last Name</th>
        <th scope="col">Actions</th>
      </tr>
      </thead>
      <tbody class="table-group-divider">
      <tr v-for="(user, index) in users" :key="user.id">
        <th scope="row">{{ index + 1 }}</th>
        <td>{{ user.firstName }}</td>
        <td>{{ user.lastName }}</td>
        <td>
          <button @click="deleteUser(user.id)" class="btn btn-danger">Delete</button>
        </td>
      </tr>
      </tbody>
    </table>
  </div>
</template>



<style scoped>
</style>
