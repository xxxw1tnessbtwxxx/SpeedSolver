import React from 'react';
export type LoadingIconProps = {
    prefixCls: string;
    existIcon: boolean;
    loading?: boolean | object;
    className?: string;
    style?: React.CSSProperties;
};
declare const LoadingIcon: React.FC<LoadingIconProps>;
export default LoadingIcon;
