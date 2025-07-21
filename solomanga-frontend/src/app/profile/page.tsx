import React from 'react';
import ProtectedRoute from "@/components/ProtectedRoute";

const ProfilePage = () => {
    return (
        <ProtectedRoute>
            <div>
                This is profile page
            </div>
        </ProtectedRoute>
    );
};

export default ProfilePage;