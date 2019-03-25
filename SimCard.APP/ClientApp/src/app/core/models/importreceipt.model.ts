import { Product } from './product.model';

export class ImportReceipt {
  prefix: string;
  suffix: number;
  ma: string;
  nhanVienLap: string;
  congNoCu: number;
  nguoiDaiDien: string;
  createdOn: Date;
  soDienThoai: number;
  products: Array<Product>;
  ghiChu: string;
  tienThanhToan: number;
  tienConLai: number;
  supplierId: number;
  shopId: number;
}
