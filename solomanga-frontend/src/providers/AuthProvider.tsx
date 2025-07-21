// src/providers/AuthProvider.tsx
"use client"

import { useEffect } from "react"
import {useAuth} from "@/hooks/useAuth";

export default function AuthProvider({ children }: { children: React.ReactNode }) {
    const { setUser } = useAuth()

    useEffect(() => {
        const token = localStorage.getItem("token")
        if (token) {
            setUser(token)
        }
    }, [])

    return <>{children}</>
}
