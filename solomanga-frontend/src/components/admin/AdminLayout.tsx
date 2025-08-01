"use client"

import React from 'react'
import {AdminSidebar} from "@/components/admin/AdminSidebar";
import {useUser} from "@/hooks/useUser";

const links = [
    {href: "/admin", label: "Главная"},
    {href: "/admin/manga", label: "Манга"},
    // Добавь при необходимости
];

export const AdminLayout = ({ children}: { children: React.ReactNode }) => {
    const { data: user, isLoading } = useUser()

    if (isLoading) return null

    if (!user || user.role !== "Admin") {
        return (
            <div className="min-h-screen bg-white flex items-center justify-center text-black text-xl font-semibold">
                Access Denied
            </div>
        )
    }

    return (
        <div className={"flex min-h-screen"}>
            <AdminSidebar links={links}/>
            <main className={"flex bg-zinc-100 p-6 overflow-y-auto"}>
                {children}
            </main>
        </div>
    )
}
