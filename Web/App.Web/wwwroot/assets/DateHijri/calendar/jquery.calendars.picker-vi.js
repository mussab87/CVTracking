// ***********************************************************************
// Assembly         : Edu
// Author           : Ali Aljarrah && Walid Azouzi
// Created          : 02-23-2020
//
// Last Modified By : Ali Aljarrah && Walid Azouzi
// Last Modified On : 08-23-2015
// ***********************************************************************
// <copyright file="jquery.calendars.picker-vi.js" company="Expert Systems">
//     Copyright ©  2019
// </copyright>
// <summary></summary>
// ***********************************************************************
/* http://keith-wood.name/calendars.html
   Vietnamese localisation for calendars datepicker for jQuery.
   Translated by Le Thanh Huy (lthanhhuy@cit.ctu.edu.vn). */
(function($) {
	/// <summary>
	/// </summary>
	/// <param name="$">The $.</param>
	$.calendarsPicker.regionalOptions['vi'] = {
		renderer: $.calendarsPicker.defaultRenderer,
		prevText: '&#x3c;Trước', prevStatus: 'Tháng trước',
		prevJumpText: '&#x3c;&#x3c;', prevJumpStatus: 'Năm trước',
		nextText: 'Tiếp&#x3e;', nextStatus: 'Tháng sau',
		nextJumpText: '&#x3e;&#x3e;', nextJumpStatus: 'Năm sau',
		currentText: 'Hôm nay', currentStatus: 'Tháng hiện tại',
		todayText: 'Hôm nay', todayStatus: 'Tháng hiện tại',
		clearText: 'Xóa', clearStatus: 'Xóa ngày hiện tại',
		closeText: 'Đóng', closeStatus: 'Đóng và không lưu lại thay đổi',
		yearStatus: 'Năm khác', monthStatus: 'Tháng khác',
		weekText: 'Tu', weekStatus: 'Tuần trong năm',
		dayStatus: 'Đang chọn DD, \'ngày\' d M', defaultStatus: 'Chọn ngày',
		isRTL: false
	};
	$.calendarsPicker.setDefaults($.calendarsPicker.regionalOptions['vi']);
})(jQuery);
