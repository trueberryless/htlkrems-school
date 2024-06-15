import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { map, switchMap } from 'rxjs/operators';

import {
  Edge,
  ModelObject,
  ModelObjectInput,
  ModelObjectResult,
  Node,
  Error,
} from '@app/_models';
import { ModelObjectService } from './modelObject.service';
import { GraphElement } from '@app/_models';
import { GraphComponent } from '@app/graph/graph.component';
import { mode } from 'd3';

@Injectable({
  providedIn: 'root',
})
export class GraphService {
  nodeId!: number;

  constructor(
    private http: HttpClient,
    private modelObjectService: ModelObjectService
  ) {}

  getNodeEdges(input: ModelObjectInput): Observable<Error | GraphElement[]> {
    return this.modelObjectService.getModelObjects(input).pipe(
      switchMap((data) => {
        if ('detailedMessage' in data) return of(data);

        var modelObjectResult: ModelObjectResult = data;

        // console.log(data);

        // modelObjectResult = modelObjectResult as ModelObject;

        var nodes: GraphElement[] = [];
        var edges: GraphElement[] = [];

        nodes = modelObjectResult.result.map((modelObject) => {
          return {
            data: {
              id: modelObject.guid,
              label: modelObject.name,
            },
          } as GraphElement;
        });

        modelObjectResult.result.forEach((modelObject) => {
          modelObject.connections.forEach((connection, index) => {
            if (connection.included) {
              edges.push({
                data: {
                  id: modelObject.guid + connection.guid,
                  source: modelObject.guid,
                  target: connection.modelObjectGuid,
                },
              } as GraphElement);
            }
          });
        });

        return of([...nodes, ...edges] as GraphElement[]);

        // nodes.push({ data: { id: 'n1' } });
        // nodes.push({ data: { id: 'n2' } });
        // edges.push({
        //   data: { id: modelObjectResult.guid, source: 'n1', target: 'n2' },
        // });

        // this.nodeId = 3;

        // const mapNode = (modelObject: ModelObject): void => {
        //   let edge = edges.find((edge) => edge.data.id === modelObject.guid)
        //     ?.data as Edge;

        //   modelObject.connections.forEach((connection, index) => {
        //     let modelObjectConnection = connection.modelObject as ModelObject;

        //     if (
        //       this.ExtractEdges(edges).find(
        //         (edge) => edge.id === modelObjectConnection.guid
        //       ) ||
        //       modelObjectConnection.connections.length === 0
        //     ) {
        //       return;
        //     }

        //     // Herausfinden, an welchen Stellen die Edge angeschlossen werden muss.
        //     let nodeConnections: [
        //       source: Edge['source'],
        //       target: Edge['target']
        //     ];

        //     var node1 = this.NodeWithMoreSimilarity(
        //       nodes,
        //       edges,
        //       modelObject,
        //       modelObjectConnection
        //     );

        //     var node2 = this.NodeWithMostSimilarity(
        //       nodes,
        //       edges,
        //       modelObject,
        //       modelObjectConnection,
        //       node1
        //     );

        //     // console.log(edge.id + ': ' + node1.id + ' ' + node2.id);

        //     nodeConnections = [node1.id, node2.id];

        //     let newEdge: Edge = {
        //       id: connection.guid,
        //       source: nodeConnections[0],
        //       target: nodeConnections[1],
        //     };
        //     edges.push({ data: newEdge });

        //     mapNode(modelObjectConnection);
        //   });
        // };

        // mapNode(modelObjectResult);

        // console.log('Observable test: ', of([...nodes, ...edges]));

        // return of([...nodes, ...edges]);
      })
    );
  }

  // private ExtractNodes(nodes: GraphElement[]): Node[] {
  //   return nodes.map((node) => node.data) as Node[];
  // }

  // private ExtractEdges(edges: GraphElement[]): Edge[] {
  //   return edges.map((edge) => edge.data) as Edge[];
  // }

  // private EdgeOnNode(edge: Edge, node: Node): boolean {
  //   return edge.source === node.id || edge.target === node.id;
  // }

  // private EdgesOnNode(edges: Edge[], node: Node): Edge[] {
  //   return edges.filter((edge) => this.EdgeOnNode(edge, node));
  // }

  // private GetRandomEnd(edge: Edge): Edge['source'] | Edge['target'] {
  //   return Math.random() < 0.5 ? edge.source : edge.target;
  // }

  // private EdgesHaveSameConnections(
  //   modelObjectConnection: ModelObject,
  //   modelObject: ModelObject
  // ): boolean {
  //   return (
  //     modelObjectConnection.connections.filter(
  //       (connection) => connection.guid != modelObjectConnection.guid
  //     ) ==
  //     modelObject.connections.filter(
  //       (connection) => connection.guid != modelObject.guid
  //     )
  //   );
  // }

  // private CountSameValues(list1: any[], list2: any[]): number {
  //   let count = 0;
  //   for (let i = 0; i < list1.length; i++) {
  //     for (let j = 0; j < list2.length; j++) {
  //       if (list1[i] == list2[j]) {
  //         count++;
  //       }
  //     }
  //   }
  //   return count;
  // }

  // private ListIncluded(small_list: any[], big_list: any[]): boolean {
  //   // Check if each element in list1 is present in list2
  //   for (const item of small_list) {
  //     if (!big_list.includes(item)) {
  //       return false;
  //     }
  //   }
  //   return true;
  // }

  // private NodeWithMoreSimilarity(
  //   nodes: GraphElement[],
  //   edges: GraphElement[],
  //   modelObject: ModelObject,
  //   modelObjectConnection: ModelObject
  // ): Node {
  //   let currentEdge = edges.find((edge) => edge.data.id === modelObject.guid)
  //     ?.data as Edge;

  //   let currentNode: Node = { id: currentEdge.source };

  //   let edgesOnNode = this.EdgesOnNode(
  //     edges.map((edge) => edge.data as Edge),
  //     currentNode
  //   );

  //   let edgesOnNodeIds = edgesOnNode.map((edge) => edge.id);
  //   let modelObjectConnectionIds = modelObjectConnection.connections.map(
  //     (modelObjectConnection) => modelObjectConnection.guid
  //   );

  //   console.log(
  //     '\x1b[36m%s\x1b[0m',
  //     'ModelObjectConnection: ' + modelObjectConnection.guid + '\n',
  //     'ModelObject: ' + modelObject.guid + '\n',
  //     'Edge: ' + currentEdge.id + '\n',
  //     'Node: ' + currentNode.id + '\n',
  //     'Edges on Node: ' + edgesOnNodeIds + '\n',
  //     'Edge Connections: ' + modelObjectConnectionIds
  //   );

  //   if (edgesOnNode.length <= 1) {
  //     console.log('\x1b[31m%s\x1b[0m', 'Little edges on node.');

  //     return currentNode;
  //     // return { id: this.GetRandomEnd(currentEdge) };
  //   }

  //   if (
  //     this.CountSameValues(edgesOnNodeIds, modelObjectConnectionIds) >= 2 &&
  //     this.ListIncluded(edgesOnNodeIds, modelObjectConnectionIds)
  //   ) {
  //     console.log('\x1b[32m%s\x1b[0m', 'Edges on node are similar.');
  //     return currentNode;
  //   } else {
  //     console.log('\x1b[31m%s\x1b[0m', 'Edges on node are not similar.');
  //     return { id: currentEdge.target } as Node;
  //   }
  // }

  // private NodeWithMostSimilarity(
  //   nodes: GraphElement[],
  //   edges: GraphElement[],
  //   modelObject: ModelObject,
  //   modelObjectConnection: ModelObject,
  //   firstNode: Node
  // ): Node {
  //   for (const node of nodes.filter((node) => node.data.id != firstNode.id)) {
  //     let edgesOnNode = this.EdgesOnNode(
  //       edges.map((edge) => edge.data as Edge),
  //       node.data as Node
  //     );

  //     let sameEdge = this.ExtractEdges(edges).find((edge) => {
  //       return (
  //         (edge.source === firstNode.id && edge.target === node.data.id) ||
  //         (edge.source === node.data.id && edge.target === firstNode.id)
  //       );
  //     });

  //     if (sameEdge) {
  //       continue;
  //     }

  //     let edgesOnNodeIds = edgesOnNode.map((edge) => edge.id);
  //     let modelObjectConnectionIds = modelObjectConnection.connections.map(
  //       (modelObjectConnection) => modelObjectConnection.guid
  //     );

  //     console.log(
  //       '\x1b[33m%s\x1b[0m',
  //       'ModelObjectConnection: ' + modelObjectConnection.guid + '\n',
  //       'ModelObject: ' + modelObject.guid + '\n',
  //       'Node: ' + node.data.id + '\n',
  //       'Edges on Node: ' + edgesOnNodeIds + '\n',
  //       'Edge Connections: ' + modelObjectConnectionIds
  //     );

  //     if (this.ListIncluded(edgesOnNodeIds, modelObjectConnectionIds)) {
  //       console.log('\x1b[32m%s\x1b[0m', 'Similar node found.');
  //       return node.data as Node;
  //     }
  //   }

  //   console.log('\x1b[31m%s\x1b[0m', 'No other similar nodes found.');

  //   let newNode = { id: 'n' + this.nodeId++ } as Node;
  //   nodes.push({ data: newNode });

  //   return newNode;
  // }
}
