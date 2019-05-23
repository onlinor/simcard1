import { Component, OnInit } from '@angular/core';
import { Network } from '../../core/models';
import { NetworkService } from '../../core/services/network.service';

@Component({
  selector: 'app-network',
  templateUrl: './network.component.html',
  styleUrls: ['./network.component.css']
})
export class NetworkComponent implements OnInit {

  displayEditDialog: boolean;
  displayAddDialog: boolean;

  network: Network = new Network();

  selectedNetwork: Network;

  newNetwork: boolean;

  networks: Network[];

  cols: any[];

  constructor(private networkService: NetworkService) {}

  ngOnInit() {
    this.showNetworksResponse();

    this.cols = [
      { field: 'ten', header: 'Tên' },
      { field: 'ma', header: 'Mã' },
      { field: 'menhGia', header: 'Mệnh giá' },
      { field: 'chietKhauDauVao', header: 'Chiết Khấu Đầu Vào' },
      { field: 'chietKhauCaoNhat', header: 'Chiết Khấu Cao Nhất' },
      { field: 'buocNhay', header: 'Bước Nhảy' },
      { field: 'khungTien_1', header: 'Khoảng Giá 1' },
      { field: 'khungTien_2', header: 'Khoảng Giá 2' },
      { field: 'khungTien_3', header: 'Khoảng Giá 3' },
      { field: 'khungTien_4', header: 'Khoảng Giá 4' },
      { field: 'khungTien_5', header: 'Khoảng Giá 5' },
      { field: 'khungTien_6', header: 'Khoảng Giá 6' },
      { field: 'khungTien_7', header: 'Khoảng Giá 7' }
    ];
  }

  showDialog() {
    this.newNetwork = true;
    this.network = new Network();
    this.displayAddDialog = true;
  }

  addNew() {
    this.network.id = 0;
    this.networkService.save(this.network).subscribe(() => {
      this.showNetworksResponse();
    });

    this.network = new Network();
    this.displayAddDialog = false;
  }

  delete() {
    const index = this.selectedNetwork.id;
    this.networkService.delete(index).subscribe(() => {
      this.showNetworksResponse();
    });
    this.network = new Network();
    this.displayEditDialog = false;
  }

  edit() {
    if (this.networks.find(x => x.id !== this.selectedNetwork.id
       && (x.ten === this.network.ten || x.ma === this.network.ma))) {
      console.log('Trùng');
    } else {
      this.network.id = this.selectedNetwork.id;
      this.networkService.update(this.network).subscribe(() => {
        this.showNetworksResponse();
      });
    }
    this.network = new Network();
    this.displayEditDialog = false;
  }

  showNetworksResponse() {
    this.networkService.getAll().subscribe(resp => {
      this.networks = resp;
    });
  }

  onRowSelect(event) {
    this.newNetwork = false;
    this.network = this.cloneNetwork(event.data);
    this.displayEditDialog = true;
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
      khungTien_7: sp.khungTien_7,
    };
    // assign
    return network;
  }
}
