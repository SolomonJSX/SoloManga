"use client"

import React, {useState} from 'react';
import {QueryClient, QueryClientProvider} from "@tanstack/react-query";

interface IProviderProps {
    children: React.ReactNode;
}

const Providers = ({ children }: IProviderProps) => {
    const [queryClient] = useState(() => new QueryClient());

    return (
        <>
            <QueryClientProvider client={queryClient}>
                {children}
            </QueryClientProvider>
        </>
    );
};

export default Providers;