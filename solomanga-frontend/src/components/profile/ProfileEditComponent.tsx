"use client"

import React, {use, useEffect, useState} from 'react';
import useEditProfileModal from "@/hooks/useEditProfileModal";
import {useUser} from "@/hooks/useUser";
import {useMutation, useQueryClient} from "@tanstack/react-query";
import {useForm} from "react-hook-form";
import api from "@/lib/axios";
import {USER_BANNER_URL, USER_URL} from "@/repository/hosts";
import IUserViewDto from "@/types/userViewDto";
import {Dialog, DialogContent, DialogHeader, DialogTitle} from "@/components/ui/dialog";
import {Label} from "@/components/ui/label";
import {Input} from "@/components/ui/input";
import {Textarea} from "@/components/ui/textarea";
import {Button} from "@/components/ui/button";

interface IUserEditDto {
    username?: string;
    bio?: string;
}

const ProfileEditComponent = () => {
    const { isOpen,close } = useEditProfileModal()
    const { data: user } = useUser()
    const queryClient = useQueryClient()
    const [bannerFile, setBannerFile] = useState<File | null>(null)
    const [previewUrl, setPreviewUrl] = useState<string | null>(null)

    const {
        register,
        handleSubmit,
        formState: { isSubmitting },
        reset
    } = useForm<IUserEditDto>({
        defaultValues: {
            username: user?.username ?? "",
            bio: user?.bio ?? ""
        }
    })

    useEffect(() => {
        if (user) {
            reset({
                username: user.username,
                bio: user.bio
            })
        }
    }, [user, reset]);

    const updateUserMutation = useMutation({
        mutationFn: async (data: IUserEditDto) => {
            const res = await api.put<IUserViewDto>(USER_URL, data)
            return res.data
        }
    })

    const uploadBannerMutation = useMutation({
        mutationFn: async (file: File) => {
            const formData = new FormData();
            formData.append("file", file)
            const res = await api.post<string>(USER_BANNER_URL, formData, {
                headers: {
                    "Content-Type": "multipart/form-data"
                }
            })
            return res.data
        }
    })

    const onSubmit = async (data: IUserEditDto) => {
        try {
            await updateUserMutation.mutateAsync(data)
            if (bannerFile) {
                await uploadBannerMutation.mutateAsync(bannerFile)
            }
            await queryClient.invalidateQueries({ queryKey: ["user"] })
            setPreviewUrl(null)
            setBannerFile(null)
            close()
        } catch (e) {
            console.error("Ошибка при обновлении: ", e)
        }
    }


    const deleteBannerMutation = useMutation({
        mutationFn: async () => {
            await api.delete(USER_BANNER_URL)
            await queryClient.invalidateQueries({ queryKey: ["user"] })
        }
    })

    return (
        <Dialog open={isOpen} onOpenChange={close}>
            <DialogContent className="sm:max-w-[425px] w-[95%]">
                <DialogHeader>
                    <DialogTitle>Редактировать профиль</DialogTitle>
                </DialogHeader>

                <form onSubmit={handleSubmit(onSubmit)} className={"space-y-4 px-1"}>
                    <div className="space-y-1">
                        <Label>Имя пользователя</Label>
                        <Input {...register("username")} placeholder={"Имя"} />
                    </div>

                    <div className="space-y-1">
                        <Label>О себе</Label>
                        <Textarea {...register("bio")} placeholder={"Расскажите о себе"} />
                    </div>

                    <div className="space-y-1">
                        <Label>Баннер</Label>
                        <Input
                            type="file"
                            accept="image/*"
                            onChange={(e) => {
                                const file = e.target.files?.[0]
                                if (file) {
                                    setBannerFile(file)
                                    setPreviewUrl(URL.createObjectURL(file))
                                }
                            }}
                            className={"cursor-pointer"}
                        />

                        {previewUrl && (
                            <img
                                src={previewUrl}
                                alt="Превью баннера"
                                className="w-full h-32 object-cover rounded-md border"
                            />
                        )}

                        {user?.bannerUrl && !previewUrl && (
                            <Button
                                type="button"
                                variant="destructive"
                                className="cursor-pointer w-full justify-center"
                                size="sm"
                                onClick={async () => {
                                    try {
                                        await deleteBannerMutation.mutateAsync()
                                        await queryClient.invalidateQueries({ queryKey: ["user"] })
                                        setBannerFile(null)
                                        setPreviewUrl(null)
                                        close()
                                    } catch (e) {
                                        console.error("Ошибка при удалении баннера", e)
                                    }
                                }}
                            >
                                Удалить баннер
                            </Button>
                        )}
                    </div>


                    <div className="flex flex-col sm:flex-row justify-end gap-2">
                        <Button className={"cursor-pointer"} type={"submit"} disabled={isSubmitting}>
                            Сохранить
                        </Button>
                        <Button className={"cursor-pointer"} type={"button"} variant={"ghost"} onClick={() => close()}>Отмена</Button>
                    </div>
                </form>
            </DialogContent>
        </Dialog>
    );
};

export default ProfileEditComponent;