"use client"

import React, {useState} from 'react';
import {useForm} from "react-hook-form";
import {RegisterForm, registerSchema} from "@/types/registerDto";
import {zodResolver} from "@hookform/resolvers/zod";
import axios from "axios";
import AuthResponseType from "@/types/authResponseType";
import {AUTH_LOGIN_URL, AUTH_REGISTER_URL} from "@/repository/hosts";
import {Form, FormControl, FormField, FormItem, FormLabel, FormMessage} from "@/components/ui/form";
import {Input} from "@/components/ui/input";
import {Button} from "@/components/ui/button";
import Link from "next/link";
import {useRouter} from "next/navigation";
import {useRegister} from "@/hooks/useRegister";

const RegisterPage = () => {
    const form = useForm<RegisterForm>({
        resolver: zodResolver(registerSchema),
        defaultValues: {
            username: "",
            email: "",
            password: ""
        }
    })

    const router = useRouter();

    const register = useRegister()

    const [error, setError] = useState("")

    const onSubmit = async (values: RegisterForm) => {
        setError("")
        register.mutate(values, {
            onSuccess: () => {
                router.push("/")
            },
            onError: (error: any) => {
                const message =
                    error.response?.data?.message ??
                    error.response?.statusText ??
                    "Произошла ошибка входа"
                setError(message)
            }
        })
    }

    return (
        <div className="mx-auto mt-10 w-full max-w-sm px-2">
            <h1 className="text-2xl font-bold mb-6">Вход</h1>
            <Form {...form}>
                <form onSubmit={form.handleSubmit(onSubmit)} className={"space-y-6"}>
                    <FormField
                        control={form.control}
                        render={({field}) => (
                            <FormItem>
                                <FormLabel>Имя пользователя</FormLabel>
                                <FormControl>
                                    <Input placeholder={"Имя пользователя"} {...field} />
                                </FormControl>
                            </FormItem>
                        )}
                        name={"username"}
                    />

                    <FormField
                        control={form.control}
                        render={({field}) => (
                            <FormItem>
                                <FormLabel>Email</FormLabel>
                                <FormControl>
                                    <Input placeholder={"email"} {...field} />
                                </FormControl>
                            </FormItem>
                        )}
                        name={"email"}
                    />

                    <FormField
                        control={form.control}
                        name="password"
                        render={({field}) => (
                            <FormItem>
                                <FormLabel>Пароль</FormLabel>
                                <FormControl>
                                    <Input type="password" placeholder="Пароль" {...field} />
                                </FormControl>
                                <FormMessage/>
                            </FormItem>
                        )}
                    />

                    {error && <p className={"text-red-600 text-sm"}>{error}</p>}
                    <Button type={"submit"} className={"w-full cursor-pointer"}>Войти</Button>

                    <p className={"text-sm text-center text-muted-foreground"}>
                        Уже есть аккаунт?{" "}
                        <Link href={"/auth/login"} className={"text-primary hover:underline"}>
                            Войдите
                        </Link>
                    </p>
                </form>
            </Form>
        </div>
    )};

export default RegisterPage;