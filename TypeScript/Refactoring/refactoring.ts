/**
 *
 * Vous arrivez dans une classe où vous trouvez ces deux fonctions f1 et f2.
 * Vous décidez de les refacto.
 *
 * Dans le respect des bonnes pratiques craft, comment procéderiez-vous ?
 */

const reducer = <T, U>(
  items: ReadonlyArray<T>,
  iteratee: (item: T) => ReadonlyArray<U>
): ReadonlyArray<U> =>
  items.reduce(
    (carry: ReadonlyArray<U>, item: T) => [...carry, ...iteratee(item)],
    []
  );

const mapper = <T>(
  items: ReadonlyArray<T>,
  iteratee: (item: T) => T
): ReadonlyArray<T> => items.map(iteratee);

const filterer = <T>(
  items: ReadonlyArray<T>,
  iteratee: (item: T) => boolean
): ReadonlyArray<T> => items.filter(iteratee);

const generic = <T, U>(
  items: ReadonlyArray<T>,
  reducing: (item: T) => ReadonlyArray<U>,
  mapping: (item: U) => U,
  filtering: (item: U) => boolean
): ReadonlyArray<U> =>
  filterer(mapper(reducer(items, reducing), mapping), filtering);

const genericAlt = <T, U>(
  items: ReadonlyArray<T>,
  reducer: (item: T) => ReadonlyArray<U>,
  mapper: (item: U) => U,
  filterer: (item: U) => boolean
): ReadonlyArray<U> => {
  const cumulator: ReadonlyArray<U> = items.reduce(
    (carry: ReadonlyArray<U>, item: T) => [...carry, ...reducer(item)],
    []
  );

  const mappedCumulator: ReadonlyArray<U> = cumulator.map(mapper);
  return mappedCumulator.filter(filterer);
};
const genericChain = <T, U>(
  items: ReadonlyArray<T>,
  reducer: (item: T) => ReadonlyArray<U>,
  mapper: (item: U) => U,
  filterer: (item: U) => boolean
): ReadonlyArray<U> => {
  return items
    .reduce(
      (carry: ReadonlyArray<U>, item: T) => [...carry, ...reducer(item)],
      []
    )
    .map(mapper)
    .filter(filterer);
};

export const f1 = (
  items: ReadonlyArray<ReadonlyArray<number>>
): ReadonlyArray<number> => {
  return generic<ReadonlyArray<number>, number>(
    items,
    (item: ReadonlyArray<number>) => item.map((i: number) => i * 2),
    (item: number) => item * 3,
    (item: number) => item % 3 === 0
  );
};

export type MyPoint = {
  x: number;
};

export const f2 = (
  items: ReadonlyArray<ReadonlyArray<MyPoint>>
): ReadonlyArray<MyPoint> => {
  return generic<ReadonlyArray<MyPoint>, MyPoint>(
    items,
    (item: ReadonlyArray<MyPoint>) =>
      item.map((p: MyPoint) => ({ ...p, x: p.x * 7 })),
    (item: MyPoint) => ({ ...item, x: item.x * 3 }),
    (item: MyPoint) => item.x % 3 === 0
  );
};
