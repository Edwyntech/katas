import { describe, test } from './common';
import { f1, f2, MyPoint } from './refactoring';

describe('test f1', () => {
  test<ReadonlyArray<number>>(
    'f1([]) => []',
    () => f1([]),
    (result: ReadonlyArray<number>) => result.length === 0
  );
});
describe('test f2', () => {
  test<ReadonlyArray<MyPoint>>(
    'f2([]) => []',
    () => f2([]),
    (result: ReadonlyArray<MyPoint>) => result.length === 0
  );
});
