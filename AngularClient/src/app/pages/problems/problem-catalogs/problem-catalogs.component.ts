import { Component, output } from '@angular/core';
import { debounceTime } from 'rxjs';
import { SelectionModel, SelectionChange } from '@angular/cdk/collections';
import { takeUntilDestroyed } from '@angular/core/rxjs-interop';
import { NodeLevel, TreeNode } from 'app/shared/models/tree.model';
import { TreeService } from '../tree.service';

@Component({
  selector: 'app-problem-catalogs',
  templateUrl: './problem-catalogs.component.html',
  styleUrls: ['./problem-catalogs.component.css'],
  standalone: false
})
export class ProblemCatalogsComponent {
  NodeLevel = NodeLevel;
  treeSelection = new SelectionModel<TreeNode>(true, [], true, (node1, node2) => node1?.id + '' + node1?.nodeLevel === node2?.id + '' + node2?.nodeLevel);
  selectionChanged = output<TreeNode[]>();

  constructor(
    readonly treeService: TreeService
  ) {
    this.treeSelection.changed.pipe(
      debounceTime(250),
      takeUntilDestroyed())
      .subscribe((change: SelectionChange<TreeNode>) => this.selectionChanged.emit(this.treeSelection.selected))
  }

  expansionKeyFn = (dataNode: TreeNode) => dataNode.id + '' + dataNode.nodeLevel;

  trackByFn = (index: number, dataNode: TreeNode) => this.expansionKeyFn(dataNode);

  childrenAccessor = (node: TreeNode) => node.children ?? [];

  hasChild = (_: number, node: TreeNode) => !!node.children && node.children?.length > 0;

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
    this.treeSelection.toggle(selectedNode);
  }

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

  descendantsPartiallySelected(node: TreeNode): boolean {
    const descendants = node?.children;
    const result = descendants.some(child => this.treeSelection.isSelected(child));
    return result && !this.descendantsAllSelected(node);
  }

  nodeSelectionToggle(node: TreeNode): void {
    this.treeSelection.toggle(node);
    const descendants = node?.children;
    this.treeSelection.isSelected(node)
      ? this.treeSelection.select(...descendants)
      : this.treeSelection.deselect(...descendants);
  }
}
