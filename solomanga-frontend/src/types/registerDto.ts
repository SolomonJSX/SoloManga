import {z} from "zod";

export const registerSchema = z.object({
    username: z.string().min(2, { message: "Введите имя" }),
    email: z.string().min(2, { message: "Введите логин или email" }),
    password: z.string().min(6, { message: "Минимум 6 символов" })
})

export type RegisterForm = z.infer<typeof registerSchema>;