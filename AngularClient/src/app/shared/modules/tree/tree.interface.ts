import { Observable } from "rxjs";
import { NodeLevel, TreeNode } from "./tree.model";

export interface TreeService {
    deleteTreeNode(id: number, nodeLevel: NodeLevel): Observable<void>;
    openNode(nodeLevel: NodeLevel, treeNode?: TreeNode, parentId?: number): Observable<TreeNode>;
    getTreeNodes(): Observable<TreeNode[]>;
}