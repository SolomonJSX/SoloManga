import {useQuery} from "@tanstack/react-query";
import api from "@/lib/axios";
import {CURRENT_USER_URL} from "@/repository/hosts";
import UserViewDto from "@/types/userViewDto";

export function useUser() {
    return useQuery<UserViewDto | null>({
        queryKey: ["user"],
        queryFn: async () => {
            const token = localStorage.getItem("token")
            if (!token) return null
            const { data } = await api.get<UserViewDto>(CURRENT_USER_URL)
            return data
        },
        staleTime: 1000 * 60 * 10,
        gcTime: 0, // 💥 очистит кэш мгновенно
    })
}
