'use client';

import React, { useState } from 'react';
import Link from 'next/link';
import { Menu, X } from 'lucide-react';
import clsx from 'clsx';

const Header = () => {
    const menu = [
        { href: '/', label: 'Главная' },
        { href: '/manga', label: 'Манга' },
    ];

    const [isOpen, setIsOpen] = useState(false);

    return (
        <>
            {/* Сам header */}
            <header className="bg-zinc-700 text-white p-4 shadow-md z-50 relative">
                <div className="container mx-auto flex justify-between items-center">
                    {/* Desktop Nav */}
                    <nav className="hidden md:flex space-x-6 text-white font-medium items-center">
                        <Link href="/public" className="font-bold text-xl">
                            SoloManga (LOGO)
                        </Link>
                        {menu.map((item, index) => (
                            <Link key={index} href={item.href}>
                                {item.label}
                            </Link>
                        ))}
                    </nav>

                    <div className="hidden md:block">
                        <Link href="/login">Войти</Link>
                    </div>

                    {/* Mobile Menu Button */}
                    <button className="md:hidden" onClick={() => setIsOpen(!isOpen)}>
                        {isOpen ? <X size={24} /> : <Menu size={24} />}
                    </button>
                </div>
            </header>

            {/* Overlay */}
            <div className={clsx('z-30 fixed inset-0 bg-black/50 transition-opacity duration-300',
                isOpen ? "opacity-100 visible" : "opacity-100 invisible"
                )} />

            {/* Mobile Sidebar — теперь не перекрывает header */}
            {isOpen && (
                <div className="relative z-40">
                    <aside
                        className={clsx(
                            "fixed top-0 left-0 w-64 bg-zinc-900 text-white shadow-lg z-40 transition-transform duration-300",
                            isOpen ? "translate-x-0" : "-translate-x-full"
                        )}
                        style={{
                            height: "calc(100vh - 55px)",
                            top: "55px"
                        }}
                    >
                        <div className="p-4 flex justify-between items-center border-b border-zinc-700">
                            <span className="text-xl font-bold">Меню</span>
                        </div>
                        <nav className="flex flex-col gap-4 p-4 text-lg">
                            <Link href="/" onClick={() => setIsOpen(false)}>Главная</Link>
                            <Link href="/manga" onClick={() => setIsOpen(false)}>Манга</Link>
                            <Link href="/login" onClick={() => setIsOpen(false)}>Войти</Link>
                        </nav>
                    </aside>
                </div>
            )}
        </>
    );
};

export default Header;
