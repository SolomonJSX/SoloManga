import React from 'react';
import {AdminOnlyComponent} from "@/components/AdminOnlyComponent";

const DashboardPage = () => {
    return (
        <AdminOnlyComponent>
            <div>
                This is dashboard page.
            </div>
        </AdminOnlyComponent>
    );
};

export default DashboardPage;