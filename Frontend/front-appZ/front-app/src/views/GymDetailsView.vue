<template>
    <div class="gym-details">
      <h1>{{ gym.Name }}</h1>
      <img :src="gym.ImagePath" alt="Gym Image">
      <p>{{ gym.Description }}</p>
      <p>Membership Price: {{ gym.MembershipPrice }} din.</p>
      <p>Location: {{ gym.Location }}</p>
    </div>
  </template>
  
  <script setup>
  import { ref, onMounted } from 'vue';
  import axios from 'axios';
  import { useRoute } from 'vue-router';
  
  const route = useRoute();
  const gym = ref({});
  
  onMounted(async () => {
    try {
      const response = await axios.get(`http://localhost:19132/api/gyms/${route.params.id}`);
      gym.value = response.data;
    } catch (error) {
      console.error('Error fetching gym details:', error);
    }
  });
  </script>
  
  <style scoped>
  .gym-details {
    padding: 20px;
    max-width: 600px;
    margin: auto;
  }
  
  .gym-details img {
    width: 100%;
    height: auto;
    border-radius: 5px;
  }
  </style>
  