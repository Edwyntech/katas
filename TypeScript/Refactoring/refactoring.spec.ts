import { describe, test } from './test.utils';
import { f1, f2, MyPoint } from './refactoring';

/////////////
//// TDD ////
/////////////
export const execTestSuite = () =>
  describe('execTestSuite: Refactoring', () => {
    describe('test f1', () =>
      test<ReadonlyArray<number>>(
        'f1([]) => []',
        () => f1([]),
        (result: ReadonlyArray<number>) => result.length === 0
      ));
    describe('test f2', () =>
      test<ReadonlyArray<MyPoint>>(
        'f2([]) => []',
        () => f2([]),
        (result: ReadonlyArray<MyPoint>) => result.length === 0
      ));
  });
