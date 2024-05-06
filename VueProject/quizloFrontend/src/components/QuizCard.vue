<script setup xmlns="http://www.w3.org/1999/html">
import {defineProps} from "vue"
import {useRouter} from "vue-router"

const router = useRouter()
const {quiz,index} = defineProps(['quiz','index'])


const navigateToQuiz = () => {
  router.push(`/quiz/${quiz.quizID}`)
}
</script>

<template>
<div @click="navigateToQuiz">
  <h1>{{quiz.title}}</h1>
  <h2>{{quiz.description}}</h2>
  <h7>quiz id:{{quiz.quizID}}</h7>
</div>
  <br/>
</template>

<style scoped>
h2{
  font-size: 20px;
}

</style>