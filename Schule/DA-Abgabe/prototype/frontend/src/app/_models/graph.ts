export interface GraphElement {
  data: Node | Edge;
}

export interface Node {
  id: string;
  label: string;
}

export interface Edge {
  id: string;
  source: string;
  target: string;
}
