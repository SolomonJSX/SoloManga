import {AdminLayout} from "@/components/admin/AdminLayout";
import {AdminOnlyComponent} from "@/components/AdminOnlyComponent";

export default function Layout({children}: { children: React.ReactNode }) {
    return (
        <AdminLayout>
            {children}
        </AdminLayout>
    )
}