'use client'

import {z} from "zod"
import {useForm} from "react-hook-form";
import {LoginForm, loginSchema} from "@/types/loginDto";
import {zodResolver} from "@hookform/resolvers/zod";
import {useState} from "react";
import {Form, FormControl, FormField, FormItem, FormLabel, FormMessage} from "@/components/ui/form";
import {Input} from "@/components/ui/input";
import {Button} from "@/components/ui/button";
import axios from "axios";
import AuthResponseType from "@/types/authResponseType";
import {AUTH_LOGIN_URL} from "@/repository/hosts";
import Link from "next/link";
import {useRouter} from "next/navigation";
import {useAuth} from "@/stores/useAuth";

export default function LoginPage() {
    const form = useForm<LoginForm>({
        resolver: zodResolver(loginSchema),
        defaultValues: {
            login: "",
            password: ""
        }
    })

    const router = useRouter();

    const { setUser } = useAuth()

    const [error, setError] = useState("")

    const onSubmit = async (values: LoginForm) => {
        try {
            const response = await axios.post<AuthResponseType>(AUTH_LOGIN_URL, values)
            localStorage.setItem("token", response.data.token)
            setUser(response.data.token)
            router.push("/")
        } catch (error: any) {
            const message =
                error.response?.data ??           // из тела ответа
                error.response?.statusText ??     // или статус
                "Произошла ошибка регистрации"

            setError(message)
        }
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
                                <FormLabel>Логин или Email</FormLabel>
                                <FormControl>
                                    <Input placeholder={"username или email"} {...field} />
                                </FormControl>
                            </FormItem>
                        )}
                        name={"login"}
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
                        Нет аккаунта?{" "}
                        <Link href={"/auth/register"} className={"text-primary hover:underline"}>
                            Зарегистрируйтесь
                        </Link>
                    </p>
                </form>
            </Form>
        </div>
    )
}
