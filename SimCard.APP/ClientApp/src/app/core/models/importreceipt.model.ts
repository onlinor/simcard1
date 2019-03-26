import { Product } from './product.model';

export class ImportReceipt {
  ma: string;
  prefix: string;
  suffix: number;
  nhanVienLap: string;
  congNoCu: number;
  nguoiDaiDien: string;
  soDienThoai: number;
  products: Array<Product>;
  ghiChu: string;
  tienThanhToan: number;
  tienConLai: number;
  tongTien: number;
  supplierId: number;
  shopId: number;
}
