import type { Dayjs } from 'dayjs';
import type { CalendarProps } from './generateCalendar';
import generateCalendar from './generateCalendar';
declare const Calendar: import("react").FC<Readonly<CalendarProps<Dayjs>>>;
export type CalendarType = typeof Calendar & {
    generateCalendar: typeof generateCalendar;
};
export type { CalendarProps };
declare const _default: CalendarType;
export default _default;
