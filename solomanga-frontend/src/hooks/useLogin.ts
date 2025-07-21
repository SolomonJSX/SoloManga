import {useMutation, useQueryClient} from "@tanstack/react-query";
import api from "@/lib/axios";
import {AUTH_LOGIN_URL} from "@/repository/hosts";

export function useLogin() {
    const queryClient = useQueryClient();

    return useMutation({
        mutationFn: async (form: { login: string; password: string }) => {
            const { data } = await api.post(AUTH_LOGIN_URL, form)
            localStorage.setItem("token", data.token)
        },
        onSuccess: () => {
            queryClient.invalidateQueries({ queryKey: ["user"] });
        }
    })
}