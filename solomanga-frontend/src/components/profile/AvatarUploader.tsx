"use client"

import React, {ChangeEvent, useRef} from 'react';
import api from "@/lib/axios";
import {BASE_URL, USER_AVATAR_URL} from "@/repository/hosts";
import {useUser} from "@/hooks/useUser";
import {useMutation, useQueryClient} from "@tanstack/react-query";
import {Avatar, AvatarFallback, AvatarImage} from "@/components/ui/avatar";
import {useDeleteAvatar} from "@/hooks/useDeleteAvatar";
import {Trash} from "lucide-react";

interface IAvatarResponse {
    avatarUrl: string;
}

const AvatarUploader = () => {
    const fileInputRef = useRef<HTMLInputElement | null>(null)

    const { data: user } = useUser()
    const queryClient = useQueryClient();

    const uploadAvatar = useMutation({
        mutationFn: async (file: File) => {
            const formData = new FormData();
            formData.append('File', file);

            const response = await api.post<IAvatarResponse>(USER_AVATAR_URL, formData, {
                headers: {"Content-Type": "multipart/form-data" },
            })

            return response.data;
        },
        onSuccess: () => {
            queryClient.invalidateQueries({ queryKey: ["user"] })
        }
    })

    const handleAvatarClick = () => {
        fileInputRef.current?.click();
    }

    const handleFileChange = (event: ChangeEvent<HTMLInputElement>) => {
        const file = event.target.files?.[0]
        if (!file) return;

        uploadAvatar.mutate(file);
    }

    const deleteAvatar = useDeleteAvatar()

    return (
        <>
            <input
                type="file"
                accept="image/*"
                ref={fileInputRef}
                className="hidden"
                onChange={handleFileChange}
                />

            <div className="relative group w-24 h-24 md:w-36 md:h-36">
                <Avatar
                    className="w-full h-full cursor-pointer border-4 border-white bg-white shadow-lg"
                    onClick={handleAvatarClick}
                >
                    <AvatarImage
                        src={`http://localhost:5190${user?.avatarUrl}` || undefined}
                        className="w-full h-full object-cover"
                    />
                    <AvatarFallback className="text-xl font-bold">
                        {user?.username?.[0]?.toUpperCase() ?? "U"}
                    </AvatarFallback>
                </Avatar>

                {/* Иконка удаления */}
                {user?.avatarUrl && (
                    <button
                        className="absolute cursor-pointer bottom-1 right-1 p-1 bg-white rounded-full shadow-md text-red-500 hover:text-red-600 opacity-0 group-hover:opacity-100 transition"
                        onClick={(e) => {
                            e.stopPropagation()
                            deleteAvatar.mutate()
                        }}
                    >
                        <Trash size={16} />
                    </button>
                )}
            </div>
        </>
    );
};

export default AvatarUploader;