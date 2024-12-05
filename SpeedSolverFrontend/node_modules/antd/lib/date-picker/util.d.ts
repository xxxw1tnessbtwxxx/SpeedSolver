import * as React from 'react';
import type { PickerMode } from 'rc-picker/lib/interface';
import type { PickerLocale, PickerProps } from './generatePicker';
export declare function getPlaceholder(locale: PickerLocale, picker?: PickerMode, customizePlaceholder?: string): string;
export declare function getRangePlaceholder(locale: PickerLocale, picker?: PickerMode, customizePlaceholder?: [string, string]): [string, string] | undefined;
export declare function useIcons(props: Pick<PickerProps, 'allowClear' | 'removeIcon'>, prefixCls: string): readonly [false | {
    clearIcon: React.ReactNode;
}, string | number | boolean | Iterable<React.ReactNode> | React.JSX.Element | ((props: any) => React.ReactNode) | null];
