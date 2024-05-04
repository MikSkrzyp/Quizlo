import axios from 'axios'
import Cookies from 'js-cookie'

console.log('Script started') // Log at the start of the script

const instance = axios.create()

// Request interceptor
instance.interceptors.request.use((config) => {
    console.log('Interceptor called') // Log when the interceptor is called

    // Get the JWT token from the cookie
    const token = Cookies.get('token')

    // If the token exists, add it to the headers
    if (token) {
        console.log('Token exists')
        config.headers.Authorization = `Bearer ${token}`
    } else {
        console.log('Token does not exist') // Log when the token does not exist
    }

    console.log('Request was sent')
    console.info(config)

    return config
})

// Response interceptor
instance.interceptors.response.use((response) => {
    // Handle the response here
    return response
}, (error) => {
    // Handle errors here
    console.error(error)
    return Promise.reject(error)
})

export default instance