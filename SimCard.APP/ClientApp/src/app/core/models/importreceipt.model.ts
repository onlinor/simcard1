import { Product } from './product.model';

export class ImportReceipt {
    prefix: string;
    suffix: string;
    dateCreated: Date;
    Nhanvienlap: string;
    Tennhacungcap: string;
    Congnocu: number;
    Nguoidaidien: string;
    Sodienthoai: number;
    Dssanpham: Product[];
    Ghichu: string;
    Tienthanhtoan: number;
    Tienconlai: number;
}
