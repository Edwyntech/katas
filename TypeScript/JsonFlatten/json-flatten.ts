/**
 * L'objectif est d'implémenter un algorithme permettant d'aplatir un objet JSON multi-niveau en un objet à un seul niveau
 * L'idée est de procéder par étape
 * Aucun framework n'est nécessaire
 *
 * En TDD, il est conseillé d'écrire un test qui ne fonctionne pas et de coder jusqu'à ce que le test passe.
 *
 * Dans notre exercice, nous procéderons de cette manière depuis le nommage de la fonction jusqu'au moment où l'on estime
 * que le besoin est couvert.
 *
 * Voici notre objet en entrée
 *
 *  const input = {
 *    a: {
 *      b: {
 *        c: 3
 *      },
 *      d: 7
 *    },
 *    e: {
 *      f: 4
 *    }
 *  };
 *
 * Voici le résultat attendu
 *
 *  const result = {
 *    'a.b.c': 3,
 *    'a.d': 7,
 *    'e.f': 4
 *  };
 *
 */

import { JsonKey, JsonObject, JsonValue } from './json-flatten.model';

const concatPath = (
  path: ReadonlyArray<string>,
  key: string
): ReadonlyArray<string> => [...path, key];
const generatePath = (path: ReadonlyArray<string>): string => path.join('.');

export const compute = (
  input: JsonObject,
  path: ReadonlyArray<string> = []
): JsonObject => {
  return Object.entries(input).reduce(
    (carry: JsonObject, current: [JsonKey, JsonValue]) =>
      ({
        ...carry,
        ...(typeof current[1] !== 'object'
          ? {
              [generatePath(concatPath(path, current[0]))]: current[1]
            }
          : compute(current[1] as JsonObject, concatPath(path, current[0])))
      } as JsonObject),

    {} as JsonObject
  );
};
