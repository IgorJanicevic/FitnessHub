import { createRouter, createWebHashHistory } from 'vue-router';
import WelcomeView from '@/views/WelcomeView.vue';
import LoginView from '@/views/LoginView.vue';
import RegisterView from '@/views/RegisterView.vue';
import GymDetailsView from '@/views/GymDetailsView.vue';
import CreateWorkoutAIView from '@/views/CreateWorkoutAIView.vue';


const routes = [
  {
    path: "/",
    name: "welcome",
    component: WelcomeView,
  },
  {
    path: '/login',
    name: 'login',
    component: LoginView
  },
  {
    path: '/register',
    name: 'register',
    component: RegisterView
  },
  {
    path: '/gym/:id',
    name: 'GymDetails',
    component: GymDetailsView,
    props: true

  },
  {
    path: "/ai",
    name: "AI",
    component: CreateWorkoutAIView,
  },
];

const router = createRouter({
  history: createWebHashHistory(),
  routes
})

export default router
