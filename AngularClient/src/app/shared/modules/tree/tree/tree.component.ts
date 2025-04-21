
import { AfterViewInit, Component, Input, OnDestroy } from '@angular/core';
import { BehaviorSubject, debounceTime, Subject, take, takeUntil } from 'rxjs';
import { NodeLevel, TreeNode } from '../tree.model';
import { TreeService } from '../tree.interface';
import { SelectionChange, SelectionModel } from '@angular/cdk/collections';


@Component({
  selector: 'app-tree',
  templateUrl: './tree.component.html',
  styleUrl: './tree.component.css',
  host: { 'class': 'flex flex-col justify-start items-start min-h-0' },
  standalone: false
})
export class TreeComponent implements AfterViewInit, OnDestroy {
  NodeLevel = NodeLevel;
  private readonly _unsubscribeAll: Subject<any> = new Subject<any>();

  treeSelection = new SelectionModel<TreeNode>(true, [], true, (node1, node2) => node1?.id + '' + node1?.nodeLevel === node2?.id + '' + node2?.nodeLevel);
  nodes = new BehaviorSubject<Array<TreeNode>>([]);
  @Input() treeService: TreeService;
  @Input() selectedNodes: Subject<TreeNode[]>;

  constructor() {
    this.treeSelection.changed.pipe(
      takeUntil(this._unsubscribeAll),
      debounceTime(250)
    ).subscribe((change: SelectionChange<TreeNode>) => this.selectedNodes?.next(this.treeSelection.selected))
  }

  expansionKeyFn = (dataNode: TreeNode) => dataNode.id + '' + dataNode.nodeLevel;

  trackByFn = (index: number, dataNode: TreeNode) => this.expansionKeyFn(dataNode);

  childrenAccessor = (node: TreeNode) => node.children ?? [];

  hasChild = (_: number, node: TreeNode) => !!node.children && node.children?.length > 0;

  ngAfterViewInit(): void {
    if (this.treeService)
      this.treeService.getTreeNodes().subscribe(this.nodes);
  }

  openNode(nodeLevel: NodeLevel, treeNode?: TreeNode, parentId?: number) {
    this.treeService.openNode(nodeLevel, treeNode, parentId).subscribe(node => { });
  }

  deleteNode(id: number, nodeLevel: NodeLevel) {
    this.treeService.deleteTreeNode(id, nodeLevel).subscribe(node => {
    });
  }

  stopPropagation(event) {
    event.stopPropagation();
  }

  selectNode(selectedNode: TreeNode) {
    this.selectedNodes.pipe(take(1)).subscribe(
      selectedNodes => {
        const selectedNodeIndex = selectedNodes.findIndex(node => node.id === selectedNode.id && node.nodeLevel === selectedNode.nodeLevel)
        if (selectedNodeIndex === -1)
          selectedNodes.push(selectedNode);
        else
          selectedNodes.splice(selectedNodeIndex, 1);
        this.selectedNodes.next(selectedNodes);
      }
    )
  }
  /** Whether all the descendants of the node are selected */
  descendantsAllSelected(node: TreeNode): boolean {
    const descendants = node?.children;
    if (descendants?.length === 0) {
      return this.treeSelection.isSelected(node);
    }
    const allselected = descendants.every(child => this.treeSelection.isSelected(child));
    if (allselected) {
      this.treeSelection.select(node);
    } else {
      this.treeSelection.deselect(node);
    }
    return allselected;
  }

  /** Whether part of the descendants are selected */
  descendantsPartiallySelected(node: TreeNode): boolean {
    const descendants = node?.children;
    const result = descendants.some(child => this.treeSelection.isSelected(child));
    return result && !this.descendantsAllSelected(node);
  }

  /** Toggle the to-do item selection. Select/deselect all the descendants node */
  todoItemSelectionToggle(node: TreeNode): void {
    this.treeSelection.toggle(node);
    const descendants = node?.children;
    this.treeSelection.isSelected(node)
      ? this.treeSelection.select(...descendants)
      : this.treeSelection.deselect(...descendants);
  }

  ngOnDestroy(): void {
    // Unsubscribe from all subscriptions
    this._unsubscribeAll.next(null);
    this._unsubscribeAll.complete();
    this.nodes.complete();
  }
}
