'use client';

import React, { useState } from 'react';
import Link from 'next/link';
import { Menu, X } from 'lucide-react';

const Header = () => {

    const menu = [
        {
            href: "/",
            label: "Home",
        },
        {
            href: "/",
            label: "Манга",
        },
    ]

    const [isOpen, setIsOpen] = useState(false);

    return (
        <header className="bg-zinc-700 text-white p-4 shadow-md">
            <div className="container mx-auto flex justify-between items-center">


                {/* Desktop Nav */}
                <nav className="hidden md:flex space-x-6 text-white font-medium">
                    <Link href="/" className="font-bold text-xl">
                        SoloManga (LOGO)
                    </Link>
                    {menu.map((item, index) => (
                        <Link href={item.href!}>{item.label}</Link>
                    ))}
                </nav>

                <div className={"hidden md:block"}>
                    <Link href="/login">Войти</Link>
                </div>

                {/* Mobile Menu Button */}
                <button className="md:hidden" onClick={() => setIsOpen(!isOpen)}>
                    {isOpen ? <X size={24} /> : <Menu size={24} />}
                </button>
            </div>

            {/* Mobile Menu */}
            {isOpen && (
                <div className="md:hidden flex flex-col gap-0.5 bg-zinc-800 px-4 py-2 space-y-2 text-white font-medium mt-5">
                    <div>
                        <Link href="/manga" onClick={() => setIsOpen(false)}>Манга</Link>
                        <Link href="/bookmarks" onClick={() => setIsOpen(false)}>Закладки</Link>
                        <Link href="/login" onClick={() => setIsOpen(false)}>Войти</Link>
                    </div>
                </div>
            )}
        </header>
    );
};

export default Header;
