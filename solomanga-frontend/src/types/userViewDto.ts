interface IUserViewDto {
    id: number;
    username: string;
    email: string;
    role: string;
    avatarUrl?: string;
    registrationDate: string;
    bio?: string;
    bannerUrl?: string;
}

export default IUserViewDto;