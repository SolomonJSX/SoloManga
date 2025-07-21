'use client';

import React, { useState } from 'react';
import Link from 'next/link';
import {CircleUserRound, LogOut, Menu, X} from 'lucide-react';
import clsx from 'clsx';
import {useAuth} from "@/stores/useAuth";
import {useRouter} from "next/navigation";

const Header = () => {
    const menu = [
        { href: '/', label: 'Главная' },
        { href: '/manga', label: 'Манга' },
    ];

    const { user, logout } = useAuth()

    const [isOpen, setIsOpen] = useState(false);

    const router = useRouter();

    return (
        <>
            {/* Сам header */}
            <header className="bg-zinc-700 text-white p-4 shadow-md z-50 relative">
                <div className="container mx-auto flex justify-between items-center">
                    {/* Desktop Nav */}
                    <nav className="hidden md:flex space-x-6 text-white font-medium items-center">
                        <Link href="/" className="font-bold text-xl">
                            SoloManga (LOGO)
                        </Link>
                        {menu.map((item, index) => (
                            <Link key={index} href={item.href}>
                                {item.label}
                            </Link>
                        ))}
                    </nav>


                    {
                        !user ? (
                            <div className="hidden md:block">
                                <Link href="/auth/login">Войти</Link>
                            </div>
                        ) : (
                            <div className={"hidden cursor-pointer md:flex items-center gap-5"}>
                                <CircleUserRound size={24} onClick={() => router.push("/profile")} />
                                <LogOut size={24} onClick={() => logout()} />
                            </div>
                        )
                    }



                    {/* Mobile Menu Button */}
                    <div className={"flex gap-2 md:hidden items-center"}>
                        <button onClick={() => setIsOpen(!isOpen)}>
                            {isOpen ? <X size={24} /> : <Menu size={24} />}
                        </button>
                        <Link href="/public" className="font-bold text-sm">
                            SoloManga (LOGO)
                        </Link>
                    </div>
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
                            {/*<Link href="/manga" onClick={() => setIsOpen(false)}>Манга</Link>*/}
                            <Link href="/auth/login" onClick={() => setIsOpen(false)}>Войти</Link>
                        </nav>
                    </aside>
                </div>
            )}
        </>
    );
};

export default Header;