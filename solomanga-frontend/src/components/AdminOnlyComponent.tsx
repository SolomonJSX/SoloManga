"use client"

import { useUser } from '@/hooks/useUser'
import React from 'react'

interface AdminOnlyComponentProps {
    children: React.ReactNode;
}

export const AdminOnlyComponent = ({ children }: AdminOnlyComponentProps) => {
    const { data: user, isLoading } = useUser()

    if (isLoading) return <div>Loading...</div>

    if (!user || user.role !== 'Admin') {
        return <div>Access Denied</div>
    }

    return (
        <>
        {children}
        </>
  )
}
