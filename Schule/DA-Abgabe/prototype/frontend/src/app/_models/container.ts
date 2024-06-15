import { ClassNameInfo } from './modelObject';

export interface ContainerInfo {
  guid: string;
  name?: string;
  nominalVoltage?: number;
  className?: ClassNameInfo;
}

export interface Container {
  guid: string;
  name: string;
  className: string;
  nominalVoltage?: number;
  subcontainer: Container[];
}
