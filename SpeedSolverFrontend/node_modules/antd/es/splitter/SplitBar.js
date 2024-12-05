"use client";

import React, { useState } from 'react';
import DownOutlined from "@ant-design/icons/es/icons/DownOutlined";
import LeftOutlined from "@ant-design/icons/es/icons/LeftOutlined";
import RightOutlined from "@ant-design/icons/es/icons/RightOutlined";
import UpOutlined from "@ant-design/icons/es/icons/UpOutlined";
import classNames from 'classnames';
function getValidNumber(num) {
  return typeof num === 'number' && !Number.isNaN(num) ? Math.round(num) : 0;
}
const SplitBar = props => {
  const {
    prefixCls,
    vertical,
    index,
    active,
    ariaNow,
    ariaMin,
    ariaMax,
    resizable,
    startCollapsible,
    endCollapsible,
    onOffsetStart,
    onOffsetUpdate,
    onOffsetEnd,
    onCollapse
  } = props;
  const splitBarPrefixCls = `${prefixCls}-bar`;
  // ======================== Resize ========================
  const [startPos, setStartPos] = useState(null);
  const onMouseDown = e => {
    if (resizable && e.currentTarget) {
      setStartPos([e.pageX, e.pageY]);
      onOffsetStart(index);
    }
  };
  const onTouchStart = e => {
    if (resizable && e.touches.length === 1) {
      const touch = e.touches[0];
      setStartPos([touch.pageX, touch.pageY]);
      onOffsetStart(index);
    }
  };
  React.useEffect(() => {
    if (startPos) {
      const onMouseMove = e => {
        const {
          pageX,
          pageY
        } = e;
        const offsetX = pageX - startPos[0];
        const offsetY = pageY - startPos[1];
        onOffsetUpdate(index, offsetX, offsetY);
      };
      const onMouseUp = () => {
        setStartPos(null);
        onOffsetEnd();
      };
      const handleTouchMove = e => {
        if (e.touches.length === 1) {
          const touch = e.touches[0];
          const offsetX = touch.pageX - startPos[0];
          const offsetY = touch.pageY - startPos[1];
          onOffsetUpdate(index, offsetX, offsetY);
        }
      };
      const handleTouchEnd = () => {
        setStartPos(null);
        onOffsetEnd();
      };
      window.addEventListener('touchmove', handleTouchMove);
      window.addEventListener('touchend', handleTouchEnd);
      window.addEventListener('mousemove', onMouseMove);
      window.addEventListener('mouseup', onMouseUp);
      return () => {
        window.removeEventListener('mousemove', onMouseMove);
        window.removeEventListener('mouseup', onMouseUp);
        window.removeEventListener('touchmove', handleTouchMove);
        window.removeEventListener('touchend', handleTouchEnd);
      };
    }
  }, [startPos]);
  // ======================== Render ========================
  const StartIcon = vertical ? UpOutlined : LeftOutlined;
  const EndIcon = vertical ? DownOutlined : RightOutlined;
  return /*#__PURE__*/React.createElement("div", {
    className: splitBarPrefixCls,
    role: "separator",
    "aria-valuenow": getValidNumber(ariaNow),
    "aria-valuemin": getValidNumber(ariaMin),
    "aria-valuemax": getValidNumber(ariaMax)
  }, /*#__PURE__*/React.createElement("div", {
    className: classNames(`${splitBarPrefixCls}-dragger`, {
      [`${splitBarPrefixCls}-dragger-disabled`]: !resizable,
      [`${splitBarPrefixCls}-dragger-active`]: active
    }),
    onMouseDown: onMouseDown,
    onTouchStart: onTouchStart
  }), startCollapsible && (/*#__PURE__*/React.createElement("div", {
    className: classNames(`${splitBarPrefixCls}-collapse-bar`, `${splitBarPrefixCls}-collapse-bar-start`),
    onClick: () => onCollapse(index, 'start')
  }, /*#__PURE__*/React.createElement(StartIcon, {
    className: classNames(`${splitBarPrefixCls}-collapse-icon`, `${splitBarPrefixCls}-collapse-start`)
  }))), endCollapsible && (/*#__PURE__*/React.createElement("div", {
    className: classNames(`${splitBarPrefixCls}-collapse-bar`, `${splitBarPrefixCls}-collapse-bar-end`),
    onClick: () => onCollapse(index, 'end')
  }, /*#__PURE__*/React.createElement(EndIcon, {
    className: classNames(`${splitBarPrefixCls}-collapse-icon`, `${splitBarPrefixCls}-collapse-end`)
  }))));
};
export default SplitBar;