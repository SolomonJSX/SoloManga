interface IUserViewDto {
    id: number;
    username: string;
    email: string;
    role: string;
    avatarUrl?: string;
    registrationDate: string;
}

export default IUserViewDto;