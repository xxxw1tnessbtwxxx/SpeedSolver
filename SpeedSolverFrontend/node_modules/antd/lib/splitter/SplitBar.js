"use strict";
"use client";

var _interopRequireDefault = require("@babel/runtime/helpers/interopRequireDefault").default;
var _interopRequireWildcard = require("@babel/runtime/helpers/interopRequireWildcard").default;
Object.defineProperty(exports, "__esModule", {
  value: true
});
exports.default = void 0;
var _react = _interopRequireWildcard(require("react"));
var _DownOutlined = _interopRequireDefault(require("@ant-design/icons/DownOutlined"));
var _LeftOutlined = _interopRequireDefault(require("@ant-design/icons/LeftOutlined"));
var _RightOutlined = _interopRequireDefault(require("@ant-design/icons/RightOutlined"));
var _UpOutlined = _interopRequireDefault(require("@ant-design/icons/UpOutlined"));
var _classnames = _interopRequireDefault(require("classnames"));
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
  const [startPos, setStartPos] = (0, _react.useState)(null);
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
  _react.default.useEffect(() => {
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
  const StartIcon = vertical ? _UpOutlined.default : _LeftOutlined.default;
  const EndIcon = vertical ? _DownOutlined.default : _RightOutlined.default;
  return /*#__PURE__*/_react.default.createElement("div", {
    className: splitBarPrefixCls,
    role: "separator",
    "aria-valuenow": getValidNumber(ariaNow),
    "aria-valuemin": getValidNumber(ariaMin),
    "aria-valuemax": getValidNumber(ariaMax)
  }, /*#__PURE__*/_react.default.createElement("div", {
    className: (0, _classnames.default)(`${splitBarPrefixCls}-dragger`, {
      [`${splitBarPrefixCls}-dragger-disabled`]: !resizable,
      [`${splitBarPrefixCls}-dragger-active`]: active
    }),
    onMouseDown: onMouseDown,
    onTouchStart: onTouchStart
  }), startCollapsible && (/*#__PURE__*/_react.default.createElement("div", {
    className: (0, _classnames.default)(`${splitBarPrefixCls}-collapse-bar`, `${splitBarPrefixCls}-collapse-bar-start`),
    onClick: () => onCollapse(index, 'start')
  }, /*#__PURE__*/_react.default.createElement(StartIcon, {
    className: (0, _classnames.default)(`${splitBarPrefixCls}-collapse-icon`, `${splitBarPrefixCls}-collapse-start`)
  }))), endCollapsible && (/*#__PURE__*/_react.default.createElement("div", {
    className: (0, _classnames.default)(`${splitBarPrefixCls}-collapse-bar`, `${splitBarPrefixCls}-collapse-bar-end`),
    onClick: () => onCollapse(index, 'end')
  }, /*#__PURE__*/_react.default.createElement(EndIcon, {
    className: (0, _classnames.default)(`${splitBarPrefixCls}-collapse-icon`, `${splitBarPrefixCls}-collapse-end`)
  }))));
};
var _default = exports.default = SplitBar;