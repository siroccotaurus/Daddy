import { Inject } from '@angular/core';
import { ICharacter, IUser } from './interfaces';
import { RaceType } from './enumerators';
import { HttpClient, HttpHeaders } from '@angular/common/http';

const httpOptions = {
  headers: {
    'Content-Type': 'application/json'
  }
}

export class User implements IUser {
  username: string;
  password: string;
  mail: string;

  constructor(username: string, password: string, mail: string) {
    this.username = username;
    this.password = password;
    this.mail = mail;
  }

  validate(): boolean {
    var rg = new RegExp(/[\w-\.]+@([\w-]+\.)+[\w-]{2,4}/);
    if (this.username.length < 3 || this.username.length > 15) return false;
    else if (this.password.length < 3 || this.password.length > 31) return false;
    else if (this.mail.length < 3 || this.mail.length > 63 || !rg.test(this.mail)) return false;
    return true;
  }
}

export class Character implements ICharacter {
    id: number;
    name: string;
    race: RaceType;
    description: string;
    exposed: boolean;
    npc: boolean;

  constructor(id: number, name: string, race: RaceType, description: string, exposed: boolean, npc: boolean) {
    this.id = id;
    this.name = name;
    this.race = race;
    this.description = description;
    this.exposed = exposed;
    this.npc = npc;
  }
}
