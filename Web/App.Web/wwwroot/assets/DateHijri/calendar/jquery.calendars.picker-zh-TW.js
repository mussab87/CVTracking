﻿// ***********************************************************************
// Assembly         : Edu
// Author           : Ali Aljarrah && Walid Azouzi
// Created          : 02-23-2020
//
// Last Modified By : Ali Aljarrah && Walid Azouzi
// Last Modified On : 08-23-2015
// ***********************************************************************
// <copyright file="jquery.calendars.picker-zh-TW.js" company="Expert Systems">
//     Copyright ©  2019
// </copyright>
// <summary></summary>
// ***********************************************************************
/* http://keith-wood.name/calendars.html
   Traditional Chinese localisation for calendars datepicker for jQuery.
   Written by Ressol (ressol@gmail.com). */
(function($) {
	/// <summary>
	/// </summary>
	/// <param name="$">The $.</param>
	$.calendarsPicker.regionalOptions['zh-TW'] = {
		renderer: $.extend({}, $.calendarsPicker.defaultRenderer,
			{month: $.calendarsPicker.defaultRenderer.month.
				replace(/monthHeader/, 'monthHeader:MM yyyy年')}),
		prevText: '&#x3c;上月', prevStatus: '顯示上月',
		prevJumpText: '&#x3c;&#x3c;', prevJumpStatus: '顯示上一年',
		nextText: '下月&#x3e;', nextStatus: '顯示下月',
		nextJumpText: '&#x3e;&#x3e;', nextJumpStatus: '顯示下一年',
		currentText: '今天', currentStatus: '顯示本月',
		todayText: '今天', todayStatus: '顯示本月',
		clearText: '清除', clearStatus: '清除已選日期',
		closeText: '關閉', closeStatus: '不改變目前的選擇',
		yearStatus: '選擇年份', monthStatus: '選擇月份',
		weekText: '周', weekStatus: '年內周次',
		dayStatus: '選擇 m月 d日, DD', defaultStatus: '請選擇日期',
		isRTL: false
	};
	$.calendarsPicker.setDefaults($.calendarsPicker.regionalOptions['zh-TW']);
})(jQuery);
