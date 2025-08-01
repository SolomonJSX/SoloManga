import {AdminOnlyComponent} from "@/components/AdminOnlyComponent";

export default function MangaAdminPage() {
    return (
        <AdminOnlyComponent>
            <h1 className={"text-2xl font-bold mb-4"}>Управление мангой</h1>
            <p className={"text-muted-foreground mb-6"}>Здесь вы можете добавить, изменить или удалить мангу.</p>
        </AdminOnlyComponent>
    )
}