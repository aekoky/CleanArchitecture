export enum NodeLevel {
    Node,
    Category,
    Catalog
}

export class TreeNode {
    id?: number;
    name?: string;
    description?: string;
    nodeLevel?: NodeLevel;
    parentId?: number;
    expanded?: boolean;
    childCount?: number;
    children?: TreeNode[];
}