export interface ClaimsVM {
  type: string;
  value: string;
}

export interface UserClaims {
  claims: ClaimsVM[];
  userName: string;
}
