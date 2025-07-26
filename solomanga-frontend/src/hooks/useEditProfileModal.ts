import {create} from "zustand/react";

type EditProfileModalStore = {
    isOpen: boolean;
    open: () => void;
    close: () => void;
}

const useEditProfileModal = create<EditProfileModalStore>((set) => ({
    isOpen: false,
    open: () => set({ isOpen: true }),
    close: () => set({ isOpen: false }),
}))

export default useEditProfileModal;