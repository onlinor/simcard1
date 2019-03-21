import { Product } from './product.model';

export class ImportReceipt {
  prefix: string;
  suffix: string;
  dateCreated: Date;
  nhanvienlap: string;
  tennhacungcap: string;
  congnocu: number;
  nguoidaidien: string;
  sodienthoai: number;
  products: Product[];
  ghichu: string;
  tienthanhtoan: number;
  tienconlai: number;
}
