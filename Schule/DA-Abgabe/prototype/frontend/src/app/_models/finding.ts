import { ModelObjectInfo } from './modelObject';

export interface FindingInput {
  limit: number;
  offset: number;
  sorting: SortFinding;
  direction?: SortDirection;
  filter?: string;
  categories?: string[];
  severities?: string[];
  classes?: string[];
  voltages?: number[];
}

export enum SortFinding {
  GUID = 'GUID',
  TYPE = 'TYPE',
  SEVERITY = 'SEVERITY',
  CATEGORY = 'CATEGORY',
  MESSAGE = 'MESSAGE',
  CLASS = 'CLASS',
}

export enum SortDirection {
  ASC = 'ASC',
  DESC = 'DSC',
}

export interface Finding {
  guid: string;
  category: string;
  severity: string;
  message: string;
  __typename?: string;
  nominalVoltage?: number;
}

export interface NodeFinding extends Finding {
  referencedNode: ModelObjectInfo;
}

export interface ContainerFinding extends Finding {
  referencedContainer: ModelObjectInfo;
}

export interface EquipmentFinding extends Finding {
  referencedEquipment: ModelObjectInfo;
}

export interface AttachmentFinding extends Finding {
  referencedNode: ModelObjectInfo;
  referencedEquipment: ModelObjectInfo;
}

export interface FindingResult {
  findings: Finding[];
  findingCount: number;
}

export interface RawFinding {
  guid: string;
  category: string;
  severity: string;
  message: string;
  __typename: string;
  referencedNode?: ModelObjectInfo;
  referencedEquipment?: ModelObjectInfo;
  referencedContainer?: ModelObjectInfo;
}

export interface RawFindingResult {
  result: RawFinding[];
  pageInfo: { position: number; count: number };
}

export type FindingsMaybe = RawFinding | Error;
