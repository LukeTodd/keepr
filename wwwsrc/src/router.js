import Vue from 'vue'
import Router from 'vue-router'
// @ts-ignore
import Home from './views/Home.vue'
// @ts-ignore
import Login from './views/Login.vue'
// @ts-ignore
import MyKeeps from './views/MyKeeps.vue'
// @ts-ignore
import MyVaults from './views/MyVaults.vue'
// @ts-ignore
import ActiveVault from './views/ActiveVault'


Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      name: 'home',
      component: Home
    },
    {
      path: '/login',
      name: 'login',
      component: Login
    },
    {
      path: '/mykeeps',
      name: 'myKeeps',
      component: MyKeeps
    },
    {
      path: '/myvaults',
      name: 'myVaults',
      component: MyVaults
    },
    {
      path: '/myvault/:id',
      name: 'activeVault',
      component: ActiveVault
    }
  ]
})
