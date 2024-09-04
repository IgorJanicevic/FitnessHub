<template>
  <footer class="footer">
    <div class="left-section">
      <h2>FitnessHub</h2>
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
    background-color: rgba(49, 49, 49, 0.5); /* Transparent gray */
  color: white;
  padding: 17px;
  display: flex;
  justify-content: space-between;
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
