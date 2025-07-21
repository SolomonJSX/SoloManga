"use client"

import React, {useEffect} from 'react';
import {useAuth} from "@/stores/useAuth";
import {useRouter} from "next/navigation";

interface IProps {
    children: React.ReactNode;
}

const ProtectedRoute = ({ children }: IProps) => {
    const {user, setUser} = useAuth()
    const router = useRouter();

    useEffect(() => {
        const token = localStorage.getItem("token");
        if (!token) {
            router.push("/auth/login");
            return;
        }

        if (!user) {
            setUser(token)
        }
    }, [user])

    if (!user) return null

    console.log(user)

    return (
        <>
            {children}
        </>
    );
};

export default ProtectedRoute;