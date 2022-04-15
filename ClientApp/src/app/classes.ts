import { Inject } from '@angular/core';
import { ICharacter, ISimpleQuestion, IUser } from './interfaces';
import { RaceType } from './enumerators';
import { HttpClient, HttpHeaders } from '@angular/common/http';

const httpOptions = {
  headers: {
    'Content-Type': 'application/json'
  }
}

export class SimpleQuestion implements ISimpleQuestion {
  text: string;
  constructor(text: string) { this.text = text;}
}

export class User implements IUser {
  email: string;
  password: string;

  constructor(mail: string, password: string) {
    this.email = mail;
    this.password = password;   
  }

  validate(): boolean {
    var rg = new RegExp(/[\w-\.]+@([\w-]+\.)+[\w-]{2,4}/);
    if (this.email.length < 3 || this.email.length > 63 || !rg.test(this.email)) return false;
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
