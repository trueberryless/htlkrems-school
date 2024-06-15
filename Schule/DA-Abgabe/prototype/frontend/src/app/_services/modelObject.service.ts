import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, empty, of } from 'rxjs';
import { catchError, map, switchMap } from 'rxjs/operators';
import {
  ContainerInfo,
  ModelObject,
  ModelObjectInConnection,
  ModelObjectInput,
  ModelObjectResult,
  Error,
} from '@app/_models';

import { Apollo, gql } from 'apollo-angular';

interface RawData {
  guid: string;
  name: string;
  className: string;
  modelObjectType: string;
  container: ContainerInfo;
  linkedObjects?: string[];
}

const GET_MODEL_OBJECTS = gql`
  query modelObjects(
    $modelObjectsToLoad: [ID!]!
    $modelObjectsToIgnore: [ID!]!
    $depth: Int!
  ) {
    modelObjects(
      input: {
        modelObjectsToLoad: $modelObjectsToLoad
        modelObjectsToIgnore: $modelObjectsToIgnore
        depth: $depth
      }
    ) {
      result {
        guid
        name
        className {
          shortName
        }
        container {
          guid
          name
          className {
            shortName
          }
          nominalVoltage
        }
        connections {
          guid
          modelObjectGuid
          included
        }
      }
    }
  }
`;

@Injectable({
  providedIn: 'root',
})
export class ModelObjectService {
  private apiUrl = '../../assets/231030-1326_modelObjects.txt'; // Ersetze dies durch die tatsächliche URL deiner Datei

  constructor(private http: HttpClient, private apollo: Apollo) {}

  getModelObjects(
    input: ModelObjectInput
  ): Observable<ModelObjectResult | Error> {
    return this.apollo
      .watchQuery<any>({
        query: GET_MODEL_OBJECTS,
        variables: {
          modelObjectsToLoad: input.modelObjectsToLoad,
          modelObjectsToIgnore: input.modelObjectsToIgnore,
          depth: input.depth,
        },
      })
      .valueChanges.pipe(
        map(({ data }) => data.modelObjects as ModelObjectResult | Error),
        map((rawModelObject) => {
          if ('detailedMessage' in rawModelObject)
            return rawModelObject as Error;

          var rawModelObjectResult = rawModelObject as ModelObjectResult;

          // console.log('Model object result: ', rawModelObjectResult);

          return rawModelObjectResult;
        }),
        catchError((error) => {
          console.error('Error loading findings', error);
          return empty(); // or throw an error if needed
        })
      );
  }

  private parseFinding(line: string): RawData {
    const modelObjectJson = JSON.parse(line);
    return {
      guid: modelObjectJson.guid,
      name: modelObjectJson.name,
      className: modelObjectJson.className,
      modelObjectType: modelObjectJson.modelObjectType,
      container: modelObjectJson.container,
      linkedObjects: modelObjectJson.linkedObjects ?? [],
    };
  }
}
