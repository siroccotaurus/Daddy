import { RaceType } from './enumerators';

export interface IUser {
  username: string;
  password: string;
  mail: string;

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
