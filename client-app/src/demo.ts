export interface IDuck {
  name: string;
  numLegs: number;
  makeSound: (sound: string) => void;
}

const duck1: IDuck = {
  name: "huey",
  numLegs: 2,
  makeSound: (sound: string) => console.log(sound),
};

const duck2: IDuck = {
  name: "dewey",
  numLegs: 2,
  makeSound: (sound: string) => console.log(sound),
};

// ! make overide possible undefined error
// duck1.makeSound("quack");
// duck2.makeSound("duck2 quack");

// duck1.name = 1
// duck1.makeSound(1);

export const ducks = [duck1, duck2];
