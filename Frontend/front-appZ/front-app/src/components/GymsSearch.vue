<template>
    <div class="search-section">
      <div class="search-container">
        <input type="text" placeholder="Enter location" v-model="location" id="locationInput">
        <button @click="searchGyms">Search</button>
      </div>
      <div class="gyms-container">
        <div v-for="gym in gyms" :key="gym.Id" class="gym-card" @click="gotoGymDetails(gym.Id)">
          <img :src="gym.ImagePath" alt="Gym Image">
          <p class="gym-name">{{ gym.Name }}</p>
          <p class="gym-price">Clanarina: {{ gym.MembershipPrice }} din.</p>
        </div>
      </div>
    </div>
  </template>
  
  <script setup>
  import { ref } from 'vue';
  import axios from 'axios';
  import router from '@/router';
  const imagePath='https://i.postimg.cc/h4QGnP9T/image.png'
  
  const location = ref('');
  const gyms = ref([]);

  const gotoGymDetails = (gymId) => {
    router.push({ name: 'GymDetails', params: { id: gymId } });
}

  
  const searchGyms = async () => {
    try {
      const response = await axios.get(`http://localhost:19132/api/gyms`, {
        params: { location: location.value }
      });
      gyms.value = response.data;
    } catch (error) {
      console.error('Error fetching gyms:', error);
    }
  }
  

  </script>
  
  <style scoped>
  .search-section {
    width: 50%;
    background-color: rgba(153, 151, 151, 0.2);
    padding: 20px;
    margin-left: 1%;
    border-radius: 10px;
    height: 52vh;
    box-shadow: 0 4px 8px rgba(0, 0, 0, 0.8);
  }
  
  .search-container {
    display: flex;
    justify-content: space-between;
    margin-bottom: 20px;
  }
  
  input[type="text"] {
    width: 60%;
    padding: 10px;
    border-radius: 5px;
    border: 1px solid #aaaaaa;
    margin-right: 10px;
    font-size: 16px;
  }
  
  button {
    padding: 10px 20px;
    background-color: #4CAF50;
    color: white;
    border: none;
    margin-right: 8px;
    border-radius: 5px;
    cursor: pointer;
    font-size: 16px;
    transition: background-color 0.3s ease;
  }
  
  button:hover {
    background-color: #45a049;
  }
  
  .gyms-container {
    display: grid;
    grid-template-columns: repeat(4, 1fr);
    grid-auto-rows: 95%;
    gap: 20px;
    height: 45vh;
    overflow-y: scroll;
    padding-right: 10px; /* Dodato zbog skrola */
  }
  
  
  /* Sakrivanje skrol bara */
  .gyms-container::-webkit-scrollbar {
    display: none; /* Sakriva skrol bar u WebKit pretraživačima (Chrome, Safari) */
  }
  
  .gym-card {
    margin: 8px;
    background-color: #fff;
    width: 100%;
    height: 90%;
    border-radius: 6px;
    box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
    text-align: center;
    cursor: pointer;
  }
  
  .gym-card img {
    width: 100%;
    height: 70%;
    border-radius: 5px;
  }
  
  .gym-card:hover {
    transform: scale(1.05);
    box-shadow: 0 4px 8px rgba(0, 0, 0, 0.2);
  }

  .gym-name {
    margin: 10px 0;
    font-size: 18px;
    font-weight: bold;
    vertical-align: bottom;
  }
  
  .gym-price {
    font-size: 16px;
    vertical-align: bottom;
  }
  </style>
  