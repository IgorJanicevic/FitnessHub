<script setup>
import CreateWorkoutAI from '@/components/CreateWorkoutAI.vue';
import Navbar from '@/components/Navbar.vue';
import Footer from '@/components/Footer.vue';

</script>

<template>
  <main>
    <Navbar/>
    <CreateWorkoutAI />
  </main>
</template>

<style scoped>

main {
  background-image: url('@/assets/background.jpg');
  background-size:  cover;
  background-position: center;
  background-repeat: no-repeat;
  background-attachment: fixed;
  min-height: 100vh; /* Osigurava da pokrije najmanje visinu prozora */
  display: flex;
  flex-direction: column;
  justify-content: space-between;
}
</style>