import { Component, OnInit } from '@angular/core';
import { Network, NetworkRange } from '../../core/models';
import { NetworkService, NetworkRangeService } from '../../core/services';

@Component({
  selector: 'app-network',
  templateUrl: './network.component.html',
  styleUrls: ['./network.component.css']
})
export class NetworkComponent implements OnInit {
  displayEditDialog: boolean;
  displayAddDialog: boolean;
  displayEditDialogRange: boolean;
  displayAddDialogRange: boolean;
  network: Network = new Network();
  networkRange: NetworkRange = new NetworkRange();
  selectedNetwork: Network;
  selectedNetworkRange: NetworkRange;
  newNetwork: boolean;
  newNetworkRange: boolean;
  networks: Network[];
  networkRanges: NetworkRange[];
  cols: any[];
  colRanges: any[];
  constructor(
    private networkService: NetworkService,
    private networkRangeService: NetworkRangeService
  ) {}

  ngOnInit() {
    this.showNetworksResponse();
    this.showNetworkRangesResponse();

    this.cols = [
      { field: 'ten', header: 'Tên' },
      { field: 'ma', header: 'Mã' },
      { field: 'menhGia', header: 'Mệnh giá' },
      { field: 'chietKhauDauVao', header: 'Chiết Khấu Đầu Vào' },
      { field: 'chietKhauCaoNhat', header: 'Chiết Khấu Cao Nhất' },
      { field: 'buocNhay', header: 'Bước Nhảy' },
      { field: 'khungTien_1' },
      { field: 'khungTien_2' },
      { field: 'khungTien_3' },
      { field: 'khungTien_4' },
      { field: 'khungTien_5' },
      { field: 'khungTien_6' },
      { field: 'khungTien_7' }
    ];

    this.colRanges = [
      { field: 'range_1', header: 'Khoảng Giá 1' },
      { field: 'range_2', header: 'Khoảng Giá 2' },
      { field: 'range_3', header: 'Khoảng Giá 3' },
      { field: 'range_4', header: 'Khoảng Giá 4' },
      { field: 'range_5', header: 'Khoảng Giá 5' },
      { field: 'range_6', header: 'Khoảng Giá 6' },
      { field: 'range_7', header: 'Khoảng Giá 7' }
    ];
  }

  showDialog() {
    this.newNetwork = true;
    this.network = new Network();
    this.displayAddDialog = true;
  }

  showDialogRange() {
    this.newNetworkRange = true;
    this.networkRange = new NetworkRange();
    this.displayAddDialogRange = true;
  }

  addNew() {
    if (
      this.network.chietKhauCaoNhat - this.network.buocNhay * 7 < 0 ||
      this.networks.find(x => x.ma === this.network.ma)
    ) {
      console.log('Please input correct value :)');
      this.displayAddDialog = false;
    } else {
      this.network.khungTien_1 = this.network.chietKhauCaoNhat;
      this.network.khungTien_2 =
        this.network.khungTien_1 - this.network.buocNhay;
      this.network.khungTien_3 =
        this.network.khungTien_2 - this.network.buocNhay;
      this.network.khungTien_4 =
        this.network.khungTien_3 - this.network.buocNhay;
      this.network.khungTien_5 =
        this.network.khungTien_4 - this.network.buocNhay;
      this.network.khungTien_6 =
        this.network.khungTien_5 - this.network.buocNhay;
      this.network.khungTien_7 =
        this.network.khungTien_6 - this.network.buocNhay;

      this.networkService.save(this.network).subscribe(() => {
        this.showNetworksResponse();

        this.network = new Network();
        this.displayAddDialog = false;
      });
    }
  }

  addNewRange() {
    this.networkRangeService.save(this.networkRange).subscribe(() => {
      this.showNetworkRangesResponse();

      this.networkRange = new NetworkRange();
      this.displayAddDialogRange = false;
    });
  }

  delete() {
    const index = this.selectedNetwork.id;
    this.networkService.delete(index).subscribe(() => {
      this.showNetworksResponse();
    });
    this.network = new Network();
    this.displayEditDialog = false;
  }

  deleteRange() {
    const index = this.selectedNetworkRange.id;
    this.networkRangeService.delete(index).subscribe(() => {
      this.showNetworkRangesResponse();
    });
    this.networkRange = new NetworkRange();
    this.displayEditDialogRange = false;
  }

  edit() {
    // if (this.network.chietKhauCaoNhat - (this.network.buocNhay * 7) < 0) {
    //   console.log('Giá trị không phù hợp');
    //   this.displayEditDialog = false;
    // } else {
    //   this.networkService.update(this.network).subscribe(() => {
    //     this.showNetworksResponse();
    //   });
    // }
    // this.network = new Network();
    // this.displayEditDialog = false;
  }

  showNetworksResponse() {
    this.networkService.getAll().subscribe(resp => {
      this.networks = resp;
    });
  }

  showNetworkRangesResponse() {
    this.networkRangeService.getAll().subscribe(resp => {
      this.networkRanges = resp;
    });
  }

  onRowSelect(event) {
    this.newNetwork = false;
    this.network = this.cloneNetwork(event.data);
    this.displayEditDialog = true;
  }

  onRowSelectRange(event) {
    this.newNetworkRange = false;
    this.networkRange = this.cloneNetworkRange(event.data);
    this.displayEditDialogRange = true;
  }

  cloneNetwork(sp: any): Network {
    // tslint:disable-next-line:prefer-const
    let network: Network = {
      id: sp.id,
      ma: sp.ma,
      ten: sp.ten,
      menhGia: sp.menhGia,
      chietKhauCaoNhat: sp.chietKhauCaoNhat,
      chietKhauDauVao: sp.chietKhauDauVao,
      buocNhay: sp.buocNhay,
      khungTien_1: sp.khungTien_1,
      khungTien_2: sp.khungTien_2,
      khungTien_3: sp.khungTien_3,
      khungTien_4: sp.khungTien_4,
      khungTien_5: sp.khungTien_5,
      khungTien_6: sp.khungTien_6,
      khungTien_7: sp.khungTien_7
    };
    // assign
    return network;
  }

  cloneNetworkRange(sp: any): NetworkRange {
    // tslint:disable-next-line:prefer-const
    let networkRange: NetworkRange = {
      id: sp.id,
      range_1: sp.range_1,
      range_2: sp.range_1,
      range_3: sp.range_1,
      range_4: sp.range_1,
      range_5: sp.range_1,
      range_6: sp.range_1,
      range_7: sp.range_1
    };
    // assign
    return networkRange;
  }

  getRange(index: any) {
    if (index === 0) {
      return 'Tên';
    }
    if (index === 1) {
      return 'Mã';
    }
    if (index === 2) {
      return 'Mệnh Giá';
    }
    if (index === 3) {
      return 'Chiết Khấu Đầu Vào';
    }
    if (index === 4) {
      return 'Chiếu Khấu Cao Nhất';
    }
    if (index === 5) {
      return 'Bước Nhảy';
    }
    if (index === 6) {
      return this.networkRanges[0].range_1;
    }
    if (index === 7) {
      return this.networkRanges[0].range_2;
    }
    if (index === 8) {
      return this.networkRanges[0].range_3;
    }
    if (index === 9) {
      return this.networkRanges[0].range_4;
    }
    if (index === 10) {
      return this.networkRanges[0].range_5;
    }
    if (index === 11) {
      return this.networkRanges[0].range_6;
    }
    if (index === 12) {
      return this.networkRanges[0].range_7;
    }
  }
}
