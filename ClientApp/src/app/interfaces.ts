import { RaceType } from './enumerators';

export interface ISimpleQuestion {
  text: string;
}

export interface IUser {
  email: string;
  password: string;

  validate(): boolean;
}

export interface ICharacter {
  id: number;
  name: string;
  race: RaceType;
  description: string;
  exposed: boolean;
  npc: boolean;
}

/* --- Responses --- */
export interface IBaseResponse {
  success: boolean;
  message: string;
  data: object;
}

export interface IUserResponse extends IBaseResponse { }
export interface ICharacterResponse extends IBaseResponse { }
