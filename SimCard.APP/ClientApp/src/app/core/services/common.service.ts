import { Injectable } from '@angular/core';
import { isNullOrUndefined, isString } from 'util';

@Injectable()
export class CommonService {
  constructor() {}

  isCreateMode(viewModel) {
    if (
      isNullOrUndefined(viewModel) ||
      isNullOrUndefined(viewModel.id) ||
      viewModel.id === '' ||
      viewModel.id === 0
    ) {
      return true;
    }
    return false;
  }

  convertToNumber(value: string) {
    if (value && isString(value)) {
      return parseFloat(value.replace(new RegExp(',', 'g'), ''));
    }
    return parseFloat(value);
  }

  getYears(minYear, maxYear) {
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
