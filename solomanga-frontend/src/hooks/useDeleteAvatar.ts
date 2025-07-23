import {useMutation, useQueryClient} from "@tanstack/react-query";
import api from "@/lib/axios";
import {USER_AVATAR_URL} from "@/repository/hosts";

export function useDeleteAvatar() {
    const queryClient = useQueryClient();

    return useMutation({
        mutationFn: async () => {
            await api.delete(USER_AVATAR_URL)
        },
        onSuccess: () => {
            queryClient.invalidateQueries({queryKey: ["user"]})
        }
    })
}