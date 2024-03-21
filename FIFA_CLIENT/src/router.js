import { createRouter, createWebHistory } from 'vue-router'
import Index from '@/pages/index.vue'

const routes = [
    {
      path: '/',
      name: 'index',
      component: Index
    },
    {
      path: '/apropos',
      name: 'apropos',
      // route level code-splitting
      // this generates a separate chunk (About.[hash].js) for this route
      // which is lazy-loaded when the route is visited.
      component: () => import('@/pages/apropos.vue')
    },
    {
      path: '/produits',
      name: 'produits',
      // route level code-splitting
      // this generates a separate chunk (About.[hash].js) for this route
      // which is lazy-loaded when the route is visited.
      component: () => import('@/pages/produits.vue')
    }
  ];

export default createRouter({
    history: createWebHistory(),
    routes
});
