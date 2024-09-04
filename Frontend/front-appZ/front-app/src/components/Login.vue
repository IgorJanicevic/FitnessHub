<template>
    <div class="login-container">
      <div class="login-box">
        <h1 style="color: white;">Login</h1>
        <form @submit.prevent="loginUser">
          <div class="input-group">
            <label for="email">Email:</label>
            <input type="email" id="email" v-model="email" required>
          </div>
          <div class="input-group">
            <label for="password">Password:</label>
            <input type="password" id="password" v-model="password" required>
          </div>
          <button type="submit">Login</button>
        </form>
        <p class="register-link">
          Don't have an account yet? <a @click="goToRegister">Register now</a>
        </p>
      </div>
    </div>
  </template>
  
  <script setup>
  import { ref } from 'vue';
  import { useRouter } from 'vue-router';
  import axios from 'axios';
  
  const email = ref('');
  const password = ref('');
  const router = useRouter();
  const message= ref('');
  
  const loginUser = async() => {
    alert(`Email: ${email.value}, Password: ${password.value}`);

    axios.post('http://localhost:19132/api/users/login', {
        Email: email.value,
        Password: password.value
      }).then(response=>{
        console.log('eee');
        alert('Login successful!');
      // Preusmeri korisnika na drugu stranicu ako je login uspešan
      //router.push('/dashboard'); // Ili neka druga ruta
        
      });
    // Nakon uspešne prijave, možeš preusmeriti korisnika na početnu stranicu
  };
  
  const goToRegister = () => {
    router.push({ name: 'register' }); // Pretpostavljam da imaš rutu za registraciju
  };
  </script>
  
  <style scoped>
  .login-container {
    background-image: url("C:/Users/HomePC/Desktop/backgr.jpg");
    background-size: cover;
    background-position: center;
    height: 100vh;
    display: flex;
    justify-content: center;
    align-items: center;
  }
  
  .login-box {
    background-color: rgba(49, 49, 49, 0.9); /* Transparent gray */
    padding: 40px;
    border-radius: 10px;
    box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
    text-align: center;
    width: 330px;
  }
  
  .input-group {
    padding-left: 5%;
    padding-right: 5%;
    margin-bottom: 15px;
    text-align: left;
  }
  
  label {
    display: block;
    margin-bottom: 5px;
    color: white;
  }
  
  input {
    width: 100%;
    padding: 8px;
    border-radius: 5px;
    border: 1px solid #ccc;
    margin-bottom: 10px;
  }
  
  button {
    width: 50%;
    padding: 10px;
    margin-left: 15%;
    margin-right: 15%;
    background-color: #4CAF50;
    color: white;
    border: none;
    border-radius: 8px;
    cursor: pointer;
    font-size: 16px;
  }
  
  button:hover {
    background-color: #45a049;
  }
  
  .register-link {
    margin-top: 10px;
    color: white;
  }
  
  .register-link a {
    color: #FFD700; /* Zlatna boja za link */
    text-decoration: underline;
    cursor: pointer;
  }
  </style>
  