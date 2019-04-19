import Vue from 'vue'
import Vuex from 'vuex'
import Axios from 'axios'
import router from './router'

Vue.use(Vuex)

let baseUrl = location.host.includes('localhost') ? '//localhost:5000/' : '/'

let auth = Axios.create({
  baseURL: baseUrl + "account/",
  timeout: 3000,
  withCredentials: true
})

let api = Axios.create({
  baseURL: baseUrl + "api/",
  timeout: 3000,
  withCredentials: true
})

export default new Vuex.Store({
  state: {
    user: {},
    keeps: [],
    vaults: [],
    vaultKeeps: []
  },
  mutations: {
    setUser(state, user) {
      state.user = user
    },
    setKeeps(state, data) {
      state.keeps = data
    },
    setVaults(state, data) {
      state.vaults = data
    },
    addKeep(state, payload) {
      state.keeps.push(payload)
    },
    addVault(state, payload) {
      state.vaults.push(payload)
    },
    setVaultKeep(state, payload) {
      state.vaultKeeps = payload
    },
    addVaultKeep(state, payload) {
      state.vaultKeeps = payload
    }
  },
  actions: {
    //#region -- AUTH STUFF
    register({ commit, dispatch }, newUser) {
      auth.post('register', newUser)
        .then(res => {
          commit('setUser', res.data)
          router.push({ name: 'home' })
        })
        .catch(e => {
          console.log('[registration failed] :', e)
        })
    },
    authenticate({ commit, dispatch }) {
      auth.get('authenticate')
        .then(res => {
          commit('setUser', res.data)
          router.push({ name: 'home' })
        })
        .catch(e => {
          console.log('not authenticated')
        })
    },
    login({ commit, dispatch }, creds) {
      auth.post('login', creds)
        .then(res => {
          commit('setUser', res.data)
          router.push({ name: 'home' })
        })
        .catch(e => {
          console.log('Login Failed')
        })
    },
    logout({ commit, dispatch }, payload) {
      auth.delete('logout')
        .then(res => {
          router.push({ name: 'login' })
        })
    },
    //#endregion
    //#region - KEEPS
    getAllKeeps({ commit, dispatch }, payload) {
      api.get("keeps")
        .then(res => {
          commit('setKeeps', res.data)
        })
    },
    getKeepsByUser({ commit, dispatch }) {
      api.get("Keeps/user")
        .then(res => {

          commit('setKeeps', res.data)
        })
    },
    createKeep({ commit, dispatch }, payload) {
      api.post('keeps', payload)
        .then(res => {
          commit('addKeep', res.data)
        })
    },
    deleteKeep({ commit, dispatch }, payload) {
      api.delete('keeps/' + payload)
        .then(res => {
          dispatch('getKeepsByUser', res.data)
        })
    },
    //#endregion
    //#region -- Vaults
    getVaultsByUser({ commit, dispatch }, payload) {
      api.get("vault/user")
        .then(res => {
          commit('setVaults', res.data)
        })
    },
    createVault({ commit, dispatch }, payload) {
      api.post('vault', payload)
        .then(res => {
          commit('addVault', res.data)
        })
    },
    deleteVault({ commit, dispatch }, payload) {
      api.delete('vault/' + payload)
        .then(res => {
          dispatch('getVaultsByUser', res.data)
        })
    },
    //#endregion
    //#region -- VaultKeeps
    getVaultKeeps({ commit, dispatch }, payload) {
      api.get('vaultkeep/' + payload)
        .then(res => {
          commit('setVaultKeep', res.data)
        })
    },
    deleteVaultKeeps({ commit, dispatch }, payload) {
      api.delete('vaultkeep/' + payload.vaultId + '/keep/' + payload.keepId)
        .then(res => {
          dispatch('getVaultKeeps', payload.vaultId)
        })
    },
    createVaultKeep({ commit, dispatch }, payload) {
      api.post('vaultkeep', payload)
        .then(res => {
          commit('addVaultKeep', res.data)
        })
    }

    //#endregion
  }
})
