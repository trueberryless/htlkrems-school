import { Error } from './error';
import { ContainerInfo } from './container';

export interface ModelObjectInfo {
  guid: string;
  name: string;
  className: ClassNameInfo;
  container: ContainerInfo;
}

export interface ModelObject {
  guid: string;
  name: string;
  className: ClassNameInfo;
  container: ContainerInfo;
  connections: ModelObjectConnection[];
}

export interface ModelObjectConnection {
  guid: string;
  modelObject: ModelObjectInConnection;
  modelObjectGuid?: string;
  included?: boolean;
}

export type ModelObjectInConnection = ModelObject | WithHeld;

export interface WithHeld {}

export interface ModelObjectInput {
  modelObjectsToLoad: string[];
  modelObjectsToIgnore: string[];
  depth: number;
}

export interface ClassNameInfo {
  shortName: string;
  fullName?: string;
}

export interface ModelObjectResult {
  result: ModelObject[];
  // pageInfo: { position: number; count: number };
}

export type ModelObjectMaybe = ModelObjectResult | Error;
