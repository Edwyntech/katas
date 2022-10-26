export const test = <T>(
  name: string,
  callback: () => T,
  expected: (result: T) => boolean
) => {
  try {
    const result = callback();
    if (!expected(result)) {
      throw new Error(`${name} ...error`);
    }
    console.log(`${name} ...done`);
  } catch (error) {
    console.error(error);
  }
};

export const describe = (description: string, callback: () => void): void => {
  console.log(description);
  try {
    callback();
  } catch (error) {
    console.error(`describe: ${description} = ${error}`);
  }
};
