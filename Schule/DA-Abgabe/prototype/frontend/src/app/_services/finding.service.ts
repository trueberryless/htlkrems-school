import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, empty, from } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import {
  AttachmentFinding,
  ClassNameInfo,
  ContainerFinding,
  EquipmentFinding,
  Error,
  Finding,
  FindingInput,
  FindingResult,
  ModelObjectInfo,
  NodeFinding,
  PercentageData,
  RawFindingResult,
  SortFinding,
} from '@app/_models';
import { Apollo, gql } from 'apollo-angular';

const GET_FINDINGS = gql`
  query findings(
    $limit: Int!
    $offset: Int!
    $sorting: SortFinding!
    $direction: SortDirection
    $filter: String
    $categories: [String!]
    $severities: [String!]
    $classes: [String!]
    $voltages: [Float!]
  ) {
    findings(
      input: {
        limit: $limit
        offset: $offset
        sorting: $sorting
        direction: $direction
        filter: $filter
        categories: $categories
        severities: $severities
        classes: $classes
        voltages: $voltages
      }
    ) {
      ... on FindingsResult {
        result {
          guid
          category
          severity
          message
          __typename
          ... on NodeFinding {
            referencedNode {
              guid
              name
              className {
                shortName
                fullName
              }
              container {
                guid
                name
                nominalVoltage
                className {
                  shortName
                  fullName
                }
              }
            }
          }
          ... on EquipmentFinding {
            referencedEquipment {
              guid
              name
              className {
                shortName
                fullName
              }
              container {
                guid
                name
                nominalVoltage
                className {
                  shortName
                  fullName
                }
              }
            }
          }
          ... on ContainerFinding {
            referencedContainer {
              guid
              name
              nominalVoltage
              className {
                shortName
                fullName
              }
            }
          }
          ... on AttachmentFinding {
            referencedNode {
              guid
              name
              className {
                shortName
                fullName
              }
              container {
                guid
                name
                nominalVoltage
                className {
                  shortName
                  fullName
                }
              }
            }
            referencedEquipment {
              guid
              name
              className {
                shortName
                fullName
              }
              container {
                guid
                name
                nominalVoltage
                className {
                  shortName
                  fullName
                }
              }
            }
          }
        }
        pageInfo {
          position
          count
        }
      }
      ... on Error {
        cause
        detailedMessage
      }
    }
  }
`;

const GET_CLASSES = gql`
  query classesOfFindings {
    classesOfFindings {
      shortName
      fullName
    }
  }
`;

const GET_CATEGORIES = gql`
  query categories {
    categories
  }
`;

const GET_SEVERITIES = gql`
  query severities {
    severities
  }
`;

const GET_VOLTAGES = gql`
  query voltagesOfFindings {
    voltagesOfFindings
  }
`;

const GET_CLASSES_PERCENTAGES = gql`
  query {
    classPercentages {
      className {
        shortName
      }
      percentage
    }
  }
`;

const GET_VOLTAGES_PERCENTAGES = gql`
  query {
    voltagePercentages {
      voltage
      percentage
    }
  }
`;

const GET_SEVERITIES_PERCENTAGES = gql`
  query {
    severityPercentages {
      severity
      percentage
    }
  }
`;

const GET_CATEGORIES_PERCENTAGES = gql`
  query {
    categoryPercentages {
      category
      percentage
    }
  }
`;

@Injectable({
  providedIn: 'root',
})
export class FindingService {
  private apiUrl = '../../assets/240212-0917_findings_test.txt'; // Ersetze dies durch die tatsächliche URL deiner Datei

  constructor(private http: HttpClient, private apollo: Apollo) {}

  getFindings(FindingInput: FindingInput): Observable<FindingResult | Error> {
    return this.apollo
      .watchQuery<any>({
        query: GET_FINDINGS,
        variables: {
          limit: FindingInput.limit,
          offset: FindingInput.offset,
          sorting: FindingInput.sorting,
          direction: FindingInput.direction,
          filter: FindingInput.filter,
          categories: FindingInput.categories,
          severities: FindingInput.severities,
          classes: FindingInput.classes,
          voltages: FindingInput.voltages,
        },
      })
      .valueChanges.pipe(
        map(({ data }) => data.findings as RawFindingResult | Error),
        map((rawFindings) => {
          if (rawFindings instanceof Error) return rawFindings as Error;

          var rawFindingFinding = rawFindings as RawFindingResult;

          let findingResult: FindingResult = {
            findings: [],
            findingCount: 0,
          };

          if (rawFindingFinding && rawFindingFinding.result) {
            // Map each RawFinding to Finding
            findingResult.findings = rawFindingFinding.result.map(
              (rawFinding) => {
                let finding: Finding;

                // Determine the type of Finding based on __typename
                switch (rawFinding.__typename) {
                  case 'NodeFinding':
                    finding = {
                      ...rawFinding,
                      referencedNode: rawFinding.referencedNode,
                    } as NodeFinding;
                    break;
                  case 'ContainerFinding':
                    finding = {
                      ...rawFinding,
                      referencedContainer: rawFinding.referencedContainer,
                    } as ContainerFinding;
                    break;
                  case 'EquipmentFinding':
                    finding = {
                      ...rawFinding,
                      referencedEquipment: rawFinding.referencedEquipment,
                    } as EquipmentFinding;
                    break;
                  case 'AttachmentFinding':
                    finding = {
                      ...rawFinding,
                      referencedNode: rawFinding.referencedNode,
                      referencedEquipment: rawFinding.referencedEquipment,
                    } as AttachmentFinding;
                    break;
                  default:
                    finding = rawFinding as Finding;
                    break;
                }

                return finding;
              }
            );

            // Set finding count
            findingResult.findingCount = rawFindingFinding.pageInfo.count;
          }

          // console.log('Finding result: ', findingResult);

          return findingResult;
        }),
        catchError((error) => {
          console.error('Error loading findings', error);
          return empty(); // or throw an error if needed
        })
      );
  }

  private parseFinding(line: string): Finding {
    const findingJson = JSON.parse(line);
    return {
      guid: findingJson.staticDataModelObjectGuid,
      category: findingJson.category,
      severity: findingJson.severity,
      message: findingJson.assambledMessage,
    };
  }

  public getFindingsFieldFromSorting(
    sorting: SortFinding | undefined
  ): keyof Finding {
    if (!sorting) {
      return 'guid';
    }

    switch (sorting) {
      case SortFinding.SEVERITY:
        return 'severity';
      case SortFinding.CATEGORY:
        return 'category';
      case SortFinding.MESSAGE:
        return 'message';
      default:
        return 'guid';
    }
  }

  getPercentCategory(): Observable<PercentageData[]> {
    return this.apollo
      .watchQuery<any>({
        query: GET_CATEGORIES_PERCENTAGES,
      })
      .valueChanges.pipe(
        map(({ data }) => data.categoryPercentages as any[]),
        map((data) => {
          return data.map((item) => {
            return {
              name: item.category,
              percent: item.percentage,
            };
          });
        }),
        catchError((error) => {
          console.error('Error loading findings', error);
          return empty(); // or throw an error if needed
        })
      );
  }

  getPercentClass(): Observable<PercentageData[]> {
    return this.apollo
      .watchQuery<any>({
        query: GET_CLASSES_PERCENTAGES,
      })
      .valueChanges.pipe(
        map(({ data }) => data.classPercentages as any[]),
        map((data) => {
          return data.map((item) => {
            return {
              name: item.className.shortName,
              percent: item.percentage,
            };
          });
        }),
        catchError((error) => {
          console.error('Error loading findings', error);
          return empty(); // or throw an error if needed
        })
      );
  }

  getPercentVoltage(): Observable<PercentageData[]> {
    return this.apollo
      .watchQuery<any>({
        query: GET_VOLTAGES_PERCENTAGES,
      })
      .valueChanges.pipe(
        map(({ data }) => data.voltagePercentages as any[]),
        map((data) => {
          return data.map((item) => {
            return {
              name: item.voltage,
              percent: item.percentage,
            };
          });
        }),
        catchError((error) => {
          console.error('Error loading findings', error);
          return empty(); // or throw an error if needed
        })
      );
  }

  getPercentSeverity(): Observable<PercentageData[]> {
    return this.apollo
      .watchQuery<any>({
        query: GET_SEVERITIES_PERCENTAGES,
      })
      .valueChanges.pipe(
        map(({ data }) => data.severityPercentages as any[]),
        map((data) => {
          return data.map((item) => {
            return {
              name: item.severity,
              percent: item.percentage,
            };
          });
        }),
        catchError((error) => {
          console.error('Error loading findings', error);
          return empty(); // or throw an error if needed
        })
      );
  }

  getAllClasses(): Observable<ClassNameInfo[]> {
    return this.apollo
      .watchQuery<any>({
        query: GET_CLASSES,
      })
      .valueChanges.pipe(
        map(({ data }) => data.classesOfFindings as ClassNameInfo[])
      );
  }

  getAllCategories(): Observable<string[]> {
    return this.apollo
      .watchQuery<any>({
        query: GET_CATEGORIES,
      })
      .valueChanges.pipe(map(({ data }) => data.categories as string[]));
  }

  getAllSeverities(): Observable<string[]> {
    return this.apollo
      .watchQuery<any>({
        query: GET_SEVERITIES,
      })
      .valueChanges.pipe(map(({ data }) => data.severities as string[]));
  }

  getAllVoltages(): Observable<number[]> {
    return this.apollo
      .watchQuery<any>({
        query: GET_VOLTAGES,
      })
      .valueChanges.pipe(
        map(({ data }) => data.voltagesOfFindings as number[])
      );
  }

  getModelObject(finding: Finding): ModelObjectInfo {
    if (
      (finding as AttachmentFinding).referencedEquipment &&
      (finding as AttachmentFinding).referencedNode
    ) {
      let attachmentFinding = finding as AttachmentFinding;
      return attachmentFinding.referencedEquipment;
    }

    if ((finding as NodeFinding).referencedNode) {
      let nodeFinding = finding as NodeFinding;
      return nodeFinding.referencedNode;
    }

    if ((finding as ContainerFinding).referencedContainer) {
      let containerFinding = finding as ContainerFinding;
      return containerFinding.referencedContainer;
    }

    if ((finding as EquipmentFinding).referencedEquipment) {
      let equipmentFinding = finding as EquipmentFinding;
      return equipmentFinding.referencedEquipment;
    }

    throw new Error('Unknown finding type');
  }
}
