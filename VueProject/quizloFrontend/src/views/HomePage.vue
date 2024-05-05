<template>
  <div class="big-word">
    <h1 class="fancy-font">Quizzes</h1>
    <br>
    <h1 class="text-center">
      <small class="text-body-secondary ms-auto">to learn, have fun and be attached</small>
    </h1>
    <br>
    <div class="d-flex justify-content-center">
      <router-link to="/login" class="btn btn-light mx-2 custom-btn" style="background-color: #60A1BC; color: white; border: none;">Click here to start your journey with us</router-link>
      <routerLink to="/aboutUs" class="btn btn-light mx-2 custom-btn" style="background-color: #60A1BC; color: white; border: none;">If you want to learn more, Click here</routerLink>
    </div>
  </div>
</template>

<script>
export default {
  // Your script setup goes here
};
</script>

<style scoped>


.fancy-font {
  font-family: 'Lobster', cursive; /* Use Lobster font */
  font-size: 6rem; /* Adjust the font size as needed */
  text-align: center;
  margin-top: 100px; /* Adjust the top margin as needed */
  color: #3C89AA; /* Adjust the font color as needed */
  /* Add any additional styling here to enhance the chic look */
}
.text-body-secondary {
  font-family: 'Lobster', cursive; /* Use Lobster font */
  font-size: 3rem; /* Adjust the font size as needed */
  color: #3e6d83 !important; /* Set the text color to blue */
  /* Add any additional styling here to enhance the chic look */
}


/* Adjustments for responsiveness */
@media (max-width: 768px) {
  .fancy-font {
    font-size: 4rem; /* Adjust font size for smaller screens */
  }
  .text-body-secondary {
    font-size: 2rem; /* Adjust font size for smaller screens */
  }
}

</style>
