"use client"

import Link from 'next/link';
import React from 'react'
import {clsx} from "clsx";
import {usePathname} from "next/navigation";

interface AdminSidebarProps {
    links: { label: string; href: string }[];
}


export const AdminSidebar = ({links}: AdminSidebarProps) => {
    const pathname = usePathname()

    return (
        <aside className="w-64 bg-zinc-900 text-white p-6 space-y-4">
            <h2 className="text-2xl font-bold">Админка</h2>
            <nav className="space-y-2">
                {links.map(link => (
                    <Link
                        key={link.href}
                        href={link.href}
                        className={clsx(
                            "block px-3 py-2 rounded hover:bg-zinc-700 transition",
                            pathname === link.href && "bg-zinc-700",
                        )}
                    >
                        {link.label}
                    </Link>
                ))}
            </nav>
        </aside>
    )
}
