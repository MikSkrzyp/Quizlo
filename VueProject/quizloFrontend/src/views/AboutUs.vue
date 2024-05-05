<script setup>

</script>

<template>

  <!-- Your About Us content goes here -->
  <div class="container mt-5">
    <h1 class="fancy-font">About Us</h1>

  </div>

  <div class="container text-center" style="padding-top: 20px">
    <div class="row align-items-start">
      <div class="col">

        <div id="carouselExampleControls" class="carousel slide" data-bs-ride="carousel">
          <div class="carousel-inner">
            <div class="carousel-item active">
              <img src="../images/mikolaj.jpg" class="d-block w-50 w-50 mx-auto" alt="...">
              <div class="carousel-caption d-none d-md-block text-shadow-bottom">

                <p>Mikołaj.</p>
              </div>
            </div>
            <div class="carousel-item">
              <img src="../images/oskar.jpg" class="d-block w-50 w-50 mx-auto" alt="...">
              <div class="carousel-caption d-none d-md-block text-shadow-bottom">

                <p>Oskar.</p>
              </div>
            </div>
            <div class="carousel-item">
              <img src="../images/olaa.jpg" class="d-block w-50 w-50 mx-auto" alt="...">
              <div class="carousel-caption d-none d-md-block text-shadow-bottom">

                <p>Ola.</p>
              </div>
            </div>
          </div>
          <button class="carousel-control-prev" type="button" data-bs-target="#carouselExampleControls" data-bs-slide="prev">
            <span class="carousel-control-prev-icon" aria-hidden="true"></span>
            <span class="visually-hidden">Previous</span>
          </button>
          <button class="carousel-control-next" type="button" data-bs-target="#carouselExampleControls" data-bs-slide="next">
            <span class="carousel-control-next-icon" aria-hidden="true"></span>
            <span class="visually-hidden">Next</span>
          </button>
        </div>


      </div>
      <div class="col">
        <br>
        <p>We are three passionate students dedicated to revolutionizing the learning experience. Our innovative quiz app enables users to learn anytime, anywhere, making education accessible and enjoyable. With interactive features and engaging content, we aim to inspire curiosity and foster a love for learning in our users. Our mission is to empower individuals to expand their knowledge effortlessly while having fun along the way. Join us on this exciting journey to redefine education!</p>
      </div>
    </div>
  </div>

    <!-- Bootstrap Carousel -->

</template>

<style scoped>
.fancy-font {
  font-family: 'Lobster', cursive; /* Use Lobster font */
  font-size: 6rem; /* Adjust the font size as needed */
  text-align: center;
  margin-top: 50px; /* Adjust the top margin as needed */
  color: #3C89AA; /* Adjust the font color as needed */
  /* Add any additional styling here to enhance the chic look */
}

@media (max-width: 768px) {
  .fancy-font {
    font-size: 4rem; /* Adjust font size for smaller screens */
  }
}
.text-shadow-bottom {
  position: absolute;
  bottom: 0;
  width: 100%;
  text-align: center;
  text-shadow: 4px 4px 8px rgba(0, 0, 0, 0.7); /* Add shadow to text */
}
</style>

