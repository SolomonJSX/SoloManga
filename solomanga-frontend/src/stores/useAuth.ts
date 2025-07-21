import {create} from "zustand/react";
import IUserViewDto from "@/types/userViewDto";
import axios from "axios";
import {CURRENT_USER_URL} from "@/repository/hosts";

interface IAuthState {
    user: IUserViewDto | null;
    setUser: (token: string) => void;
    logout: () => void;
}

export const useAuth = create<IAuthState>((set) => ({
    user: null,
    setUser: async (token: string) => {
        try {
            const response = await axios.get<IUserViewDto>(CURRENT_USER_URL, {
                headers: {
                    Authorization: `Bearer ${token}`,
                }
            });
            console.log(response.data);
            let { id, email, role, username, avatarUrl, registrationDate} = response.data;

            set({
                user: {
                    id,
                    email,
                    role,
                    username,
                    avatarUrl,
                    registrationDate,
                }
            })
        } catch (e) {
            console.error("Invalid token")
            set({ user: null })
        }
    },
    logout: () => {
        localStorage.removeItem('token')
        set({ user: null })
    }
}))