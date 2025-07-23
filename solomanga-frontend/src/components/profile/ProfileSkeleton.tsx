"use client"

import React from 'react';
import { Skeleton } from '../ui/skeleton';

const ProfileSkeleton = () => {
    return (
        <div className="min-h-screen">
            <div className="h-56 w-full bg-zinc-200" />
            <div className="mt-16 p-6 grid grid-cols-1 md:grid-cols-3 gap-6 max-w-6xl mx-auto">
                <div className="col-span-1 space-y-4">
                    <Skeleton className="h-6 w-32" />
                    <Skeleton className="h-4 w-48" />
                    <Skeleton className="h-4 w-40" />
                </div>
                <div className="col-span-2">
                    <Skeleton className="h-10 w-40 mb-4" />
                    <Skeleton className="h-32 w-full" />
                </div>
            </div>
        </div>
    );
};

export default ProfileSkeleton;