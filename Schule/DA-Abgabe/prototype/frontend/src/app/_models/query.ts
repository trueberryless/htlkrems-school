import { Container } from './container';
import { FindingResult, FindingInput } from './finding';
import { ModelObjectInput, ModelObjectResult } from './modelObject';

export interface Query {
  findings: (input: FindingInput) => FindingResult;
  modelObjects: (input: ModelObjectInput) => ModelObjectResult;
  containers: Container[];
}
