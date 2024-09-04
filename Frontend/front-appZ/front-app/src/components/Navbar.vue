<template>
    <nav class="navbar">
      <div class="container">
        <div class="brand">
          <!-- <h1 style="color: rgba(240, 240, 240,1);">FitnessHub</h1> -->
        </div>
        <button class="signin-btn" @click="goToLogin">Sign in</button>
      </div>
    </nav>
  </template>


<script setup>
import { useRouter } from 'vue-router';

const router = useRouter();

const goToLogin = () => {
  router.push({ name: 'login' });
};
</script>
  
  <style scoped>
  .navbar {
    background-color: rgba(49, 49, 49, 0.7); /* Transparent gray */
    padding: 10px;
  }
  
  .container {
    display: flex;
    justify-content: space-between;
    align-items: center;
  }
  
  .signin-btn {
    background-color: transparent;
    border: 2px solid white;
    margin-top: 8px;
    color: white;
    padding: 10px 20px;
    cursor: pointer;
  }
  
  .signin-btn:hover {
    background-color: white;
    color: black;
  }
  </style>
  