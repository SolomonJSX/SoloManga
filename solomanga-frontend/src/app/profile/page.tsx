import React from 'react';
import ProtectedRoute from "@/components/ProtectedRoute";
import ProfilePageComponent from "@/components/profile/ProfilePageComponent";

const ProfilePage = () => {
    return (
        <ProtectedRoute>
            <ProfilePageComponent />
        </ProtectedRoute>
    );
};

export default ProfilePage;