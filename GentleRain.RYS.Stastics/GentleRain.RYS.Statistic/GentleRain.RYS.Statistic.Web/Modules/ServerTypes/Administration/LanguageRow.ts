import { getLookup, getLookupAsync, fieldsProxy } from "@serenity-is/corelib";

export interface LanguageRow {
    Id?: number;
    LanguageId?: string;
    LanguageName?: string;
}

export abstract class LanguageRow {
    static readonly idProperty = 'Id';
    static readonly nameProperty = 'LanguageName';
    static readonly localTextPrefix = 'Administration.Language';
    static readonly lookupKey = 'RYS.Statistic.Administration.Language';

    /** @deprecated use getLookupAsync instead */
    static getLookup() { return getLookup<LanguageRow>('RYS.Statistic.Administration.Language') }
    static async getLookupAsync() { return getLookupAsync<LanguageRow>('RYS.Statistic.Administration.Language') }

    static readonly deletePermission = 'Administration:Translation';
    static readonly insertPermission = 'Administration:Translation';
    static readonly readPermission = 'Administration:Translation';
    static readonly updatePermission = 'Administration:Translation';

    static readonly Fields = fieldsProxy<LanguageRow>();
}