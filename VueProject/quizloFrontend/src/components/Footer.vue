<script setup>
// No JavaScript code is needed for this component
</script>

<template>
  <footer class="footer">
    <div class="container">
      <p>&copy; 2024 MyQuiz. All Rights Reserved.</p>
    </div>
  </footer>
</template>

<style scoped>
.footer {
  background-color: #bababa;
  padding: 20px 0;
  text-align: center;
  position: fixed;
  bottom: 0;
  width: 100%;
  z-index: 1000; /* Ensures it appears above other content */
  overflow-y: auto; /* Enables vertical scrolling */
  max-height: 200px; /* Adjust the maximum height as needed */
}
</style>