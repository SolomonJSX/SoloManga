import React from 'react';
import {BASE_URL, USER_URL} from "@/repository/hosts";

interface IProfileBannerProps {
    bannerUrl?: string;
    onBannerChange?: (file: File) => void;
    children?: React.ReactNode;
}

const ProfileBanner = ({ bannerUrl, onBannerChange, children }: IProfileBannerProps) => {
    return (
        <div className={"relative h-56 w-full group"}>
            <img
                src={bannerUrl
                    ? `http://localhost:5190${bannerUrl}`
                    : "/no-image.png"}
                alt={"Banner"}
                className={"w-full h-full object-cover rounded-b-md"}
                />
            <div className={"absolute bottom-[-48px] left-6"}>
                {children}
            </div>
        </div>
    );
};

export default ProfileBanner;