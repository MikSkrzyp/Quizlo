<script>
export default {

};
</script>
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



<style scoped>


.fancy-font {
  font-family: 'Lobster', cursive;
  font-size: 6rem;
  text-align: center;
  margin-top: 70px;
  color: #3C89AA;

}
.text-body-secondary {
  font-family: 'Lobster', cursive;
  font-size: 3rem;
  color: #3e6d83 !important;

}


/* Adjustments for responsiveness */
@media (max-width: 768px) {
  .fancy-font {
    font-size: 4rem;
  }
  .text-body-secondary {
    font-size: 2rem;
  }
}

</style>
