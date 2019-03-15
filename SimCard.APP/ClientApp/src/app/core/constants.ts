export class LocalStorageKey {
  static AUTHORIZATION = 'authorization';
  static AUTHENTICATE_MODE = 'authenticate-mode';
}

export class HttpStatusCode {
  static SimCardError = 601;
}

export class CrudActionType {
  static CREATE = 'CREATE';
  static EDIT = 'EDIT';
  static DELETE = 'DELETE';
  static SUBMIT = 'SUBMIT';
  static APPROVE = 'APPROVE';
  static REJECT = 'REJECT';
  static DETAILS = 'DETAILS';
}

export class SubscribeConstant {
  static FULL_PAGE = 'FullPage';
  static SHOW_LOADING = 'ShowLoading';
}

export class DefaultDataConstant {
  static IMG_DEFAULT_URL = './assets/images/defaultUploadImage.png';
}

export class ReportConstant {
  static SupportedReports = [
    {
      label: 'BÁO CÁO XUẤT NHẬP TỒN',
      items: [
        { label: '--- XUẤT NHẬP TỒN TỔNG HỢP', value: '1' },
        { label: '--- HÀNG TỒN KHO', value: '2' }
      ]
    },
    {
      label: 'BÁO CÁO NHẬP HÀNG',
      items: [
        { label: '--- NHẬP HÀNG THEO NHÀ CUNG CẤP', value: '3' },
        { label: '--- NHẬP HÀNG THEO MẶT HÀNG', value: '4' }
      ]
    },
    {
      label: 'BÁO CÁO XUẤT HÀNG VÀ LỢI NHUẬN',
      items: [
        { label: '--- CHI TIẾT XUẤT HÀNG VÀ LỢI NHUẬN', value: '5' },
        {
          label: '--- TỔNG HỢP XUẤT HÀNG VÀ LỢI NHUẬN THEO MẶT HÀNG',
          value: '6'
        },
        {
          label:
            '--- TỔNG HỢP  XUẤT HÀNG - LỢI NHUẬN - CÔNG NỢ THEO KHÁCH HÀNG',
          value: '7'
        }
      ]
    },
    {
      label: 'BÁO CÁO CÔNG NỢ KHÁCH HÀNG',
      items: [
        { label: '--- CÔNG NỢ KHÁCH HÀNG CỦA TOÀN CÔNG TY', value: '7' },
        { label: '--- TỔNG HỢP CÔNG NỢ KHÁCH HÀNG CỦA TỪNG CN', value: '8' }
      ]
    },
    {
      label: 'BÁO CÁO SỔ TIỀN MẶT - SỔ NGÂN HÀNG',
      items: [
        { label: '--- SỔ TIỀN MẶT TOÀN CÔNG TY', value: '9' },
        {
          label: '--- TỔNG HỢP GIAO DỊCH VÀ SỐ DƯ TKNH TOÀN CÔNG TY',
          value: '10'
        }
      ]
    },
    {
      label: 'BÁO CÁO THU - CHI KHÁC',
      items: [
        { label: '--- CHI TIẾT THU CHI KHÁC', value: '11' },
        { label: '--- TỔNG HỢP THU CHI KHÁC', value: '12' }
      ]
    },
    {
      label: 'BÁO CÁO CHI PHÍ HOẠT ĐỘNG KINH DOANH',
      items: [
        { label: '--- CHI TIẾT CHI PHÍ HOẠT ĐỘNG KINH DOANH', value: '13' },
        { label: '--- TỔNG HỢP CHI PHÍ HOẠT ĐỘNG KINH DOANH', value: '14' }
      ]
    },
    {
      label: 'BÁO CÁO KẾT QUẢ KINH DOANH',
      items: [{ label: '--- KẾT QUẢ KINH DOANH', value: '15' }]
    }
  ];
}
