import { Injectable } from '@angular/core';

@Injectable()
export class CommonService {
  constructor() {}

  isCreateMode(viewModel: any) {
    if (
      viewModel === null ||
      viewModel.id === null ||
      viewModel.id === '' ||
      viewModel.id === 0
    ) {
      return true;
    }
    return false;
  }

  convertToNumber(value: string) {
    if (value && typeof value === 'string') {
      return parseFloat(value.replace(new RegExp(',', 'g'), ''));
    }
    return parseFloat(value);
  }

  getYears(minYear: number, maxYear: number) {
    const years = [];
    const currentYear = new Date().getFullYear();
    for (let year = minYear; year <= maxYear; year++) {
      const item = {
        id: year,
        text: year,
        selected: year === currentYear
      };
      years.push(item);
    }
    return years;
  }
}
