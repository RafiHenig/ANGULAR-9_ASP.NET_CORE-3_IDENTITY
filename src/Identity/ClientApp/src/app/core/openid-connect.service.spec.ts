import { TestBed } from '@angular/core/testing';

import { OpenidConnectService } from './openid-connect.service';

describe('OpenidConnectService', () => {
  let service: OpenidConnectService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(OpenidConnectService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
