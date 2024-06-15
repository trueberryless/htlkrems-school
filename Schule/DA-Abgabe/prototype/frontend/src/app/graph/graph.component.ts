import { Component, HostListener } from '@angular/core';
import cytoscape, { BaseLayoutOptions, Stylesheet } from 'cytoscape';
import cola from 'cytoscape-cola';
import d3Force from 'cytoscape-d3-force';

import { MatCardModule } from '@angular/material/card';
import { DarkModeService, GraphService } from '@app/_services';
import {
  ColaLayoutOptions,
  D3LayoutOptions,
  GraphElement,
  ModelObject,
  colaLayout,
  d3Layout,
  Error,
} from '@app/_models';
import { ActivatedRoute } from '@angular/router';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';

import { debounce } from 'lodash';

@Component({
  selector: 'app-graph',
  standalone: true,
  imports: [MatCardModule, MatProgressSpinnerModule],
  templateUrl: './graph.component.html',
  styleUrl: './graph.component.scss',
})
export class GraphComponent {
  nodesEdges: GraphElement[] | Error = [];
  start!: string;

  cy: any;

  stylesheet: Stylesheet[] = [
    // the stylesheet for the graph
    {
      selector: 'node',
      style: {
        'background-color': '#666',
        label: 'data(label)',
        'text-wrap': 'ellipsis',
        'text-max-width': '100px',
        'font-family': 'Roboto, arial, sans-serif',
        // 'font-size': '12px',
        'text-background-color': '#ddd',
        'text-background-shape': 'roundrectangle',
        'text-background-opacity': 0.9,
        'text-background-padding': '10px',
      },
    },

    {
      selector: 'edge',
      style: {
        width: 3,
        'line-color': '#ccc',
        'target-arrow-color': '#ccc',
        'target-arrow-shape': 'triangle',
        // 'curve-style': 'unbundled-bezier',
        // 'curve-style': 'taxi',
        // label: 'data(id)',
        // 'text-rotation': 'autorotate',
        'text-wrap': 'ellipsis',
        'text-max-width': '100px',
        'font-family': 'Roboto, arial, sans-serif',
        // 'font-size': '12px',
        'text-background-color': '#ddd',
        'text-background-shape': 'roundrectangle',
        'text-background-opacity': 0.9,
        'text-background-padding': '10px',
      },
    },
  ];

  constructor(
    private graphService: GraphService,
    private darkModeService: DarkModeService,
    private route: ActivatedRoute
  ) {}

  ngAfterContentInit(): void {
    cytoscape.use(cola);
    cytoscape.use(d3Force);

    this.route.queryParams.subscribe((params) => {
      this.start = params['start'];
      this.graphService
        .getNodeEdges({
          modelObjectsToLoad: [this.start],
          modelObjectsToIgnore: [],
          depth: 30,
        })
        .subscribe((data) => {
          if ('detailedMessage' in data) {
            document.getElementById('no-object')!.style.display = 'block';
          }
          this.nodesEdges = data as GraphElement[];
          document.getElementById('spinner')!.style.display = 'none';

          this.cy = cytoscape({
            container: document.getElementById('cy'), // container to render in
            elements: this.nodesEdges as GraphElement[],
            style: this.stylesheet as Stylesheet[],
            layout: colaLayout,
          });

          this.darkModeService.darkMode$.subscribe((darkMode) => {
            if (darkMode) {
              this.cy
                .style()
                .clear()
                .fromJson([
                  ...this.stylesheet,
                  {
                    selector: 'node',
                    style: {
                      'background-color': '#eee',
                    },
                  },
                  {
                    selector: 'edge',
                    style: {
                      'line-color': '#888',
                      color: '#fff',
                      'text-background-color': '#222',
                    },
                  },
                ])
                .update();
              document.getElementById('guid')!.style.color = '#8792d3';
            } else {
              this.cy.style().clear().fromJson(this.stylesheet).update();
              document.getElementById('guid')!.style.color = '#3F51B5';
            }
          });

          this.cy.getElementById(this.start).position({
            x: 0,
            y: 0,
          });

          // this.cy.fit(this.cy.elements(), 30);
          this.cy.zoom(1);

          this.cy.maxZoom(2);
          this.cy.minZoom(0.1);

          this.cy.elements('#' + this.start).style({
            color: '#fff',
            'text-background-color': '#3F51B5',
            'line-color': '#bf4c41',
          });

          // setInterval(() => {
          //   console.log(this.cy.getElementById(this.start).renderedPosition());
          // }, 1000);

          // var lastClick = 0;
          // var delay = 1000;

          // this.cy.on('dragpan', (event: { target: any }) => {
          //   var nodes = this.cy.nodes();

          //   var viewport = this.cy.extent();

          //   var loadnodesIds: string[] = [];

          //   nodes.forEach((node: any) => {
          //     var nodePosition = node.position();

          //     if (
          //       (nodePosition.x >= viewport.x2 &&
          //         nodePosition.x <= viewport.x2 + 100 &&
          //         nodePosition.y >= viewport.y1 &&
          //         nodePosition.y <= viewport.y2) ||
          //       (nodePosition.x <= viewport.x1 &&
          //         nodePosition.x >= viewport.x1 - 100 &&
          //         nodePosition.y >= viewport.y1 &&
          //         nodePosition.y <= viewport.y2) ||
          //       (nodePosition.y >= viewport.y2 &&
          //         nodePosition.y <= viewport.y2 + 100 &&
          //         nodePosition.x >= viewport.x1 &&
          //         nodePosition.x <= viewport.x2) ||
          //       (nodePosition.y <= viewport.y1 &&
          //         nodePosition.y >= viewport.y1 - 100 &&
          //         nodePosition.x >= viewport.x1 &&
          //         nodePosition.x <= viewport.x2) ||
          //       (nodePosition.x >= viewport.x2 &&
          //         nodePosition.x <= viewport.x2 + 100 &&
          //         nodePosition.y >= viewport.y2 &&
          //         nodePosition.y <= viewport.y2 + 100) ||
          //       (nodePosition.x <= viewport.x1 &&
          //         nodePosition.x >= viewport.x1 - 100 &&
          //         nodePosition.y >= viewport.y2 &&
          //         nodePosition.y <= viewport.y2 + 100) ||
          //       (nodePosition.x >= viewport.x2 &&
          //         nodePosition.x <= viewport.x2 + 100 &&
          //         nodePosition.y <= viewport.y1 &&
          //         nodePosition.y >= viewport.y1 - 100) ||
          //       (nodePosition.x <= viewport.x1 &&
          //         nodePosition.x >= viewport.x1 - 100 &&
          //         nodePosition.y <= viewport.y1 &&
          //         nodePosition.y >= viewport.y1 - 100)
          //     ) {
          //       loadnodesIds.push(node.id());
          //     }
          //   });

          //   if (loadnodesIds.length > 0) {
          //     if (lastClick >= Date.now() - delay) return;
          //     lastClick = Date.now();
          //     console.log('loadnodesIds', loadnodesIds);
          //     this.graphService
          //       .getNodeEdges({
          //         modelObjectsToLoad: loadnodesIds,
          //         modelObjectsToIgnore: nodes
          //           .map((node: any) => node.id())
          //           .filter((id: any) => !loadnodesIds.includes(id)),
          //         depth: 2,
          //       })
          //       .subscribe((data) => {
          //         this.cy.add(data as GraphElement[]);
          //         // this.cy.layout.stop();
          //         this.cy.layout({ colaLayout }).run();
          //         // this.cy = cytoscape({
          //         //   container: document.getElementById('cy'), // container to render in
          //         //   elements: [
          //         //     ...(this.nodesEdges as GraphElement[]),
          //         //     ...(data as GraphElement[]),
          //         //   ],
          //         //   style: this.stylesheet as Stylesheet[],
          //         //   layout: colaLayout,
          //         // });
          //       });
          //   }
          // });

          // this.cy.on('tap', 'edge', (evt: { target: any }) => {
          //   var edge = evt.target;
          //   // console.log('tapped ' + edge.id());
          //   // copyToClipboard(edge.id());

          //   this.graphService
          //     .getNodeEdges({
          //       modelObjectId: edge.id(),
          //       depth: 3,
          //     })
          //     .subscribe((data) => {
          //       this.cy.add(data as GraphElement[]);
          //       // this.cy.layout.run();
          //     });
          // });

          // this.cy.on('tap', 'node', (evt: { target: any }) => {
          //   var node = evt.target;
          // });
        });
    });

    // timeout
    // setTimeout(() => {
    //   var eles = cy.add([
    //     { group: 'nodes', data: { id: 'c' }, position: { x: 500, y: 500 } },
    //     { group: 'edges', data: { id: 'ca', source: 'c', target: 'a' } },
    //   ]);
    // }, 3000);

    // cy.animate(
    //   {
    //     center: { eles: 'c' },
    //     zoom: 0.5,
    //   },
    //   {
    //     duration: 1000,
    //     easing: 'ease-in-out',
    //   }
    // );
  }

  @HostListener('window:resize', ['$event'])
  onResize = debounce(
    (event: any) => {
      if (this.cy) {
        this.cy.animate({
          fit: {
            eles: this.cy.elements(),
            padding: 30,
          },
          duration: 600,
          easing: 'ease-in-out-quint',
        });
      }
    },
    200,
    { leading: false, trailing: true }
  );
}

async function copyToClipboard(text: string): Promise<void> {
  try {
    await navigator.clipboard.writeText(text);
    console.log('Text copied to clipboard successfully');
  } catch (err) {
    console.error('Unable to copy text to clipboard', err);
  }
}
