import { IDuck } from "./demo";

interface Props {
  duck: IDuck;
}

export default function DuckItem({ duck }: Props) {
  return (
    <div>
      <span>{duck.name}</span>
      <button
        type="button"
        onClick={() => {
          duck.makeSound(duck.name + " quack");
        }}
      >
        MakeSound
      </button>
    </div>
  );
}
