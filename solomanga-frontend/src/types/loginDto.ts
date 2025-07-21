import {z} from "zod";

export const loginSchema = z.object({
    login: z.string().min(2, { message: "Введите логин или email" }),
    password: z.string().min(6, { message: "Минимум 6 символов" })
})

export type LoginForm = z.infer<typeof loginSchema>;