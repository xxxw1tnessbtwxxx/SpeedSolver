import type { GetDefaultToken } from '../../theme/internal';
export interface ComponentToken {
}
export declare const prepareRowComponentToken: GetDefaultToken<'Grid'>;
export declare const prepareColComponentToken: GetDefaultToken<'Grid'>;
export declare const useRowStyle: (prefixCls: string, rootCls?: string) => readonly [(node: React.ReactElement) => React.ReactElement, string, string];
export declare const useColStyle: (prefixCls: string, rootCls?: string) => readonly [(node: React.ReactElement) => React.ReactElement, string, string];
