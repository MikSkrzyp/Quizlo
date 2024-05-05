<template>
  <div>
    <h1>User List</h1>
    <ul>
      <li v-for="user in users" :key="user.id">
        {{ user.firstName }} {{ user.lastName }}
        <button @click="deleteUser(user.id)">Delete</button>
      </li>
    </ul>
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

<style scoped>
li {
  margin-bottom: 10px;
}
button {
  margin-left: 10px;
}
</style>
