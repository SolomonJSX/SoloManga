import axios from "axios";
import {BASE_URL} from "@/repository/hosts";

const api = axios.create({
    baseURL: BASE_URL,
    withCredentials: true
})

api.interceptors.request.use((config) => {
    const token = localStorage.getItem("token")
    if (token) {
        config.headers.Authorization = `Bearer ${token}`
    }

    return config
})

api.interceptors.response.use(
    (res) => res,
    (err) => {
        console.log("API ERROR:", err)
        return Promise.reject(err)
    }
)

export default api;