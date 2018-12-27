export class MenuModel {
    id: string;
    name: string;
    icon: string;
    url: string;
    displayName: string;
    isDisplay: boolean;
    active: boolean;
    children: MenuModel[];
}
