"use client"

import React, {ChangeEvent, useRef} from 'react';
import {useAuth} from "@/hooks/useAuth";
import api from "@/lib/axios";
import {USER_AVATAR_URL} from "@/repository/hosts";

interface IAvatarResponse {
    avatarUrl: string;
}

const Avatar = () => {
    const fileInputRef = useRef<HTMLInputElement | null>(null)
    const { user, setUser } = useAuth()

    const handleAvatarClick = () => {
        fileInputRef.current?.click()
    }

    // const handleFileChange = async (e: ChangeEvent<HTMLInputElement>) => {
    //     const file = e.target.files?.[0]
    //     if (!file) return;
    //
    //     try {
    //         const formData = new FormData();
    //         formData.append('File', file);
    //
    //         const res = await api.post<IAvatarResponse>(USER_AVATAR_URL, formData, {
    //             headers: {
    //                 'Content-Type': 'multipart/form-data'
    //             }
    //         })
    //
    //         const newAvatarUrl = res.data;
    //         await setUser()
    //     }
    // }

    return (
        <div>

        </div>
    );
};

export default Avatar;