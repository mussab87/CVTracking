﻿// ***********************************************************************
// Assembly         : Edu
// Author           : Ali Aljarrah && Walid Azouzi
// Created          : 02-23-2020
//
// Last Modified By : Ali Aljarrah && Walid Azouzi
// Last Modified On : 08-23-2015
// ***********************************************************************
// <copyright file="jquery.calendars.picker-ur.js" company="Expert Systems">
//     Copyright ©  2019
// </copyright>
// <summary></summary>
// ***********************************************************************
/* http://keith-wood.name/calendars.html
   Urdu localisation for calendars datepicker for jQuery.
   Mansoor Munib -- mansoormunib@gmail.com <http://www.mansoor.co.nr/mansoor.html>
   Thanks to Habib Ahmed, ObaidUllah Anwar. */
(function($) {
	/// <summary>
	/// </summary>
	/// <param name="$">The $.</param>
	$.calendarsPicker.regionalOptions['ur'] = {
		renderer: $.calendarsPicker.defaultRenderer,
		prevText: '&#x3c;گذشتہ', prevStatus: 'ماه گذشتہ',
		prevJumpText: '&#x3c;&#x3c;', prevJumpStatus: 'برس گذشتہ',
		nextText: 'آئندہ&#x3e;', nextStatus: 'ماه آئندہ',
		nextJumpText: '&#x3e;&#x3e;', nextJumpStatus: 'برس آئندہ',
		currentText: 'رواں', currentStatus: 'ماه رواں',
		todayText: 'آج', todayStatus: 'آج',
		clearText: 'حذف تاريخ', clearStatus: 'کریں حذف تاریخ',
		closeText: 'کریں بند', closeStatus: 'کیلئے کرنے بند',
		yearStatus: 'برس تبدیلی', monthStatus: 'ماه تبدیلی',
		weekText: 'ہفتہ', weekStatus: 'ہفتہ',
		dayStatus: 'انتخاب D, M d', defaultStatus: 'کریں منتخب تاريخ',
		isRTL: true
	};
	$.calendarsPicker.setDefaults($.calendarsPicker.regionalOptions['ur']);
})(jQuery);
