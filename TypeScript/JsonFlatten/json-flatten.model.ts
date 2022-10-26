export type JsonKey = string;
export type JsonValue = string | number | boolean | JsonObject | null;
export type JsonObject = {
  [key in JsonKey]: JsonValue;
};
