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

<script>
import axios from 'axios';

export default {
  data() {
    return {
      users: []
    };
  },
  mounted() {
    this.fetchUsers();
  },
  methods: {
    async fetchUsers() {
      try {
        const response = await axios.get('https://localhost:7244/api/User/ReadAllUsers');
        this.users = response.data;
      } catch (error) {
        console.error('Failed to fetch users:', error);
        alert('Failed to load users.');
      }
    },
    async deleteUser(userId) {
      try {
        await axios.delete(`https://localhost:7244/api/User/DeleteOneUser/${userId}`);
        this.users = this.users.filter(user => user.id !== userId);
        alert('User deleted successfully');
      } catch (error) {
        console.error('Failed to delete user:', error);
        alert('Failed to delete user.');
      }
    }
  }
};
</script>

