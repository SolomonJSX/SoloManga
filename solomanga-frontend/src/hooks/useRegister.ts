import {useMutation, useQueryClient} from "@tanstack/react-query";
import api from "@/lib/axios";
import {AUTH_LOGIN_URL, AUTH_REGISTER_URL} from "@/repository/hosts";

export function useRegister() {
    const queryClient = useQueryClient();

    return useMutation({
        mutationFn: async (form: { username: string; email: string; password: string }) => {
            const { data } = await api.post(AUTH_REGISTER_URL, form)
            localStorage.setItem("token", data.token)
        },
        onSuccess: () => {
            queryClient.invalidateQueries({ queryKey: ["user"] });
        }
    })
}