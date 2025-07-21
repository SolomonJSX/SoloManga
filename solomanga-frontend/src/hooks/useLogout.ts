import {useQueryClient} from "@tanstack/react-query";
import {useRouter} from "next/navigation";

export function useLogout() {
    const queryClient = useQueryClient();
    const router = useRouter();

    return () => {
        localStorage.removeItem("token")

        // ✅ Принудительно обнуляем данные
        queryClient.setQueryData(["user"], null)

        // ✅ Удаляем кэш
        queryClient.removeQueries({ queryKey: ["user"], exact: true })
    }
}