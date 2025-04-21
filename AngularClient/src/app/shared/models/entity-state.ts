import { ViewMode } from "../enums/view-mode.enum";

export class EntityState {
    entity?: any;
    filters?: any;
    isClientSide?: boolean;
    viewMode?: ViewMode;
}