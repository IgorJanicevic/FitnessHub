<template>
  <footer class="footer">
    <div class="left-section">
      <img src="../assets/LogoFooter.png" alt="logo" width="400" height="50">
    </div>
    <div class="right-section">
      <div class="column">
        <h3>About Us</h3>
        <p>Your Fitness</p>
        <p>Why FitnessHub</p>
        <p>Workout Tips</p>
      </div>
      <div class="column">
        <h3>Connection</h3>
        <p>Instagram</p>
        <p>Facebook</p>
      </div>
      <div class="column">
        <h3>More</h3>
        <p>Shop</p>
        <p>Careers</p>
        <p>News</p>
      </div>
    </div>
  </footer>
</template>

<style scoped>
.footer {
  background-color: #333;
  color: white;
  padding: 17px;
  display: flex;
  justify-content: space-between;
  position: relative; /* Isto kao za Navbar */
  z-index: 5; /* Ispod Navbara, ali iznad pozadine */
}

.left-section h2 {
  margin-left: 3%;
  justify-content: center;
  vertical-align:middle;
  font-size: 44px;
}

.right-section {
  display: flex;
  justify-content: space-between;
  margin-right: 3%;
}

.column {
  margin-right: 20px;
}

.column h3 {
  margin-bottom: 10px;
}
</style>
