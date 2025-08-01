interface IUserViewDto {
    id: number;
    username: string;
    email: string;
    role: "Admin" | "User";
    avatarUrl?: string;
    registrationDate: string;
    bio?: string;
    bannerUrl?: string;
}

export default IUserViewDto;