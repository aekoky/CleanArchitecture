import { Injectable, OnDestroy } from "@angular/core";
import { Subject } from "rxjs";

interface Entity {
    id?: number | string;
}
@Injectable()
export abstract class CacheService<T extends Entity> {
    private readonly _cache = new Map<number | string, T>();

    getCache(id: number | string): T | undefined {
        return this._cache.get(id);
    }

    setCache(entity: T) {
        if (entity.id)
            this._cache.set(entity.id, entity);
    }

    removeCache(id: number | string) {
        this._cache.delete(id);
    }
}