import { Component, output } from '@angular/core';
import { debounceTime } from 'rxjs';
import { SelectionModel, SelectionChange } from '@angular/cdk/collections';
import { takeUntilDestroyed } from '@angular/core/rxjs-interop';
import { NodeLevel, TreeNode } from 'app/shared/models/tree.model';
import { TreeService } from '../tree.service';
import { MatBadgeModule } from '@angular/material/badge';
import { MatButtonModule } from '@angular/material/button';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatDividerModule } from '@angular/material/divider';
import { MatMenuModule } from '@angular/material/menu';
import { MatTreeModule } from '@angular/material/tree';
import { MatIconModule } from '@angular/material/icon';
import { CommonModule } from '@angular/common';

@Component({
  imports: [
    CommonModule,
    MatBadgeModule,
    MatTreeModule,
    MatDividerModule,
    MatCheckboxModule,
    MatMenuModule,
    MatButtonModule,
    MatIconModule
  ],
  selector: 'app-problem-catalogs',
  templateUrl: './problem-catalogs.component.html',
  styleUrls: ['./problem-catalogs.component.css'],
})
export class ProblemCatalogsComponent {
  NodeLevel = NodeLevel;

  constructor(
    readonly treeService: TreeService
  ) {
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
    this.treeService.treeSelection.toggle(selectedNode);
  }

  descendantsAllSelected(node: TreeNode): boolean {
    const descendants = node?.children;
    if (descendants?.length === 0) {
      return this.treeService.treeSelection.isSelected(node);
    }
    const allselected = descendants.every(child => this.treeService.treeSelection.isSelected(child));
    if (allselected) {
      this.treeService.treeSelection.select(node);
    } else {
      this.treeService.treeSelection.deselect(node);
    }
    return allselected;
  }

  descendantsPartiallySelected(node: TreeNode): boolean {
    const descendants = node?.children;
    const result = descendants.some(child => this.treeService.treeSelection.isSelected(child));
    return result && !this.descendantsAllSelected(node);
  }

  nodeSelectionToggle(node: TreeNode): void {
    this.treeService.treeSelection.toggle(node);
    const descendants = node?.children;
    this.treeService.treeSelection.isSelected(node)
      ? this.treeService.treeSelection.select(...descendants)
      : this.treeService.treeSelection.deselect(...descendants);
  }
}
