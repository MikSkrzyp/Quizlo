<script setup>
import {onMounted} from "vue"
import Nav from "./components/Nav.vue"
import Footer from "./components/Footer.vue"
import {RouterView} from "vue-router"
</script>

<template>
  <main>
    <Nav/>
    <RouterView/>
    <Footer/>
  </main>
</template>

<style scoped>

</style>
