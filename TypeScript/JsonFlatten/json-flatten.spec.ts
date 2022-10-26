import { describe, test } from './test.utils';
import { compute } from './json-flatten';
import { JsonObject } from './json-flatten.model';

/////////////
//// TDD ////
/////////////
export const execTestSuite = () =>
  describe('execTestSuite: JsonFlatten', () => {
    describe('test compute', () =>
      test<JsonObject>(
        'compute({}) => {}',
        () => compute({} as JsonObject),
        (result: JsonObject) => !result.length
      ));
  });
