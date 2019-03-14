import { Component, OnInit } from '@angular/core';
import { Network } from '../../core/models';
import { NetworkService } from '../../core/services/network.service';

@Component({
  selector: 'app-network',
  templateUrl: './network.component.html',
  styleUrls: ['./network.component.css']
})
export class NetworkComponent implements OnInit {

  displayDialog: boolean;

  network: Network = new Network();

  selectedNetwork: Network;

  newNetwork: boolean;

  networks: Network[];

  cols: any[];

  constructor(private networkService: NetworkService) { }

  ngOnInit() {
    this.networkService.getAll().subscribe(
      networks => this.networks = networks
    );

    this.cols = [
      { field: 'ten', header: 'Tên' },
      { field: 'ma', header: 'Mã' },
      { field: 'menhgia', header: 'Mệnh giá' },
      { field: 'chietkhaudauvao', header: 'Chiết Khấu Đầu Vào' },
      { field: 'chietkhaucaonhat', header: 'Chiết Khấu Cao Nhất' },
      { field: 'buocnhay', header: 'Bước Nhảy' },
      { field: 'khungtien_1', header: 'Khoảng Giá 1' },
      { field: 'khungtien_2', header: 'Khoảng Giá 2' },
      { field: 'khungtien_3', header: 'Khoảng Giá 3' },
      { field: 'khungtien_4', header: 'Khoảng Giá 4' },
      { field: 'khungtien_5', header: 'Khoảng Giá 5' },
      { field: 'khungtien_6', header: 'Khoảng Giá 6' },
      { field: 'khungtien_7', header: 'Khoảng Giá 7' }
    ];
  }

  showDialogToAdd() {
      this.newNetwork = true;
      this.network = new Network();
      this.displayDialog = true;
  }

  save() {
      // tslint:disable-next-line:prefer-const
      let networks = [...this.networks];
      if (this.newNetwork) {
        networks.push(this.network);
      } else {
        networks[this.networks.indexOf(this.selectedNetwork)] = this.network;
      }
      this.networks = networks;
      this.network = new Network();
      this.displayDialog = false;
  }

  delete() {
      const index = this.networks.indexOf(this.selectedNetwork);
      this.networks = this.networks.filter((val, i) => i !== index);
      this.network = null;
      this.displayDialog = false;
  }

  onRowSelect(event) {
      this.newNetwork = false;
      this.network = this.cloneNetwork(event.data);
      this.displayDialog = true;
  }

  cloneNetwork(n: Network): Network {
      // tslint:disable-next-line:prefer-const
      let network = new Network();
      // tslint:disable-next-line:forin
      for (const prop in n) {
        network[prop] = n[prop];
      }
      return network;
  }

}
