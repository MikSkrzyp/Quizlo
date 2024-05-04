import { defineStore } from 'pinia'
import Cookies from 'js-cookie'
import axios from './axios'

export const useAuthStore = defineStore({
  id: 'auth',
  state: () => ({
    token: Cookies.get('token') || null,
    error: null,
  }),
  getters: {
    isAuthenticated(state) {
      return !!state.token
    },
  },
  actions: {
    setToken(token) {
      this.token = token
      Cookies.set('token', token)
    },
    clearToken() {
      this.token = null
      Cookies.remove('token')
    },
    async login(credentials) {
      try {
        const response = await axios.post('https://localhost:7244/api/Authentification/login', credentials)
        if (response.status !== 200) {
          throw new Error('Bad credentials')
        }
        this.setToken(response.data.token)
        return true
      } catch (error) {
        this.error = error.message
        return false
      }
    },
    async register(userDetails) {
      try {
        const response = await axios.post('https://localhost:7244/api/Authentification/register', userDetails)
        if (response.status !== 200) {
          throw new Error('Registration failed')
        }
        this.setToken(response.data.token)
        return true
      } catch (error) {
        this.error = error.message
        return false
      }
    },
    // ... other actions ...
  },
})