import React from 'react';

interface IProfileBannerProps {
    bannerUrl?: string;
    onBannerChange?: (file: File) => void;
    children?: React.ReactNode;
}

const ProfileBanner = ({ bannerUrl, onBannerChange, children }: IProfileBannerProps) => {
    return (
        <div className={"relative h-56 w-full group"}>
            <img
                src={bannerUrl || "/no-image.png"}
                alt={"Banner"}
                className={"w-full h-full object-contain rounded-b-md"}
                />
            <div className={"absolute bottom-[-48px] left-6"}>
                {children}
            </div>
        </div>
    );
};

export default ProfileBanner;