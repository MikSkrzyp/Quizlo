import { defineStore } from 'pinia'
import Cookies from 'js-cookie'
import axios from './axios'
import {jwtDecode} from 'jwt-decode'

export const useAuthStore = defineStore({
  id: 'auth',
  state: () => {
    const token = Cookies.get('token') || null;
    let user = null;
    if (token) {
      user = jwtDecode(token);
    }
    return {
      token: token,
      error: null,
      user: user,
    }
  },
  getters: {
    isAuthenticated(state) {
      return !!state.token
    },
    userName(state) {
      return state.user ? state.user.name : null
    },
    userRole(state) {
      return state.user ? state.user['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'] : null
    },
  },
  actions: {
    setToken(token) {
      this.token = token
      Cookies.set('token', token)
      if (token) {
        this.user = jwtDecode(token)
      } else {
        this.user = null
      }
    },
    clearToken() {
      this.token = null
      Cookies.remove('token')
      this.user = null
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
    logOut() {
      this.clearToken()
    },
  },
})