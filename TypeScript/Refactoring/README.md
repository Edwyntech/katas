/\*\*

-
- Vous arrivez dans une classe où vous trouvez ces deux fonctions f1 et f2.
- Vous décidez de les refacto.
-
- Dans le respect des bonnes pratiques craft, comment procéderiez-vous ?
  \*/

const f1 = (
items: ReadonlyArray<ReadonlyArray<number>>
): ReadonlyArray<number> => {
const cumulator: ReadonlyArray<number> = items.reduce(
(carry: ReadonlyArray<number>, item: ReadonlyArray<number>) => [
...carry,
...item.map((i: number) => i * 2)
],
[]
);
const mappedCumulator: ReadonlyArray<number> = cumulator.map(
(item: number) => item \* 3
);
return mappedCumulator.filter((item: number) => item % 3 === 0);
};

const f2 = (
items: ReadonlyArray<
ReadonlyArray<{
x: number;
}>

> ): ReadonlyArray<{
> x: number;
> }> => {
> const cumulator: ReadonlyArray<{

    x: number;

}> = items.reduce(
(
carry: ReadonlyArray<{
x: number;
}>,
item: ReadonlyArray<{
x: number;
}>
) => [...carry, ...item.map((p: { x: number }) => ({ ...p, x: p.x * 7 }))],
[]
);

const mappedCumulator: ReadonlyArray<{
x: number;
}> = cumulator.map((p: { x: number }) => ({
...p,
x: p.x \* 3
}));
return mappedCumulator.filter((p: { x: number }) => p.x % 3 === 0);
};
