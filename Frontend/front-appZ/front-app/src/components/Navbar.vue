<template>
  <nav class="navbar">
    <div class="container">
      <div class="brand">
        <!-- <h1 style="color: rgba(240, 240, 240,1);">FitnessHub</h1> -->
      </div>
      
      <ul class="nav-links">
        <li><img src="../assets/LogoNavbar4.png" alt="Logo" width="180" height="20"></li>
        <li><a @click="goToHome">Home</a></li>
        <li><a href="#">Start Training</a></li>
        <li><a @click="goToAi">Get Plan</a></li>
        <li><a href="#">Contact</a></li>
      </ul>

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

const goToAi = () => {
  router.push({ name: 'ai' });
};

const goToHome = () => {
  router.push({ name: 'welcome' });
};

</script>
  
  <style scoped>
  .navbar {
    background-color: #333; 
    padding: 10px;
    position: relative; /* Da bi z-index funkcionisao */
    z-index: 10; /* Visok z-index da se osigura da bude iznad drugih elemenata */
  }

  .container {
  display: flex;
  justify-content: flex-start;
  align-items: center;
}

.nav-links {
  list-style-type: none;
  display: flex;
  gap: 1.5rem; 
  margin: 0;
  padding: 0;
  margin-right: auto; 
}


.nav-links li {
  display: inline-block; 
}

.nav-links li a {
  color: white;
  text-decoration: none;
  font-size: 1.2rem;
}

.nav-links li a:hover {
  color: #ccc;
}

.signin-btn {
  background-color: #333; 
  color: #fff; 
  border: 2px solid #fff; 
  padding: 0.5rem 1rem;
  cursor: pointer;
}

.signin-btn:hover {
  background-color: #444; 
  border-color: #ccc; 
}
</style>