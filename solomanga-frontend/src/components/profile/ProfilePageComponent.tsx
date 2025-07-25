"use client"

import React from 'react';
import {useUser} from "@/hooks/useUser";
import ProfileSkeleton from "@/components/profile/ProfileSkeleton";
import {Tabs, TabsContent, TabsList, TabsTrigger} from "@/components/ui/tabs";
import AvatarUploader from "@/components/profile/AvatarUploader";
import ProfileBanner from "@/components/profile/ProfileBanner";

const ProfilePageComponent = () => {
    const { data: user, isLoading } = useUser()

    if (isLoading || !user) return <ProfileSkeleton />

    return (
        <div className="min-h-screen">
            {/* БАННЕР */}
            <ProfileBanner bannerUrl={undefined}>
                <AvatarUploader />
            </ProfileBanner>

            {/* Контент */}
            <div className="mt-16 p-6 grid grid-cols-1 md:grid-cols-3 gap-6 max-w-6xl mx-auto">
                {/* Левая колонка */}
                <div className="col-span-1 space-y-4">
                    <h2 className="text-xl font-bold">{user.username}</h2>
                    <p className="text-sm text-muted-foreground">{user.email}</p>
                    <p className="text-sm text-muted-foreground">
                        Дата регистрации: {new Date(user.registrationDate).toLocaleDateString()}
                    </p>
                    {/* Редактировать профиль */}
                    <button className="px-4 py-2 bg-zinc-700 text-white rounded hover:bg-zinc-600">
                        Редактировать профиль
                    </button>
                </div>

                {/* Правая колонка */}
                <div className="col-span-2">
                    <Tabs defaultValue="ratings" className="w-full">
                        <TabsList>
                            <TabsTrigger value="ratings">Оценки</TabsTrigger>
                            <TabsTrigger value="comments">Комментарии</TabsTrigger>
                        </TabsList>
                        <TabsContent value="ratings">
                            {/* Тут будут оценки пользователя */}
                            <div className="mt-4 text-muted-foreground">Пока нет оценок.</div>
                        </TabsContent>
                        <TabsContent value="comments">
                            {/* Тут будут комментарии */}
                            <div className="mt-4 text-muted-foreground">Пока нет комментариев.</div>
                        </TabsContent>
                    </Tabs>
                </div>
            </div>
        </div>
    );
};

export default ProfilePageComponent;