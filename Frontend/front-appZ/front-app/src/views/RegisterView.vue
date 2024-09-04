<template>
    <div class="login-container">
      <div class="login-box">
        <h1 style="color: white;">Register</h1>
        <form @submit.prevent="registerUser">
          <div class="input-group">
            <label for="username">Username:</label>
            <input type="text" v-model="newUser.Username" required>
          </div>
          <div class="input-group">
            <label for="email">Email:</label>
            <input type="email" v-model="newUser.Email" required>
          </div>
          <div class="input-group">
            <label for="password">Password:</label>
            <input type="password" v-model="newUser.Password" required>
          </div>
          <div class="input-group">
            <label for="password">Confirm password:</label>
            <input type="password" id="confPassword" v-model="confirmedPassword" required>
          </div>
          <button type="submit" style="margin-top: 3%;">Register</button>
        </form>
        <p class="register-link" style="margin-top: 5%; margin-bottom: -5px;">
           Already have an account? <a @click="toLogin">Login</a>
        </p>
      </div>
    </div>
  </template>
  
  <script setup>
  import { ref } from 'vue';
  import { useRouter } from 'vue-router';
  import axios from 'axios';
  
  const confirmedPassword = ref('');
  const router = useRouter();
  const message = ref('');
  const newUser = ref({
    Username: '',
    Email: '',
    Password: '',        
  });

  const registerUser = async() => {
  if (newUser.value.Password !== confirmedPassword.value) {
    alert('Passwords do not match');
    return;
  }

  axios.post('http://localhost:19132/api/users/register', {
    Username: newUser.value.Username,
    Email: newUser.value.Email,
    Password: newUser.value.Password
  }).then(response => {
    alert('Register successful!');
    // Sačuvaj token u localStorage
    localStorage.setItem('token', response.data.Token);
    // Prebaci korisnika na početnu stranicu (Welcome)
    router.push({ name: 'welcome'});
      }).catch(error => {
    alert('Registration failed: ' + error.response.data);
  });
};
  
  const toLogin = () => {
    router.push({ name: 'login' }); // Pretpostavljam da imaš rutu za registraciju
  };
  </script>
  
  <style scoped>
  .login-container {
    background-image: url('@/assets/background.jpg');
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
  