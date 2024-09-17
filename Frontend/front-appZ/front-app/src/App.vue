<template>
  <div id="app">
    <Navbar />
    <router-view/>
    <Footer />
  </div>
</template>

<script>
import Navbar from '@/components/Navbar.vue'; // Importuješ Navbar komponentu
import Footer from './components/Footer.vue';

export default {
  components: {
    Navbar, // Dodaj Navbar kao komponentu
    Footer,
  },
};
</script>

<style>
html, body {
  height: 100%;
  margin: 0;
  padding: 0;
  overflow-x: hidden; /* Sprečava horizontalni scroll u slučaju širih elemenata */
}

#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #333;
}
</style>
