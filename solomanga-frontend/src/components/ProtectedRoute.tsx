'use client'

import { useRouter } from 'next/navigation'
import { useEffect } from 'react'
import { useUser } from '@/hooks/useUser'

interface IProps {
    children: React.ReactNode
}

const ProtectedRoute = ({ children }: IProps) => {
    const router = useRouter()
    const { data: user, isLoading, isError } = useUser()

    useEffect(() => {
        const token = localStorage.getItem('token')
        if (!token || isError) {
            router.push('/auth/login')
        }
    }, [isError])

    if (isLoading) return null // или спиннер

    if (!user) return null

    return <>{children}</>
}

export default ProtectedRoute
