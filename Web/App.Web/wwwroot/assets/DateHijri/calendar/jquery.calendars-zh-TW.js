// ***********************************************************************
// Assembly         : Edu
// Author           : Ali Aljarrah && Walid Azouzi
// Created          : 02-23-2020
//
// Last Modified By : Ali Aljarrah && Walid Azouzi
// Last Modified On : 01-16-2016
// ***********************************************************************
// <copyright file="jquery.calendars-zh-TW.js" company="Expert Systems">
//     Copyright ©  2019
// </copyright>
// <summary></summary>
// ***********************************************************************
/* http://keith-wood.name/calendars.html
   Traditional Chinese localisation for Gregorian/Julian calendars for jQuery.
   Written by Ressol (ressol@gmail.com). */
(function($) {
	/// <summary>
	/// </summary>
	/// <param name="$">The $.</param>
	$.calendars.calendars.gregorian.prototype.regionalOptions['zh-TW'] = {
		name: 'Gregorian',
		epochs: ['BCE', 'CE'],
		monthNames: ['一月','二月','三月','四月','五月','六月',
		'七月','八月','九月','十月','十一月','十二月'],
		monthNamesShort: ['一','二','三','四','五','六',
		'七','八','九','十','十一','十二'],
		dayNames: ['星期日','星期一','星期二','星期三','星期四','星期五','星期六'],
		dayNamesShort: ['周日','周一','周二','周三','周四','周五','周六'],
		dayNamesMin: ['日','一','二','三','四','五','六'],
		digits: $.calendars.substituteChineseDigits(
			['〇', '一', '二', '三', '四', '五', '六', '七', '八', '九'], ['', '十', '百', '千']),
		dateFormat: 'yyyy/mm/dd',
		firstDay: 1,
		isRTL: false
	};
	if ($.calendars.calendars.julian) {
		$.calendars.calendars.julian.prototype.regionalOptions['zh-TW'] =
			$.calendars.calendars.gregorian.prototype.regionalOptions['zh-TW'];
	}
})(jQuery);
