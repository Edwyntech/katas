import { describe, test } from './common';
import { compute } from './json-flatten';

/////////////
//// TDD ////
/////////////

describe('test compute', () => {
  test<{ [key: string]: any }>(
    'compute([]) => []',
    () => compute([]),
    (result: { [key: string]: any }) => result.length === 0
  );
});
