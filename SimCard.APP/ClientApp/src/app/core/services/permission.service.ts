import { Injectable } from '@angular/core';

@Injectable()
export class PermissionService {
  constructor() {}

  hasPermission(permissionNames: string[]) {
    return true;
  }

  hasChildrenPermission(permissionNames: string[]) {
    return true;
  }
}
