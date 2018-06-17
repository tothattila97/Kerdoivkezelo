import { Kerdes } from './kerdes';

export class Kerdoiv {
  nev: string;
  kerdesek: Kerdes[];
}

export const KERDOIV: Kerdoiv = {
  nev: 'Teszt01',
  kerdesek: [
    {
      kerdes: '2+2=?',
      valaszok: [ '1', '2', '3', '4', '#quickmaffs'],
      tipus: 'tobbszoros'
    },
    {
      kerdes: 'Megyünk enni?',
      valaszok: [ 'Igen', 'Nem :('],
      tipus: 'egyszeru'
    },
    {
      kerdes: 'Megyünk enni?',
      valaszok: [ 'Igen', 'Nem :('],
      tipus: 'egyszeru'
    },
    {
      kerdes: 'Hogyan szaporodnak a polipok?',
      valaszok: [],
      tipus: 'szoveges'
    }
  ]
};
